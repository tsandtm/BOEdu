function AutocompalteDN(element, valueset, id_loadDDL) {
    var $input = $(element);
    function createAutocompletedoanhnghiep() {
        var options = {
            columns: ["label", "value"],
            minLength: 3,
            source: $input.attr("data-otf-action"),
            select: function (event, ui) {
                this.value = (ui.item ? ui.item.label : '');
                $(valueset).val(ui.item.value);

                ajaxDropdowlistFromAutocomplate(ui.item.value, id_loadDDL, $input.attr("data-otf-action-loadchilrend"));
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


function ajaxDropdowlistFromAutocomplate(itemvalue, id_ddl, actionlink) {
    var $ddltaget = $(id_ddl);

    $.ajax({
        cache: false,
        type: "GET",
        url: actionlink,
        data: { "value": itemvalue },//parametter 
        success: function (data) {
            $ddltaget.html('');
            $.each(data, function (id, option) {
                $ddltaget.append($('<option></option>').val(option.id).html(option.name));
            });
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert('server bận vui lòng quay lại sau ít phút nữa');
        }
    });
};
function DeleteCAT(element) {
    var $button = $(element);
    if ($button.attr("data-otf-confirm"))
        if (!confirm($button.attr("data-otf-confirm")))
            return false;


    var idList = $button.attr("data-otf-target");
    //chua kiem tra data-otf-mutil

    //trường họp 1 item 
    $.ajax({
        type: 'Post',
        cache: false,
        url: $button.attr("data-otf-action"),
        //data: { selectedIds: selectedIds },
        //dataType: "json",
        success: function (data) {
            $(idList).load($button.attr("data-otf-action-target"));
        }
    }).done(function () {
    });
    return true;

}

function DeleteFileSystem(element) {
    var $button = $(element);
    if ($button.attr("data-otf-confirm"))
        if (!confirm($button.attr("data-otf-confirm")))
            return false;


    var idList = $button.attr("data-otf-target");
    //chua kiem tra data-otf-mutil

    //trường họp 1 item 
    $.ajax({
        type: 'Post',
        cache: false,
        url: $button.attr("data-otf-action"),
        //data: { selectedIds: selectedIds },
        //dataType: "json",
        success: function (data) {
            $(idList).load($button.attr("data-otf-action-target"));
        }
    }).done(function () {
    });
    return true;

}

function LoadEditCauHinhCaiDat(element) {
    var $button = $(element);
    var idListFile = $button.attr("data-otf-action-target-id");
    var idList = $button.attr("data-otf-target");
    // $(idList).load($button.attr("data-otf-action"));


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
            $(idListFile).load($button.attr("data-otf-action-target"));
        }

    });


    return true;
}

function getView(element) {
    var $button = $(element);
    var idList = $button.attr("data-otf-target");
    $(idList).load($button.attr("data-otf-action"));
}

function ReloadPatial(idList, action, idListFile, tagertfile) {

    //showmessageerror('Thông báo', 'Thao tác thành công!', 2);

    $(idList).load(action, function (responseTxt, statusTxt, xhr) {

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

            //$('.chosen-select').on('change', function (event) {
            //    var data = $.map($('li.search-choice>span'), function (element) { return $(element).text() }).join(';');
            //    $('#DoiTuongThamGiaName').val(data);

            //});
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
                        $(idListFile).load(tagertfile);
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

        }

    });
}
function AddTuyenDung(element) {
    var $button = $(element);
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
            //$('.chosen-select').on('change', function (event) {
            //    var data = $.map($('li.search-choice>span'), function (element) { return $(element).text() }).join(';');
            //    $('#DoiTuongThamGiaName').val(data);

            //});

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
        }

    });


}
function LoadEditTuyenDung(element) {
    var $button = $(element);
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
            //$('.chosen-select').on('change', function (event) {
            //    var data = $.map($('li.search-choice>span'), function (element) { return $(element).text() }).join(';');
            //    $('#DoiTuongThamGiaName').val(data);

            //});


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


    return true;
}
function DeleteTuyenDung(element) {
    var $button = $(element);


    if ($button.attr("data-otf-confirm"))
        if (!confirm($button.attr("data-otf-confirm")))
            return false;


    var idList = $button.attr("data-otf-target");
    //chua kiem tra data-otf-mutil
    var ismultil = $button.attr("data-otf-mutil");
    if (ismultil == "false") {
        //trường họp 1 item 
        $.ajax({
            type: 'Post',
            cache: false,
            url: $button.attr("data-otf-action") ,
            //data: { selectedIds: selectedIds },
            //dataType: "json",
            success: function (data) {

                    $(idList).load($button.attr("data-otf-action-target"));
            }
        }).done(function () {
        });
        return true;
    }

    //trường họp nhiều item    
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


function ReloadEditChiTietLienHe(idList, action) {

    //showmessageerror('Thông báo', 'Thao tác thành công!', 2);

    $(idList).load(action, function (responseTxt, statusTxt, xhr) {

        if (statusTxt == "success") {

            $('#data_ngaygap .input-group.date').datepicker({
                format: 'dd/mm/yyyy',
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                calendarWeeks: true,
                autoclose: true
            });
            CKEDITOR.replace('ckeditorKetQua');
            CKEDITOR.replace('ckeditorThamGia');
            CKEDITOR.replace('ckeditorNoiDung');
            AutocompalteDN('#textdoanhnghep', "#hivalue", "#dllthongtinlienhe");
            $("#licreate").addClass("active");
            $("#listlichsu").removeClass("active");
        }

    });
}

