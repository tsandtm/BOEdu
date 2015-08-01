<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="PageThongTinChiTietDoanhNghiep.aspx.cs" Inherits="project.web.Page._10042014_HDHTDoanhNghiep.FolderPageThongTinDoanhNghiep.PageThongTinChiTietDoanhNghiep" %>

<%@ Register Src="../FolderDoanhNghiep/AddDoanhNghiepControl.ascx" TagName="AddDoanhNghiepControl"
    TagPrefix="uc1" %>
<%@ Register Src="ControlAddThongTinHocBong.ascx" TagName="ControlAddThongTinHocBong"
    TagPrefix="uc2" %>
<%@ Register Src="ControlThemHoTro.ascx" TagName="ControlThemHoTro" TagPrefix="uc3" %>
<%@ Register Src="ControlThemThucTap.ascx" TagName="ControlThemThucTap" TagPrefix="uc4" %>
<%@ Register Src="ControlThemThongTinTuyenDung.ascx" TagName="ControlThemThongTinTuyenDung"
    TagPrefix="uc5" %>
<%@ Register Src="ListThongTinHocBongControl.ascx" TagName="ListThongTinHocBongControl"
    TagPrefix="uc6" %>
<%@ Register Src="~/Page/10042014_HDHTDoanhNghiep/FolderPageThongTinDoanhNghiep/ControlThongTinHoTro.ascx"
    TagName="ControlThongTinHoTro" TagPrefix="uc7" %>
<%@ Register Src="~/Page/10042014_HDHTDoanhNghiep/FolderPageThongTinDoanhNghiep/ControlThongTinThucTap.ascx"
    TagName="ControlThongTinThucTap" TagPrefix="uc8" %>
<%@ Register Src="~/Page/10042014_HDHTDoanhNghiep/FolderPageThongTinDoanhNghiep/ControlThongTinTuyenDung.ascx"
    TagName="ControlThongTinTuyenDung" TagPrefix="uc9" %>
<%@ Register Src="~/Page/10042014_HDHTDoanhNghiep/FolderPageThongTinDoanhNghiep/ControlAddMouDoangNghiep.ascx"
    TagName="ControlAddMouDoangNghiep" TagPrefix="uc10" %>
<%@ Register Src="~/Page/10042014_HDHTDoanhNghiep/FolderPageThongTinDoanhNghiep/ControlListMouDoanhNghiep.ascx"
    TagName="ControlListMouDoanhNghiep" TagPrefix="uc11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    Hoạt động doanh nghiệp
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
    <li><a href="../FolderDoanhNghiep/PageQuanLyThongTinDoanhNghiep.aspx">Quản lý doanh
        nghiệp</a></li>
    <li class="active">Chi tiết doanh nghiệp</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <div class="panel-heading p-b-none">
        <ul class="nav nav-tabs">
            <li class="" id="licoban"><a data-toggle="tab" onclick="OnclickTab('CB')">Thông tin
                cơ bản</a></li>
            <li class="" id="lithuctap"><a data-toggle="tab" onclick="OnclickTab('TT')">Thực tập</a></li>
            <li class="" id="lituyendung"><a data-toggle="tab" onclick="OnclickTab('TD')">Tuyển
                dụng</a></li>
            <li class="" id="lihocbong"><a data-toggle="tab" onclick="OnclickTab('HB')">Học bổng</a></li>
            <li class="" id="lihotro"><a data-toggle="tab" onclick="OnclickTab('HT')">Tài trợ</a></li>
            <li class="" id="limou"><a data-toggle="tab" onclick="OnclickTab('MOU')">MOU</a></li>
        </ul>
    </div>
    <div class="ibox-content">
        <div class="tab-content">
            <div id="tabcoban" class="tab-pane">
                <uc1:AddDoanhNghiepControl runat="server" ID="AddDoanhNghiepControl1" />
            </div>
            <div id="tabhocbong" class="tab-pane">
                <asp:UpdatePanel ID="UpdatePanelHocBong" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <uc6:ListThongTinHocBongControl ID="ListThongTinHocBongControl1" runat="server" />
                        <uc2:ControlAddThongTinHocBong runat="server" ID="ControlAddThongTinHocBong1" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="ListThongTinHocBongControl1" />
                        <asp:PostBackTrigger ControlID="ControlAddThongTinHocBong1" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            <div id="tabhotro" class="tab-pane">
                <asp:UpdatePanel ID="UpdatePanelHoTro" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <uc7:ControlThongTinHoTro ID="ControlThongTinHoTro1" runat="server" />
                        <uc3:ControlThemHoTro ID="ControlThemHoTro1" runat="server" Visible="false" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="ControlThemHoTro1" />
                        <asp:PostBackTrigger ControlID="ControlThongTinHoTro1" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            <div id="tabthuctap" class="tab-pane">
                <asp:UpdatePanel ID="UpdatePanelThucTap" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <uc8:ControlThongTinThucTap ID="ControlThongTinThucTap1" runat="server" />
                        <uc4:ControlThemThucTap ID="ControlThemThucTap1" runat="server" Visible="false" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="ControlThemThucTap1" />
                        <asp:PostBackTrigger ControlID="ControlThongTinThucTap1" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            <div id="tabtuyendung" class="tab-pane">
                <asp:UpdatePanel ID="UpdatePanelTuyenDung" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <uc9:ControlThongTinTuyenDung ID="ControlThongTinTuyenDung1" runat="server" />
                        <uc5:ControlThemThongTinTuyenDung ID="ControlThemThongTinTuyenDung1" runat="server"
                            Visible="false" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="ControlThemThongTinTuyenDung1" />
                        <asp:PostBackTrigger ControlID="ControlThongTinTuyenDung1" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            <div id="tabmou" class="tab-pane">
                <asp:UpdatePanel ID="UpdatePanelMou" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <uc10:ControlAddMouDoangNghiep ID="ControlAddMouDoangNghiep1" runat="server" />
                        <uc11:ControlListMouDoanhNghiep ID="ControlListMouDoanhNghiep1" runat="server" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="ControlListMouDoanhNghiep1" />
                        <asp:PostBackTrigger ControlID="ControlAddMouDoangNghiep1" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
    <%--input mark--%>
    <script src="<%=ResolveUrl("~/") %>Resources/plugins/jasny/jasny-bootstrap.min.js"
        type="text/javascript"></script>
    <script type="text/javascript">

        function reloadWithQueryStringVars(queryStringVars) {
            var existingQueryVars = location.search ? location.search.substring(1).split("&") : [],
        currentUrl = location.search ? location.href.replace(location.search, "") : location.href,
        newQueryVars = {},
        newUrl = currentUrl + "?";
            //            if (existingQueryVars.length > 0) {
            //                for (var i = 0; i < existingQueryVars.length; i++) {
            //                    var pair = existingQueryVars[i].split("=");
            //                    newQueryVars[pair[0]] = pair[1];
            //                }
            //            }
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
            } else {
                window.location.href = location.href;
            }
        }

        function OnclickTab(tabindex) {

            var guidDoanhNghiep = GetParameterValues("peihgnhnaoddiug");
            reloadWithQueryStringVars({ "peihgnhnaoddiug": guidDoanhNghiep, "TabIndex": tabindex });
        }

        $(document).ready(function () {
            $('#data_doanhnghiep_thanhlap .input-group.date').datepicker({
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                calendarWeeks: true,
                autoclose: true, format: "dd/mm/yyyy"
            });
            $('#data_tungay_thongtinhocbong .input-group.date').datepicker({
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                calendarWeeks: true,
                autoclose: true, format: "dd/mm/yyyy"
            });
            $('#data_ngayky_thongtinhocbong .input-group.date').datepicker({
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                calendarWeeks: true,
                autoclose: true, format: "dd/mm/yyyy"
            });
            $('#data_denngay_thongtinhocbong .input-group.date').datepicker({
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                calendarWeeks: true,
                autoclose: true, format: "dd/mm/yyyy"
            });


            $('#data_tungay_mou .input-group.date').datepicker({
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                calendarWeeks: true,
                autoclose: true, format: "dd/mm/yyyy"
            });
            $('#data_ngayky_mou .input-group.date').datepicker({
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                calendarWeeks: true,
                autoclose: true, format: "dd/mm/yyyy"
            });
            $('#data_denngay_mou .input-group.date').datepicker({
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                calendarWeeks: true,
                autoclose: true, format: "dd/mm/yyyy"
            });

            // chuongtv timepicker
            $('#data_hotro_ngayky .input-group.date').datepicker({
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                calendarWeeks: true,
                autoclose: true,
                format: "dd/mm/yyyy"

            });
            $('#data_ngaykyfile_hotro .input-group.date').datepicker({
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                calendarWeeks: true,
                autoclose: true,
                format: "dd/mm/yyyy"
            });
            $('#data_thuctap_TextBoxTuNgay .input-group.date').datepicker({
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                calendarWeeks: true,
                autoclose: true,
                format: "dd/mm/yyyy"
            });
            $('#data_thuctap_TextBoxDenNgay .input-group.date').datepicker({
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                calendarWeeks: true,
                autoclose: true,
                format: "dd/mm/yyyy"
            });
            $('#data_thuctap_ngaykyfile .input-group.date').datepicker({
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                calendarWeeks: true,
                autoclose: true,
                format: "dd/mm/yyyy"
            });
            $('#data_tuyendung_TextBoxTuNgay .input-group.date').datepicker({
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                calendarWeeks: true,
                autoclose: true,
                format: "dd/mm/yyyy"
            });
            $('#data_tuyendung_TextBoxDenNgay .input-group.date').datepicker({
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                calendarWeeks: true,
                autoclose: true,
                format: "dd/mm/yyyy"
            });
            $('#data_tuyendung_ngaykyfile .input-group.date').datepicker({
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                calendarWeeks: true,
                autoclose: true,
                format: "dd/mm/yyyy"
            });
            $('#data_ngaythanhlap_thongtindoanhnghiep .input-group.date').datepicker({
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                calendarWeeks: true,
                autoclose: true, format: "dd/mm/yyyy"
            });

            setsummernote();
            SearchDoanhNghiepNameGoiY();
            //            $('#TextBoxDoanhNghiepNameVN').keydown(function () {
            //                var TextBoxDoanhNghiepNameVN1 = document.getElementById('TextBoxDoanhNghiepNameVN');
            //                if (TextBoxDoanhNghiepNameVN1.value.trim().length > 3) {
            //                    $.ajax({
            //                        url: "GetGoiYDoanhNghiep.asmx/GetGoiYDoanhNghiep2",
            //                        data: JSON.stringify({ 'Keysearch': $("#TextBoxDoanhNghiepNameVN").val() }),
            //                        dataType: "json",
            //                        type: "POST",
            //                        contentType: "application/json",
            //                        success: function (data) {
            //                            var jsonData = data.d;
            //                            var toancuc = JSON.parse(jsonData);
            //                            var result;
            //                            var start = 0;
            //                            if (!data || data.length === 0) {
            //                                result = [{
            //                                    label: 'không có gì'
            //                                }];
            //                            } else {
            //                                result = toancuc;
            //                                $('#LabelGoiYTen').text("");
            //                                $('#LabelGoiYTen').append("<strong>Các công ty đã có:</strong><br/>");
            //                                $('#LabelGoiYTen').append("-" + result[0]["DoanhNghiepNameVN"] + "<br/>");
            //                                $('#LabelGoiYTen').append("-"+result[1]["DoanhNghiepNameVN"] + "<br/>");
            //                                $('#LabelGoiYTen').append("-"+result[2]["DoanhNghiepNameVN"] + "<br/>");
            //                            }
            //                            //alert(result[0]["DoanhNghiepNameVN"]);
            //                        },
            //                        error: function (XMLHttpRequest, textStatus, errorThrown) {
            //                            alert(textStatus + "_" + errorThrown + "_" + XMLHttpRequest);
            //                        }
            //                    });
            //                }
            //                else {
            //                    $('#LabelGoiYTen').text("");
            //                }

            //            });

            var guidDoanhNghiep1 = GetParameterValues("peihgnhnaoddiug");
            var tabbindex1 = GetParameterValues("TabIndex");
            if (guidDoanhNghiep1 == 'undefined') {
                document.getElementById("licoban").setAttribute("Style", "display:none");
                document.getElementById("lihocbong").setAttribute("Style", "display:none");
                document.getElementById("lihotro").setAttribute("Style", "display:none");
                document.getElementById("lithuctap").setAttribute("Style", "display:none");
                document.getElementById("lituyendung").setAttribute("Style", "display:none");
                document.getElementById("limou").setAttribute("Style", "display:none");
            }
            else
                if (guidDoanhNghiep1 == '00000000-0000-0000-0000-000000000000') {
                    document.getElementById("lihocbong").setAttribute("Style", "display:none");
                    document.getElementById("lihotro").setAttribute("Style", "display:none");
                    document.getElementById("lithuctap").setAttribute("Style", "display:none");
                    document.getElementById("lituyendung").setAttribute("Style", "display:none");
                    document.getElementById("limou").setAttribute("Style", "display:none");
                    document.getElementById("tabcoban").setAttribute("class", "active");
                    document.getElementById("licoban").setAttribute("class", "active");

                }
                else {
                    if (typeof tabbindex1 === 'undefined' || tabbindex1 == "CB") {
                        document.getElementById("tabcoban").setAttribute("class", "active");
                        document.getElementById("licoban").setAttribute("class", "active");

                    }

                    if (tabbindex1 == "HB") {
                        document.getElementById("tabhocbong").setAttribute("class", "active");
                        document.getElementById("lihocbong").setAttribute("class", "active");
                    }
                    if (tabbindex1 == "HT") {
                        document.getElementById("tabhotro").setAttribute("class", "active");
                        document.getElementById("lihotro").setAttribute("class", "active");
                    }
                    if (tabbindex1 == "TT") {
                        document.getElementById("tabthuctap").setAttribute("class", "active");
                        document.getElementById("lithuctap").setAttribute("class", "active");
                        LoadDataCatologieThucTap();
                    }
                    if (tabbindex1 == "TD") {
                        document.getElementById("tabtuyendung").setAttribute("class", "active");
                        document.getElementById("lituyendung").setAttribute("class", "active");
                        LoadDataCatologie();
                    }
                    if (tabbindex1 == "MOU") {
                        document.getElementById("tabmou").setAttribute("class", "active");
                        document.getElementById("limou").setAttribute("class", "active");
                    }
                }

        });
        function setsummernote() {
            $('#summernote_doanhnghiep_gioithieu').summernote({
                toolbar: [
                //['style', ['style']], // no style button
                    ['style', ['bold', 'italic', 'underline', 'clear']],
                    ['fontsize', ['fontsize']],
                    ['color', ['color']],
                    ['para', ['ul', 'ol', 'paragraph']],
                    ['height', ['height']],
                //['insert', ['picture', 'link']], // no insert buttons
                //['table', ['table']], // no table button
                //['help', ['help']] //no help button
                  ],
                //                onkeyup: function (e) {
                //                    //$("#summernote_doanhnghiep_gioithieu_dulieu").val($("#summernote_doanhnghiep_gioithieu").code());
                //                    document.getElementById('summernote_doanhnghiep_gioithieu_dulieu').value = $("#summernote_doanhnghiep_gioithieu").code();
                //                    //alert($('#summernote_doanhnghiep_gioithieu_dulieu').val());
                //                },
                height: 100,
                focus: true
            });

            $('#summernote_doanhnghiep_ghichu').summernote({
                toolbar: [
                //['style', ['style']], // no style button
                    ['style', ['bold', 'italic', 'underline', 'clear']],
                    ['fontsize', ['fontsize']],
                    ['color', ['color']],
                    ['para', ['ul', 'ol', 'paragraph']],
                    ['height', ['height']],
                //['insert', ['picture', 'link']], // no insert buttons
                //['table', ['table']], // no table button
                //['help', ['help']] //no help button
                  ],
                //                onkeyup: function (e) {
                //                    //$("#summernote_doanhnghiep_ghichu_dulieu").val($("#summernote_doanhnghiep_ghichu").code());
                //                    document.getElementById('summernote_doanhnghiep_ghichu_dulieu').value = $("#summernote_doanhnghiep_ghichu").code();
                //                },
                height: 100,
                focus: true
            });

            $('#summernote_hocbong_dieukien').summernote({
                toolbar: [
                    ['style', ['bold', 'italic', 'underline', 'clear']],
                    ['fontsize', ['fontsize']],
                    ['color', ['color']],
                    ['para', ['ul', 'ol', 'paragraph']],
                    ['height', ['height']],
                  ],
                height: 100
            });

            $('#summernote_mou_thongtinkyket').summernote({
                toolbar: [
                    ['style', ['bold', 'italic', 'underline', 'clear']],
                    ['fontsize', ['fontsize']],
                    ['color', ['color']],
                    ['para', ['ul', 'ol', 'paragraph']],
                    ['height', ['height']],
                  ],
                height: 100
            });

            $('#summernote_hotro_noidung').summernote({
                toolbar: [
                    ['style', ['bold', 'italic', 'underline', 'clear']],
                    ['fontsize', ['fontsize']],
                    ['color', ['color']],
                    ['para', ['ul', 'ol', 'paragraph']],
                    ['height', ['height']],
                  ],
                height: 100
            });
            $('#summernote_thuctap_mota').summernote({
                toolbar: [
                    ['style', ['bold', 'italic', 'underline', 'clear']],
                    ['fontsize', ['fontsize']],
                    ['color', ['color']],
                    ['para', ['ul', 'ol', 'paragraph']],
                    ['height', ['height']],
                  ],
                height: 100
            });

            $('#summernote_tuyendung_mota').summernote({
                toolbar: [
                    ['style', ['bold', 'italic', 'underline', 'clear']],
                    ['fontsize', ['fontsize']],
                    ['color', ['color']],
                    ['para', ['ul', 'ol', 'paragraph']],
                    ['height', ['height']],
                  ],
                height: 100
            });
        }
        // tab thong tin tuyen dung
        function LoadDataCatologie() {
            $('#selectBox').append($('<option></option>').val('0').html('Đang load dữ liệu...')
                );
            $.ajax({
                type: "POST",
                url: "WCatologieService.asmx/GetCatologieByKindGuid",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: '{"loaiGuid":"F2D65250-82D0-44F7-9FA5-712C40176F3B"}',
                success: function (data) {
                    $('#selectBox').empty();
                    var start = 0;
                    var count = Object.keys(data.d).length;
                    while (count > start) {
                        $('#selectBox')
                     .append($("<option></option>")
                     .val(data.d[start]["CatologyGuid"])
                     .html(data.d[start]["CatologyName"]));
                        start = start + 1;
                    }
                },
                error: function (xmlHttpRequest, textStatus, errorThrown) {
                    console.log(xmlHttpRequest.responseText);
                    console.log(textStatus);
                    console.log(errorThrown);
                }
            });

        }

        //tab thong tin thuc tap
        function LoadDataCatologieThucTap() {
            $('#selectBoxtt').append($('<option></option>').val('0').html('Đang load dữ liệu...')
                );
            $.ajax({
                type: "POST",
                url: "WCatologieService.asmx/GetCatologieByKindGuid",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: '{"loaiGuid":"235EC154-4370-48B3-BDC6-7BC09FF5F346"}',
                success: function (data) {
                    $('#selectBoxtt').empty();
                    var start = 0;
                    var count = Object.keys(data.d).length;
                    while (count > start) {
                        $('#selectBoxtt')
                     .append($("<option></option>")
                     .val(data.d[start]["CatologyGuid"])
                     .html(data.d[start]["CatologyName"]));
                        start = start + 1;
                    }
                },
                error: function (xmlHttpRequest, textStatus, errorThrown) {
                    console.log(xmlHttpRequest.responseText);
                    console.log(textStatus);
                    console.log(errorThrown);
                }
            });

        }
        function SearchDoanhNghiepNameGoiY() {
            $.widget('custom.namdeptraiautocomplete', $.ui.autocomplete, {
                _create: function () {
                    this._super();
                    this.widget().menu("option", "items", "> :not(.ui-widget-header)");
                },
                _renderMenu: function (ul, items) {
                    var self = this,
                         thead;
                    if (this.options.showHeader) {
                        table = $('<div class="ui-widget-header" style="width:100%"></div>');
                        $.each(this.options.columns, function (index, item) {
                            table.append('<span style="padding:0 4px;float:left;width:' + item.width + ';">' + item.name + '</span>');
                        });
                        table.append('<div style="clear: both;"></div>');
                        ul.append(table);
                    }
                    $.each(items, function (index, item) {
                        self._renderItem(ul, item);
                    });
                },
                _renderItem: function (ul, item) {
                    var t = '',
                result = '';
                    $.each(this.options.columns, function (index, column) {
                        t += '<span style="padding:0 4px;float:left;width:' + column.width + ';">' + item[column.valueField ? column.valueField : index] + '</span>'
                    });
                    result = $('<li></li>')
                .data('ui-autocomplete-item', item)
                .append('<a class="mcacAnchor">' + t + '<div style="clear: both;"></div></a>')
                .appendTo(ul);
                    return result;
                }
            });

            $("#TextBoxDoanhNghiepNameVN").namdeptraiautocomplete({
                showHeader: true,

                columns: [{
                    name: 'Doanh nghiệp đã có',
                    width: '220px',
                    valueField: 'DoanhNghiepNameVN'
                }],

                select: function (event, ui) {
                    //this.value = (ui.item ? ui.item.FullName : ' ');

                    return false;
                },

                minLength: 4,
                source: function (request, response) {
                    $.ajax({
                        url: "GetGoiYDoanhNghiep.asmx/GetGoiYDoanhNghiep2",
                        data: JSON.stringify({ 'Keysearch': $("#TextBoxDoanhNghiepNameVN").val() }),
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json",
                        success: function (data) {
                            var jsonData = data.d;
                            var toancuc = JSON.parse(jsonData);
                            var result;
                            if (!data || data.length === 0) {
                                result = [{
                                    label: 'không có gì'
                                }];
                            } else {
                                result = toancuc;
                            }
                            response(result);
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(textStatus + "_" + errorThrown + "_" + XMLHttpRequest);
                        }
                    });
                }
            });
        }
    </script>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(setsummernote);
    </script>
</asp:Content>
