// 0: hoat dong
// 1: hoc bong
// 2: tai tro
// 3: thuc tap
// 4: tuyen dung
function reloadWithQueryStringVarsHoatDong(queryStringVars) {
    url = getURLFun() + "Page/10042014_HDHTDoanhNghiep/FolderPageThongTinDoanhNghiep/PageThongTinChiTietDoanhNghiep.aspx",
        currentUrl = location.search ? url.replace(location.search, "") : url,
        newQueryVars = {},
        newUrl = currentUrl + "?";

    if (queryStringVars) {
        for (var queryStringVar in queryStringVars) {
            newQueryVars[queryStringVar] = queryStringVars[queryStringVar];
        }
    }
    if (newQueryVars) {
        for (var newQueryVar in newQueryVars) {
            newUrl += newQueryVar + "=" + newQueryVars[newQueryVar] + "&";
        }
        newUrl = newUrl.substring(0, newUrl.length - 1);
        window.location.href = newUrl;
        //window.open(newUrl, '_blank');
    } else {
        window.location.href = location.href;
        // window.open(location.href, '_blank');
    }
}

function OnclickHoatDong(tabindex, thongtinhoptacguid) {

    var guidDoanhNghiep = GetParameterValues("index");
    reloadWithQueryStringVarsHoatDong({ "peihgnhnaoddiug": guidDoanhNghiep, "TabIndex": tabindex, "diugcatpohnitgnoht": thongtinhoptacguid });
}

function HBOnClick(idDiv, loaicontent) {
    if (!$.trim(idDiv.html())) { // kiem tra xem co noi dung html trong do ko
        LoadHoatDongDN(loaicontent, idDiv);
    }
}
function GetParameterValues(param) {
    var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < url.length; i++) {
        var urlparam = url[i].split('=');
        if (urlparam[0] == param) {
            return urlparam[1];
        }
    }
}
function currencyFormatDE(num) {
    return num
       .toFixed(2) // always two decimal digits
       .replace(".", ",") // replace decimal point character with ,
       .replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1.") + " VND" // use . as a separator
}

function imageExists(image_url) {
    var http = new XMLHttpRequest();
    http.open('HEAD', image_url, false);
    http.send();
    return http.status != 404;
}

function LoadHoatDongDN(loai, divID) {

    var linkFile = getURLFun() + "Data/ThongTinHocBong/Doc/";
    var linkHinh = getURLFun() + "Data/ThongTinHocBong/Image/";
    var linkHinhThum = getURLFun() + "Data/ThongTinHocBong/Image/250x300/";
    var linkHinhLogo = getURLFun() + "Data/ThongTinDoanhNghiep/Logo/250x300/";
    var linknologo = getURLFun() + "Resources/img/no-logo.png";
    var linknoimage = getURLFun() + "Resources/img/no-image.png";

    var currentUserGuid = getCurrentUser();
    var doanhNGhiepGuid = GetParameterValues('index');
    var LoaiGuid = loai;
    var myElementToAppendTo = divID;
    var urlsv = "ThongTinHopTacService.asmx/LoadThongTinHopTac";
    var payload = '{ "loaiGuid":"' + LoaiGuid + '","doanhNGuid":"' + doanhNGhiepGuid + '","userguid":"' + currentUserGuid + '"}';
    $.ajax({
        type: "POST",
        url: urlsv,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: payload,
        success: function (data) {
            var start = 0;
            var contentString = "<div class='feed-activity-list'>";
            var count = Object.keys(data.d).length;
            while (count > start) {
                contentString += "<div class='feed-element'>"
                                + "<span class='pull-left'>";
                if (data.d[start]["HinhAnhLogo"] != "" && imageExists(linkHinhLogo + data.d[start]["HinhAnhLogo"]))
                    contentString += "<img alt='image' class='img-circle' src='" + linkHinhLogo + data.d[start]["HinhAnhLogo"] + "'>";
                else
                    contentString += "<img alt='image' class='img-circle' src='" + linknologo + "'>";
                contentString += "</span>" // can bo sung hinh
                                + "<div class='media-body'>"
                                + "<small class='pull-right'>" + data.d[start]["StringCreateDate"] + "</small>"; // bo sung tinh ngay
                if (loai == '26adf09d-adf6-4882-86c7-b9bc41b19374' || (loai == '00000000-0000-0000-0000-000000000000' && data.d[start]["CatologyGuid"] == '26adf09d-adf6-4882-86c7-b9bc41b19374')) // hoc bong
                    contentString += "<a target=\"_blank\" onclick=\"OnclickHoatDong('HB','" + data.d[start]["ThongTinHopTacGuid"] + "')\">Tặng <strong>" + data.d[start]["SoLuong"] + " suất học bổng </strong> tổng trị giá <strong>" + currencyFormatDE(data.d[start]["TriGia"]) + "</strong></a><br>"
                                          + data.d[start]["DieuKien"] + "<br>";
                if (loai == '7aaf1c69-8a5a-4fef-843f-81c0030b8e7f' || (loai == '00000000-0000-0000-0000-000000000000' && data.d[start]["CatologyGuid"] == '7aaf1c69-8a5a-4fef-843f-81c0030b8e7f')) // tai tro
                    contentString += "<a target=\"_blank\" onclick=\"OnclickHoatDong('HT','" + data.d[start]["ThongTinHopTacGuid"] + "')\">Tài trợ <strong>" + data.d[start]["HinhThucTaiTroName"] + "</strong> tổng trị giá <strong>" + currencyFormatDE(data.d[start]["TriGia"]) + "</strong></a><br>"
                                          + data.d[start]["NoiDung"] + "<br>";
                if (loai == 'cbfca483-5e44-4a6e-916b-16a45a5c63bf' || (loai == '00000000-0000-0000-0000-000000000000' && data.d[start]["CatologyGuid"] == 'cbfca483-5e44-4a6e-916b-16a45a5c63bf')) // thuc tap
                    contentString += "<a target=\"_blank\" onclick=\"OnclickHoatDong('TT','" + data.d[start]["ThongTinHopTacGuid"] + "')\">Tuyển thực tập <strong>" + data.d[start]["HinhThucLamViecName"] + "</strong> số lượng <strong>" + data.d[start]["SoLuong"] + "</strong> chỉ tiêu</a><br>"
                                          + data.d[start]["DieuKien"] + "<br>";
                if (loai == 'cf1cda6d-273c-4d9a-b944-7c110b5982d2' || (loai == '00000000-0000-0000-0000-000000000000' && data.d[start]["CatologyGuid"] == 'cf1cda6d-273c-4d9a-b944-7c110b5982d2')) //tuyen dung
                    contentString += "<a target=\"_blank\" onclick=\"OnclickHoatDong('TD','" + data.d[start]["ThongTinHopTacGuid"] + "')\">Tuyển dụng nhân sự <strong>" + data.d[start]["HinhThucLamViecName"] + "</strong> số lượng <strong>" + data.d[start]["SoLuong"] + "</strong> chỉ tiêu</a><br>"
                                          + data.d[start]["DieuKien"] + "<br>";
                // them file
                var countDoc = Object.keys(data.d[start]["DanhSachVanBanMinhChung"]).length;
                if (countDoc > 0) {
                    contentString += "<div>";
                    var indexDoc = 0;
                    while (countDoc > indexDoc) {
                        contentString += "<img src='subforum_old.gif'>"
                            + "<img src='IconFileType/16/" + data.d[start]["DanhSachVanBanMinhChung"][indexDoc]["FileType"] + ".gif'>"
                            + "<a target='_blank' href='" + linkFile + data.d[start]["DanhSachVanBanMinhChung"][indexDoc]["ServerFileName"] + "'>" + data.d[start]["DanhSachVanBanMinhChung"][indexDoc]["ClientFileName"] + "</a>"
                            + "<br>";
                        indexDoc++;
                    }
                    contentString += "</div>";
                }
                var countHinh = Object.keys(data.d[start]["DanhSachHinhAnhHoatDong"]).length;
                if (countHinh > 0) {
                    contentString += "<div class=' row well m-w-none'>";
                    var indexHinh = 0;
                    while (countHinh > indexHinh) {
                        if (indexHinh < 3) {
                            contentString += "<div class='file-box'>";
                        }
                        else
                            contentString += "<div class='file-box' style='display:none'>";
                        contentString += "<div class='file'>"
										            + "<a class='group1' rel='" + data.d[start]["ThongTinHopTacGuid"] + "' href='" + linkHinh + data.d[start]["DanhSachHinhAnhHoatDong"][indexHinh]["ServerFileName"] + "'>"
											            + "<span class='corner'></span>"
                                                            + "<div class='image'>";
                        if (data.d[start]["DanhSachHinhAnhHoatDong"][indexHinh]["ServerFileName"] != "" && imageExists(linkHinhThum + data.d[start]["DanhSachHinhAnhHoatDong"][indexHinh]["ServerFileName"]))
                            contentString += "<img class='img-responsive' src='" + linkHinhThum + data.d[start]["DanhSachHinhAnhHoatDong"][indexHinh]["ServerFileName"] + "' alt='image'>"
                        else
                            contentString += "<img class='img-responsive' src='" + linknoimage + "' alt='image'>"
                        contentString += "</div>"
										            + "</a>"
									            + "</div>"
								            + "</div>";
                        indexHinh++;
                    }
                    contentString += "</div>";
                }
                contentString += "</div>"
                            + "</div>";
                start = start + 1;
            }
            myElementToAppendTo.append(contentString)
            //            // show hinh anh
            $('.group1').fancybox({
                groupAttr: 'data-rel',
                prevEffect: 'fade',
                nextEffect: 'fade',
                openEffect: 'elastic',
                closeEffect: 'fade',
                closeBtn: true,
                helpers: {
                    title: {
                        type: 'float'
                    }
                }
            });
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            console.log(xmlHttpRequest.responseText);
            console.log(textStatus);
            console.log(errorThrown);
        }
    });
}