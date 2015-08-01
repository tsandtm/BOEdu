<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DanhSachSinhVienMienMonControl.ascx.cs"
    Inherits="project.web.Page.MienGiamMon_21052015.FolderBaoCaoThongKe.DanhSachSinhVienMienMonControl" %>
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
            <div class="col-sm-4 p-b-5 p-w-5 pull-right text-right ">
                <div class="btn-group">
                    <asp:LinkButton ID="ButtonMore" runat="server" ToolTip="Tác vụ khác" CssClass="btn btn-more dropdown-toggle"
                        data-toggle="dropdown" aria-expanded="false">Tác vụ khác <span class="caret"></span></asp:LinkButton>
                    <ul class="dropdown-menu">
                        <li id="mm_importsinhvien" runat="server"><a href="<%=ResolveUrl("~/") %>Page/MienGiamMon_21052015/FolderImportSinhVien/PageImportSinhVienControlMienGiamMonHoc.aspx">
                            Import sinh viên</a></li>
                        <li id="mm_importbosungthongtin" runat="server"><a href="<%=ResolveUrl("~/") %>Page/MienGiamMon_21052015/FolderImportSinhVien/PageImportUpdateThongTinSinhVienControlMienGiamMonHoc.aspx">
                            Import bổ sung thông tin</a></li>
                    </ul>
                </div>
                <asp:LinkButton ID="LinkButtonKhoa" runat="server" ToolTip="Khóa dữ liệu" CssClass="btn btn-reset"><i class="fa fa-lock"></i>&nbsp;Khóa</asp:LinkButton>
                <asp:LinkButton ID="ButtonDelete" runat="server" ToolTip="Xóa" OnClientClick="return confirm('Bạn có thực sự muốn xóa?')"
                    CssClass="btn btn-delete"><i class="fa fa-trash-o"></i>&nbsp;Xóa</asp:LinkButton>
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
                                            Mã SV
                                        </th>
                                        <th>
                                            Ngày sinh
                                        </th>
                                        <th>
                                            Điện thoại
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
                                                    <div class="hideme">
                                                        <%# Container.ItemIndex + 1 + (PageNumber - 1) * PageSize%>
                                                    </div>
                                                    <div class="showme">
                                                        <asp:LinkButton ID="LinkButton1" CssClass="btn btn-primary btn-circle btn-outline"
                                                            ToolTip="Chỉnh sửa" runat="server" CommandName="EDIT" CommandArgument='<%# Eval("SinhVienGuid")%>'> <i class="fa fa-pencil"></i></asp:LinkButton>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="LabelThongTinSinhVien"></asp:Label>
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
                                                    <%# Eval("NgaySinh")%>
                                                </td>
                                                <td>
                                                    <%# Eval("DienThoai")%>
                                                </td>
                                                <td class="text-center ">
                                                    <asp:LinkButton ID="LinkButtonItem" CssClass="btn btn-primary btn-circle btn-outline"
                                                        runat="server" CommandName="SHOWMONMIENGIAM" ToolTip="Xem môn học miễn giảm"
                                                        CommandArgument='<%# Eval("SinhVienGuid")%>'><i class="fa fa-eye"></i> </asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButtonPrint" CssClass="btn btn-success btn-circle btn-outline"
                                                        runat="server" CommandName="SHOWPRINTPREVIEW" ToolTip="In chương trình đào tạo"
                                                        CommandArgument='<%# Eval("SinhVienID")%>'><i class="fa fa-print"></i> </asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <td colspan="9">
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
<script src="<%=ResolveUrl("~/") %>Resources/js/jquery-2.1.1.js" type="text/javascript"></script>
<script type="text/javascript">


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
