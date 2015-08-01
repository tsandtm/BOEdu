
$(function () {
    // cho nay khai bao su kien 
    var submitAutocompleteFormdoanhnghiep = function (event, ui) {
        var $input = $(this);
        var $inputValue = $('#hiddenFieldValue');
        $input.val(ui.item.label);
        $inputValue.val(ui.item.value);

    };
    var loadAutoCompleteDoanhNghiep = function () {
        var $input = $(this);
        var options = {
            minLength: 3,
            source: $input.attr("data-otf-action"),
            select: submitAutocompleteFormdoanhnghiep
        };
        $input.autocomplete(options);

    }

    $("input[data-otf-autocomplete ='true']").each(loadAutoCompleteDoanhNghiep);
});

//search danh sách doanh nghiệp
function ajaxSearchListDoanhNghiep() {
    var $button = $("#buttonsearch");
    var idList = $button.attr("data-otf-target");
    var valTextbox = $("#txtdoanhnghiep").val();
    var valDropdownlist = $("#ddlnganhnghe").val();
    var queryString = valDropdownlist + "_" + valTextbox;

    $(idList).load($button.attr("data-otf-action") + "?q=" + queryString);
}


//gán url action cho button export excel danh sách doanh nghiệp
function ajaxSearchListDoanhNghiepForExcel() {
    var $button = $("#btnexportexcel");
    var valTextbox = $("#txtdoanhnghiep").val();
    var valDropdownlist = $("#ddlnganhnghe").val();
    var queryString = valDropdownlist + "_" + valTextbox;

    document.location = $button.attr("data-otf-action") + "?q=" + queryString;
}

function showPopupThemLienHe(itemGuid, element) {
    var $thea = $(element);
    var $idlist = $($thea.attr("data-otf-target"))
    $idlist.load($thea.attr("data-otf-action") + "?itemguid=" + itemGuid)
}

//lưu thông tin liên hệ
function saveThongTinLienHe(doanhnghiepguid) {
    var $button = $("#buttonSaveLienHe");
    var valhoten = $("#txtHoTen").val();
    var valcontent = $("#editorLienHe").val();

    var queryString = valhoten + "_" + valcontent + "_" + doanhnghiepguid;

    $.ajax({
        type: 'Post',
        cache: false,
        url: $("#formAddThongTinLienHe").attr("action") + "&q=" + queryString,
        success: function (data) {
        }
    })
}



function openPopupLienHe(element) {
    var $button = $(element);
    var idList = $button.attr("data-otf-target");

    //var editor = CKEDITOR.instances[ckeditorLienHe];
    //if (editor) { editor.destroy(true); }
    //CKEDITOR.replace('editorLienHe');

    //var editor = CKEDITOR.instances[ckeditorLienHeEdit];
    //if (editor) { editor.destroy(true); }
    //CKEDITOR.replace('ckeditorLienHeEdit');

    $(idList).load($button.attr("data-otf-action"));
    return true;
}
function GetTabThongTinLienHe(element) {
    var $button = $(element);
    var idList = $button.attr("data-otf-target");
    $(idList).load($button.attr("data-otf-action"));
    return true;
}

//gán action cho sự kiện nhấn enter trong textbox tìm kiếm
function EnterEvent(event, textbox, button, ajaxEvent) {
    if (event.which == 13) {
        //$('#buttonsearch').trigger('submit');
        //$('#txtdoanhnghiep').select();
        //ajaxSearchListDoanhNghiep();
        $('#' + textbox).select();
        ajaxSearchList(textbox, button);
    }
}

// HoaDM function() lay tat ca dieu kien loc cua filter de dung ham get chung
// theo thu tu truong du lieu luu tru
function GetDataFilter(textboxsearch) {
    //var stringSearch = "";
    // position 0: textbox key search, id textbox truyen vao
    var stringSearch = $("#" + textboxsearch).val().trim().replace("_", "");

    //quan ly tuyen dung
    //position 1: doanhnghiepguid
    var doanhnghiepguid = $("#hiddenFieldValue").val();
    stringSearch += "_" + doanhnghiepguid;
    //position 2: tungay
    var tungay = $("#inputTuNgay").val();
    stringSearch += "_" + tungay;
    //position 3: denngay
    var denngay = $("#inputDenNgay").val();
    stringSearch += "_" + denngay;
    //continue

    //danh sach doanh nghiep
    //position 4: nganhngheguid
    var nganhngheguid = $("#ddlnganhnghe").val();
    stringSearch += "_" + nganhngheguid;
    //end danh sach doanh nghiep

    //continue quan ly tuyen dung
    //position 5: doituongthamgiaguid
    var doituongthamgiaguid = $("#ddlListDoiTuongThamGia").val();
    stringSearch += "_" + doituongthamgiaguid;
    //position 6: hinhthuclamviecguid
    var hinhthuclamviecguid = $("#ddlListHinhThucLamViec").val();
    stringSearch += "_" + hinhthuclamviecguid;
    //position 7: vitrituyendungguid
    var vitrituyendungguid = $("#ddlListViTriTuyenDung").val();
    stringSearch += "_" + vitrituyendungguid;
    //end quan ly tuyen dung

    return stringSearch;
}

//search danh sách dung chung
function ajaxSearchList(textbox, button) {
    var $button = $("#" + button);
    var idList = $button.attr("data-otf-target");
    var textSearch = GetDataFilter(textbox);
    textSearch = textSearch.replace(" ", "+");
    //alert(textSearch);
    $(idList).load($button.attr("data-otf-action") + "?q=" + textSearch);
}

//export danh sách dùng chung
function ajaxSearchListForExcel(textbox, button) {
    var $button = $("#" + button);
    var idList = $button.attr("data-otf-target");
    var textSearch = GetDataFilter(textbox);
    textSearch = textSearch.replace(" ", "+");

    document.location = $button.attr("data-otf-action") + "?q=" + textSearch;
}

function AutocompalteDN(element, valueset) {
    var $input = $(element);
    function createAutocompletedoanhnghiep() {
        var options = {
            columns: ["label", "value"],
            minLength: 3,
            source: $input.attr("data-otf-action"),
            select: function (event, ui) {
                this.value = (ui.item ? ui.item.label : '');
                $(valueset).val(ui.item.value);
                return false;
            },
            focus: function (event, ui) {
                $(this).val(ui.item.label);
                return false;
            },
        };
        $input.autocomplete(options);

    }
    createAutocompletedoanhnghiep();
}

function LoadEventEditThongTinHopTac(idList, action) {

    $(idList).load(action, function (responseTxt, statusTxt, xhr) {

        location.href = action;
        return false;
        //if (statusTxt == "success") {
        //    $('#data_ngaygap .input-group.date').datepicker({
        //        format: 'dd/mm/yyyy',
        //        todayBtn: "linked",
        //        keyboardNavigation: false,
        //        forceParse: false,
        //        calendarWeeks: true,
        //        autoclose: true
        //    });
        //    CKEDITOR.replace('ckeditorKetQua');
        //    CKEDITOR.replace('ckeditorThamGia');
        //    CKEDITOR.replace('ckeditorNoiDung');
        //    AutocompalteDN('#textdoanhnghep', "#hivalue", "#dllthongtinlienhe");
        //    $("#licreate").addClass("active");
        //    $("#listlichsu").removeClass("active");
        //}
    });


    //Step: Load edit tuyển dụng
    var $button = $(this);
    var idListFile = $button.attr("data-otf-action-target-id");
    var idList = $button.attr("data-otf-target");

    $(idList).load($button.attr("data-otf-action"), function (responseTxt, statusTxt, xhr) {
        if (statusTxt == "success") {
            var config = {
                '.chosen-select': {},
                '.chosen-select-deselect': { allow_single_deselect: true },
                '.chosen-select-no-single': { disable_search_threshold: 10 },
                '.chosen-select-no-results': { no_results_text: 'Lỗi! Vui lòng chọn ít nhất 1 mục.' },
                '.chosen-select-width': { width: "95%" }
            }
            for (var selector in config) {
                $(selector).chosen(config[selector]);
            }
            $('.search-choice>a').on('click', function (event) {
                var data = $.map($('li.search-choice>span'), function (element) { return $(element).text() }).join(';');
                $('#DoiTuongThamGiaName').val(data);

            });
            $('#DoiTuongThamGia_chosen>.chosen-drop>.chosen-results>li').on('click', function (event) {
                var data = $.map($('li.search-choice>span'), function (element) { return $(element).text() }).join(';');
                $('#DoiTuongThamGiaName').val(data);

            });
            $("#my-awesome-dropzone").dropzone({
                autoProcessQueue: true,
                parallelUploads: 1,
                maxFiles: 100,
                paramName: "files",
                uploadMultiple: false,
                maxFilesize: 1000,
                init: function () {
                    var myDropzone = this;
                    this.on("complete", function (data) {
                    });
                    this.on("queuecomplete", function (file) {
                        $(idListFile).load($button.attr("data-otf-action-target"));
                        myDropzone.removeAllFiles();
                    });
                    this.on("errormultiple", function (files, response) {
                    });
                }
            });
            $('#data_tuyendung_tungay .input-group.date').datepicker({
                format: 'dd/mm/yyyy',
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                calendarWeeks: true,
                autoclose: true
            });
            $('#data_tuyendung_denngay .input-group.date').datepicker({
                format: 'dd/mm/yyyy',
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                calendarWeeks: true,
                autoclose: true
            });
            $('#datetungay').datepicker("option", "dateFormat", "dd/mm/yyyy").val();
            $('#datedenngay').datepicker("option", "dateFormat", "dd/mm/yyyy").val();
            $(idListFile).load($button.attr("data-otf-action-target"));
        }
    });
    //end load edit tuyển dụng

}


function openPopupQuanLyTuyenDung(element) {
    var $button = $(element);
    var idList = $button.attr("data-otf-target");

    $(idList).load($button.attr("data-otf-action"), function () {

        //kiem tra de loai tru cai nay
        var config = {
            '.chosen-select': {},
            '.chosen-select-deselect': { allow_single_deselect: true },
            '.chosen-select-no-single': { disable_search_threshold: 10 },
            '.chosen-select-no-results': { no_results_text: 'Lỗi! Vui lòng chọn ít nhất 1 mục.' },
            '.chosen-select-width': { width: "95%" }
        }
        for (var selector in config) {
            $(selector).chosen(config[selector]);
        }

        AutocompalteDN('#inputDoanhNghiepName', '#hiddenFieldDoanhNghiepName');


        $('#data_tuyendung_tungay .input-group.date').datepicker({
            format: 'dd/mm/yyyy',
            todayBtn: "linked",
            keyboardNavigation: false,
            forceParse: false,
            calendarWeeks: true,
            autoclose: true
        });

        $('#data_tuyendung_denngay .input-group.date').datepicker({
            format: 'dd/mm/yyyy',
            todayBtn: "linked",
            keyboardNavigation: false,
            forceParse: false,
            calendarWeeks: true,
            autoclose: true
        });


    });


    return true;

}


function openPopupUsers(element) {
    var $button = $(element);
    var idList = $button.attr("data-otf-target");

    $(idList).load($button.attr("data-otf-action"));
    return true;
}

function deleteListItem(element) {
    var $button = $(element);
    if ($button.attr("data-otf-confirm"))
        if (!confirm($button.attr("data-otf-confirm")))
            return false;

    var idList = $button.attr("data-otf-target");

    var numberCheckboxSeleted = $(idList + " input.checkbox-item:checked").length;
    var count = 0;
    $(idList + " input.checkbox-item").each(function (index, value) {
        if ($(this).is(':checked')) {
            $.ajax({
                type: 'Post',
                cache: false,
                url: $button.attr("data-otf-action") + $(this).attr("value"),
                //data: { selectedIds: selectedIds },
                //dataType: "json",
                success: function (data) {
                    count++;
                    if (count == numberCheckboxSeleted)
                        $(idList).load($button.attr("data-otf-action-target"));
                }
            }).done(function () {
            });
        }
    });
    return false;
}

