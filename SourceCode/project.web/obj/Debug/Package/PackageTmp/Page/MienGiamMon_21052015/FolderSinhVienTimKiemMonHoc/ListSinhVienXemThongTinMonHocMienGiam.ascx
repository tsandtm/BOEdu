<%--   
Author:					Nam Dep Trai
Created:				2015-5-23
Last Modified:			2015-5-23
--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListSinhVienXemThongTinMonHocMienGiam.ascx.cs"
    Inherits="project.web.Controls.ListSinhVienXemThongTinMonHocMienGiam" %>
<script language="javascript" type="text/javascript">
    function OpenPopupCenter(pageURL, title, w, h) {
        var left = (screen.width - w) / 2;
        var top = (screen.height - h) / 4;  // for 25% - devide by 4  |  for 33% - devide by 3
        var targetWin = window.open(pageURL, title, 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
    } 
</script>
<style>
    .ui-widget-header
    {
        background: #cedc98;
        border: 1px solid #DDDDDD;
        color: #333333;
        font-weight: bold;
    }
</style>
<asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="UpdatePanelShowSinhVien_on">
    <ProgressTemplate>
        <span style="position: fixed; z-index: 9999; top: 48%; left: 48%;">
            <img src="<%=ResolveUrl("~/") %>Resources/img/waiting.gif" alt="Vui lòng đợi..."
                height="80px" width="80px" /></span>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanelShowSinhVien_on" runat="server" UpdateMode="Conditional"
    ChildrenAsTriggers="false">
    <ContentTemplate>
        <div class="row">
            <asp:Panel runat="server" DefaultButton="ButtonSearch" ID="pnlsearch">
                <div class="col-sm-8 p-l-none p-b-5">
                    <div>
                        <div class="col-sm-4 p-w-5 p-b-5">
                            <asp:DropDownList ID="DropDownListNienKhoa" CssClass="form-control w-full" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-4 p-w-5 p-b-5">
                            <asp:DropDownList ID="DropDownListKhoa" AutoPostBack="true" CssClass="form-control w-full"
                                runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-4 p-w-5 p-b-5">
                            <asp:DropDownList ID="DropDownListChuyenNganh" AutoPostBack="true" CssClass="form-control w-full"
                                runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div>
                        <div class="col-sm-4 p-w-5 p-b-5">
                            <asp:DropDownList ID="DropDownListHuongChuyenSau" CssClass="form-control w-full"
                                runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-4 p-w-5 p-b-5">
                            <asp:DropDownList ID="DropDownListDaCapNhatMienGiam" CssClass="form-control w-full"
                                runat="server">
                                <asp:ListItem Value="0" Text="--Điều kiện--"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Đã cập nhật miễn giảm"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Chưa cập nhật miễn giảm"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-4 p-w-5 p-b-5">
                            <div class="input-group">
                                <asp:TextBox ID="TextBoxValueSearch" runat="server" CssClass="form-control w-full showtooltip"
                                    placeholder="Thông tin tìm kiếm ..."></asp:TextBox>
                                <asp:HiddenField ID="HiddenFieldCurrentUserID" runat="server" />
                                <ul id="elementToHide">
                                    <li><b><u>Quy định khóa</u></b></li>
                                    <li>- <strong class="text-danger">PHONE</strong>: số điện thoại</li>
                                    <li>- <strong class="text-danger">ADD</strong>: địa chỉ</li>
                                    <li>- <strong class="text-danger">NAME</strong>: tên sinh viên</li>
                                    <li><b><u>Sử dụng</u></b></li>
                                    <li class="text-danger">[từ khóa]:[cụm từ cần tìm]</li>
                                    <li><i><u>Ví dụ:</u> PHONE:093</i></li>
                                    <li class="text-success">* Mặc định không sử dụng từ khóa thì tìm kiếm theo tên</li>
                                </ul>
                                <span class="input-group-btn">
                                    <asp:LinkButton ID="ButtonSearch" ToolTip="Tìm kiếm" runat="server" Text="" CssClass="btn btn-primary"><i class="fa fa-search"></i>
                                    </asp:LinkButton>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <div class="col-sm-4 p-b-5 p-w-5 pull-right text-right">
               
                <% if (CheckQuyenEdit())
                   { %>
                <asp:Panel ID="pnlGroupTacVuDaoTao" runat="server">
                    <div class="btn-group">
                        <asp:LinkButton ID="ButtonMore" runat="server" ToolTip="Tác vụ khác" CssClass="btn btn-more dropdown-toggle"
                            data-toggle="dropdown" aria-expanded="false">Tác vụ khác <span class="caret"></span></asp:LinkButton>
                        <ul class="dropdown-menu">
                            <li id="Li1" runat="server"><a data-toggle="modal" data-target="#myModalabcxyuz"
                                data-backdrop="static" onclick="getListSinhVienMienGiamDuThu()" href="#">Xuất PDF</a></li>

                            <li id="mm_importsinhvien" runat="server"><a href="<%=ResolveUrl("~/") %>Page/MienGiamMon_21052015/FolderImportSinhVien/PageImportSinhVienControlMienGiamMonHoc.aspx">
                                Import sinh viên</a></li>
                            <li id="mm_importbosungthongtin" runat="server"><a href="<%=ResolveUrl("~/") %>Page/MienGiamMon_21052015/FolderImportSinhVien/PageImportUpdateThongTinSinhVienControlMienGiamMonHoc.aspx">
                                Import bổ sung thông tin</a></li>
                        </ul>
                    </div>
                    <asp:LinkButton ID="LinkButtonKhoa" runat="server" ToolTip="Khóa dữ liệu" CssClass="btn btn-reset"><i class="fa fa-lock"></i>&nbsp;Khóa</asp:LinkButton>
                    <%--<button type="button" class="btn btn-reset">
                    PDF
                </button>--%>
                    <div class="modal inmodal fade" id="myModalabcxyuz" data-backdrop="static" tabindex="-1"
                        role="dialog" aria-hidden="true">
                        <div class="modal-dialog modal-lg">
                            <div class="modal-content">
                                <div class="modal-body">
                                    <%--<div class="progress progress-striped active">
                                    <div aria-valuemax="100" aria-valuemin="0" aria-valuenow="1"
                                        role="progressbar" class="progress-bar progress-bar-danger" id="divprogressbarpdfmiengiam">
                                    </div>
                                </div>--%>
                                    <div id="divprogressbar">
                                    </div>
                                    <br />
                                    Đã hoàn thành: <span id="phantramhoanthanhpdf"></span>/ <span id="tongsoluongsinhvienmiengiampdf">
                                    </span>&nbsp sinh viên.
                                    <br />
                                    Những sinh viên bị lỗi trong quá trình convert:
                                    <div id="divdanhsachsinhvienloitrongquatrinhconvert">
                                    </div>
                                </div>
                                <div class="modal-footer" id="divshowkhihoanthanhconvertpdf">
                                    <a href="" class="btn btn-link btn-cancel btn-sm" runat="server" id="linkdowwn">Download
                                        File</a>
                                    <button type="button" class="btn btn-white" data-dismiss="modal">
                                        Đóng</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <asp:LinkButton ID="ButtonDelete" runat="server" ToolTip="Xóa" OnClientClick="return confirm('Bạn có thực sự muốn xóa?')"
                        CssClass="btn btn-delete"><i class="fa fa-trash-o"></i>&nbsp;Xóa</asp:LinkButton>
                </asp:Panel>
                <%} %>

            </div>
        </div>
        <div class="row">
            <div class="col-sm-12 p-b-5 p-w-5">
                <div class="ibox float-e-margins">
                    <div class="ibox-content">
                        <div class="table-responsive">
                            <table class="table table-stripped">
                                <thead>
                                    <tr>
                                        <th class="text-center">
                                            <input id="CheckBoxAll" onclick="javascript:SelectAllCheckboxes(this,'RepeaterSinhVien');"
                                                runat="server" type="checkbox" />
                                        </th>
                                        <th class="text-center">
                                            #
                                        </th>
                                        <th>
                                            Sinh viên
                                        </th>
                                        <th>
                                        </th>
                                        <th>
                                            SBD
                                        </th>
                                        <th>
                                            Mã SV (nếu có)
                                        </th>
                                        <th>
                                            Lớp
                                        </th>
                                        <th>
                                            Ngày sinh
                                        </th>
                                        <th>
                                            Điện thoại
                                        </th>
                                        <th class="text-right">
                                           Tổng TC miễn
                                        </th>
                                        <th class="text-center">
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="RepeaterSinhVien" runat="server">
                                        <ItemTemplate>
                                            <tr class="showhim" data="<%# Eval("SinhVienGuid")%>">
                                                <td class="text-center ">
                                                    <asp:CheckBox ID="CheckBoxSelect" runat="server" />
                                                </td>
                                                <td class="text-center w-50">
                                                    <asp:Literal ID="LiteralSinhVienGuid" runat="server" Text='<%# Eval("SinhVienGuid")%>'
                                                        Visible="false"></asp:Literal>
                                                    <asp:Literal ID="LiteralSinhVienName" runat="server" Text='<%# Eval("SinhVienName")%>'
                                                        Visible="false"></asp:Literal>
                                                    <asp:Literal ID="LiteralSBD" runat="server" Text='<%# Eval("SBD")%>' Visible="false"></asp:Literal>
                                                    <asp:Literal ID="LiteralTrangThai" runat="server" Text='<%# Eval("TrangThai")%>'
                                                        Visible="false"></asp:Literal>
                                                    <% if (CheckQuyenEdit())
                                                       { %>
                                                    <div class="hideme">
                                                        <%# Container.ItemIndex + 1 + (PageNumber - 1) * PageSize%>
                                                    </div>
                                                    <div class="showme">
                                                        <asp:LinkButton ID="LinkButton1" CssClass="btn btn-primary btn-circle btn-outline"
                                                            ToolTip="Chỉnh sửa" runat="server" CommandName="EDIT" CommandArgument='<%# Eval("SinhVienGuid")%>'> <i class="fa fa-pencil"></i></asp:LinkButton>
                                                    </div>
                                                    <%}
                                                       else
                                                       { %>
                                                    <%# Container.ItemIndex + 1 + (PageNumber - 1) * PageSize%>
                                                    <%} %>
                                                </td>
                                                <td>
                                                    <%# Eval("SinhVienName")%>
                                                </td>
                                                <td class="text-center w-50">
                                                    <%# Eval("TrangThai").ToString().Trim() == "false" ? "<span><i class='fa fa-unlock'></i></span>" : "<i class='fa fa-lock'></i>" %>
                                                </td>
                                                <td>
                                                    <%# Eval("SBD")%>
                                                </td>
                                                <td>
                                                    <%# Eval("SinhVienID")%>
                                                </td>
                                                <td>
                                                    <%# Eval("Lop")%>
                                                </td>
                                                <td>
                                                    <%# ConvertDateTiemFormat(Eval("NgaySinh"))%>
                                                </td>
                                                <td>
                                                    <%# Eval("DienThoai")%>
                                                </td>
                                                <td class="text-right">
                                                    <%# Eval("TongTCMienGiam")%>
                                                </td>
                                                <td class="text-right">
                                                    <%# Eval("TrangThai").ToString().Trim() == "false" ? "<a class='btn btn-warning btn-circle btn-outline'  target='_blank' title='Đăng ký miễn giảm' href='" + ResolveUrl("~/") + "Page/MienGiamMon_21052015/FolderXetMienGiamHocPhan/PageXetMienTruHocPhan.aspx?SBD_MIENGIAM=" + Eval("SBD") + "'><i class='fa fa-external-link'></i></a>" : ""%>
                                                    <asp:LinkButton ID="LinkButtonItem" CssClass="btn btn-primary btn-circle btn-outline"
                                                        runat="server" CommandName="SHOWMONMIENGIAM" ToolTip="Xem môn học miễn giảm"
                                                        CommandArgument='<%# Eval("SinhVienGuid")%>'><i class="fa fa-eye"></i> </asp:LinkButton>
                                                    <a href="javascript:void(0);" class="btn btn-success btn-circle btn-outline" onclick="OpenPopupCenter('<%#ResolveUrl("~/")+"Page/MienGiamMon_21052015/FolderBaoCaoThongKe/PrintPreview.aspx?SinhVienID="+Eval("SinhVienID") %>', 'In bảng chương trình đào tạo bắt buộc học', 1000, 700);"
                                                        title="In bảng chương trình đào tạo bắt buộc học"><i class="fa fa-print"></i>
                                                    </a>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <td colspan="10">
                                            <div class="pull-left" id="block_page">
                                                <MyC:mojoCutePager ID="mojoCutePager1" runat="server" CssClass="" />
                                            </div>
                                            <div class=" pull-right">
                                                <asp:DropDownList ID="DropDownListPageNumber" runat="server" AutoPostBack="true"
                                                    CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                </tfoot>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="DropDownListKhoa" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="DropDownListChuyenNganh" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ButtonDelete" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="ButtonSearch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="LinkButtonKhoa" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="DropDownListPageNumber" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="mojoCutePager1" EventName="Command" />
    </Triggers>
</asp:UpdatePanel>
<div style="display: none;">
    <ul id="datatest">
    </ul>
    <input name="TextBoxSo1" type="text" value="yes" id="TextBoxSo1" />
</div>
<script type="text/javascript">
    var myVar = null;
    var vala = 0;
    //divprogressbar
    function getListSinhVienMienGiamDuThu() {
        $("#divshowkhihoanthanhconvertpdf").css("display", "none");
        vala = 0;

        var paranienkhoa = $('#<%=DropDownListNienKhoa.ClientID %> option:selected').val();
        var parakhoaguid = $('#<%=DropDownListKhoa.ClientID %> option:selected').val();
        var parachuyennganh = $('#<%=DropDownListChuyenNganh.ClientID %> option:selected').val();

        var parachuyensau = $('#<%=DropDownListHuongChuyenSau.ClientID %> option:selected').val();
        var paradacapnhat = $('#<%=DropDownListDaCapNhatMienGiam.ClientID %> option:selected').val();
        var TextBoxValueSearch = document.getElementById('<%= TextBoxValueSearch.ClientID %>');
        var parakey = TextBoxValueSearch.value;

        //        $("divdanhsachsinhvienloitrongquatrinhconvert").text() = "";
        //alert(parakey + "_" + paranienkhoa + "_" + parakhoaguid + "_" + parachuyennganh + "_" + parachuyensau + "_" + paradacapnhat);
        var result;
        $.ajax({
            url: 'GetListSinhVienMienGiamMonHoc.asmx/GetListSinhVList',
            data: JSON.stringify({ 'Keysearch': parakey, 'NienKhoaGuid': paranienkhoa, 'KhoaGuid': parakhoaguid, 'ChuyenNganhGuid': parachuyennganh, 'HuongChuyenSauGuid': parachuyensau, 'daCapNhatMienGiam': paradacapnhat }),
            dataType: 'json',
            type: 'POST',
            contentType: 'application/json',
            success: function (data) {
                var jsonData = data.d;
                var toancuc = JSON.parse(jsonData);
                if (!data || data.length === 0) {
                    result = [{
                        label: 'không có gì'
                    }];
                } else {
                    result = toancuc;
                }
                var start = 0;
                var biendem5 = 0;
                var count = Object.keys(result).length;
                $("#divprogressbar").progressbar({
                    value: 0,
                    max: count
                });
                $("#phantramhoanthanhpdf").text(start);
                $("#tongsoluongsinhvienmiengiampdf").text(count);

                while (count > start) {
                    $("#datatest").append("<li>" + result[start]['SinhVienID'] + "_</li>")
                    start = start + 1;
                }
                myVar = setInterval(function () { myTimer() }, 2000);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                //alert(errorThrown);
            }
        });
    }


    var resultconvert;

    function convertToPDfMienGiamMonHoc(listmasinhvien) {
        var valHiddenFieldCurrentUserID = document.getElementById('<%= HiddenFieldCurrentUserID.ClientID %>').value;
        document.getElementById("TextBoxSo1").value = "no";
        $.ajax({
            url: 'GetListSinhVienMienGiamMonHoc.asmx/ConvertSinhVien',
            data: JSON.stringify({ 'Keysearch': listmasinhvien, 'CurrentUser': valHiddenFieldCurrentUserID }),
            dataType: 'json',
            type: 'POST',
            contentType: 'application/json',
            success: function (data) {
                var jsonData = data.d;
                var toancuc = JSON.parse(jsonData);
                flagresultconvert = 1;
                if (!data || data.length === 0) {
                    resultconvert = [{
                        label: 'không có gì'
                    }];
                } else {
                    resultconvert = toancuc;
                }
                $('#datatest li').first().remove();

                document.getElementById("TextBoxSo1").value = "yes";

                vala = vala + 1;
                $("#phantramhoanthanhpdf").text(vala);
                $("#divprogressbar").progressbar({
                    value: vala
                });

                var start = 0;
                var count = Object.keys(result).length;
                while (count > start) {
                    sinhvienbisaimiengiamxuatpdf += resultconvert[start]['SinhVienID'] + ", ";
                    start = start + 1;
                }
                $("#divdanhsachsinhvienloitrongquatrinhconvert").append(sinhvienbisaimiengiamxuatpdf);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                //alert(errorThrown);
            }
        });
    }

    function loadSelect() {
        $('.showhim').click(function () {
            var bb = $(this).attr("data");
            $.cookie('aaa', bb);

            var a = $('tr');
            $(a).removeClass('current');

            if (bb) {
                var a = $('tr[data="' + bb + '"]');
                $(a).addClass('current');
            }
        });

        var thisLink = $.cookie('aaa');
        if (thisLink) {
            var a = $('tr[data="' + thisLink + '"]');
            $(a).addClass('current');
        }
    }
    $(document).ready(loadSelect);
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(loadSelect);
</script>
<script>
    function myTimer() {
        var t1 = document.getElementById("TextBoxSo1");
        if (t1.value == "yes") {
            if ($('#datatest li').length >= 1) {
                convertToPDfMienGiamMonHoc($("#datatest li").first().text());
            }
            else {
                $("#divshowkhihoanthanhconvertpdf").css("display", "block");
                clearInterval(myVar);
            }
        }
    }
</script>
