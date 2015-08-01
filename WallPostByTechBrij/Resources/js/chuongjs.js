
$(function () {
    // cho nay khai bao su kien 
    var ajaxDropdowlistSelectchange = function () {
        var $ddlmain = $(this);
        var $ddltaget = $($ddlmain.attr("data-otf-target"));
        var actionlink = $ddlmain.attr("data-otf-action");
        $.ajax({
            cache: false,
            type: "GET",
            url: actionlink,
            data: { "value": $ddlmain.val(), "actionname": $ddlmain.attr("data-otf-actionname") },
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
    var submitAutocompleteFormdoanhnghiep = function (event, ui) {
        var $input = $(this);
        $input.val(ui.item.label);
        var url = $input.attr("data-otf-tagetaction") + "?diugpeihgnhnaod=" + ui.item.value;
        window.location.href = url;
    };
    var createAutocompletedoanhnghiep = function () {
        var $input = $(this);
        var options = {
            minLength: 3,
            source: $input.attr("data-otf-action"),
            select: submitAutocompleteFormdoanhnghiep
        };
        $input.autocomplete(options);
    }

    $("select[data-otf-selectchange='true']").change(ajaxDropdowlistSelectchange);
    $("input[data-otf-autocomplete ='true']").each(createAutocompletedoanhnghiep);
});

// kiem tra ton tai hinh
function imageExists(image_url) {
    var http = new XMLHttpRequest();
    http.open('HEAD', image_url, false);
    http.send();
    return http.status != 404;
}

// doi lai hinh logo khi thay doi
function ChangeImageLogo(imagetype) {
    var link = $("#logoview").attr("data-otf-target");
    d = new Date();
    var linkurlimage = "/Data/ThongTinDoanhNghiep/Logo/" + link + "_logo" + "." + imagetype;
    if (imageExists(linkurlimage)) {
        $("#logoview").attr("src", linkurlimage + "?" + d.getTime());
    } else {
        $("#logoview").attr("src", "Resources/img/no-logo.png" + "?" + d.getTime());
    }
}

// xoa logo
function DeletelLogo(element) {
    var $a = $(element);
    var actionlink = $a.attr("data-otf-action-target");
    var xacnhan = confirm("Có chắc chắn muốn xóa logo này?");
    if (xacnhan == true) {
        $.ajax({
            cache: false,
            type: "POST",
            url: actionlink,
            success: function (data) {
                if (data == "true") {
                    $($a.attr("data-otf-target")).css('display', 'none');
                }
                else
                    alert('Không thể xóa logo vui lòng liên hệ quản trị để khắc phục');
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert('server bận vui lòng quay lại sau ít phút nữa');
            }
        });
    }
}
// xoa doanh nghiep
function XoaDoanhnghiepClick(element) {
    var conf = confirm("Bạn chắc chắn muốn xóa doanh nghiệp này, và mọi hoạt động liên quan?");
    var $button = $(element);
    if (conf) {
        $.ajax({
            type: "POST",
            url: $button.attr("data-otf-action-target"),
            success: function (data) {
                if (data == true) {
                    alert('Xóa thành công. hệ thống sẽ chuyển đến trang mặc định!');
                    var url1 = $button.attr("data-otf-target");
                    window.location.href = url1;
                }
                else
                    alert('Không thể xóa doanh nghiệp vui lòng liên hệ quản trị để khắc phục!');
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert('server bận vui lòng quay lại sau ít phút nữa!');
            }
        });
    }
}

// danh cho cap tai lieu ao
function ClosePopupAndLoadDataChuong(idPopup, idActionLoadList, errormessage) {

    if (idPopup != 'null') {
        $(idPopup).modal('hide');
    }

    if (idActionLoadList != 'null') {
        var idList = $(idActionLoadList).attr("data-otf-target");
        $(idList).load($(idActionLoadList).attr("data-otf-action"));
    }
    DialogAlert("", errormessage, 1);
}

function ClosePopupAndLoadDataEditChuong(idPopup, idActionLoadList, errormessage) {

    if (idPopup != 'null')
        $(idPopup).modal('hide');

    if (idActionLoadList != 'null') {
        var idList = $(idActionLoadList).attr("data-otf-target");
        $(idList).load($(idActionLoadList).attr("data-otf-action"));
    }
    DialogAlert("", errormessage, 1);
}

function GetTabDanhSachMonHoc(element) {
    var $button = $(element);
    var idList = $button.attr("data-otf-target");
    $(idList).load($button.attr("data-otf-action"));
    return true;
}
function ClickEditMonHoc(element) {
    var $button = $(element);
    var idList = $button.attr("data-otf-target");
    $(idList).load($button.attr("data-otf-action"));

    return true;
}
function ReloadDanhSachMon(errormessage) {

    DialogAlert("", errormessage, 1);
}

function ClickXoaMonHoc(element) {

    var trangThai = confirm("Bạn chắc muốn xóa môn học và trương trình dạy môn này?");
    if (trangThai == false)
        return true;
    var $button = $(element);
    var idList = $button.attr("data-otf-target");
    $(idList).load($button.attr("data-otf-actionmain"));
    $(idList).load($button.attr("data-otf-action"));

    return true;
}

function XoaFileDinhKem(element) {

    var $button = $(element);
    var conf = confirm("Bạn chắc chắn muốn xóa tài liệu buổi này?");
    if (conf) {
        $.ajax({
            type: "POST",
            url: $button.attr("data-otf-action"),
            success: function (data) {
                if (data == true) {
                    var idList = $button.attr("data-otf-target");
                    $(idList).load($button.attr("data-otf-actionload"));
                }
                else
                    alert('Không thể xóa vui lòng liên hệ quản trị để khắc phục!');
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert('server bận vui lòng quay lại sau ít phút nữa!');
            }
        });
    }


}

function ThemFileVaoCap(element) {
    var $button = $(element);
    $.ajax({
        type: "POST",
        url: $button.attr("data-otf-action"),
        success: function (data) {
            if (data == true) {
                $($button.attr("data-otf-target")).css({ "display": "block" });
            }
            else
                alert('Không thể thêm vui lòng liên hệ quản trị để khắc phục!');
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert('server bận vui lòng quay lại sau ít phút nữa!');
        }
    });
}