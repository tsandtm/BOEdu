<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListDoanhNghiepEmptyControl.ascx.cs"
    Inherits="project.web.Page.FolderBaoCaoThongKe.ListDoanhNghiepEmptyControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:UpdatePanel ID="UpdatePanelShowDoanhNghiep" runat="server" UpdateMode="Conditional"
    ChildrenAsTriggers="false">
    <ContentTemplate>
        <asp:Panel ID="PanelFilter" runat="server" DefaultButton="ButtonSearch">
            <div class="row">
                <div class="col-sm-5 m-b-5 p-w-5">
                    <div class="input-group">
                        <asp:TextBox ID="TextBoxValueSearch" runat="server" CssClass="form-control w-full showtooltip"
                            placeholder="Thông tin tìm kiếm ..."></asp:TextBox>
                        <ul id="elementToHide">
                            <li><b><u>Quy định khóa</u></b></li>
                            <li>- <strong class="text-danger">EMAIL</strong>: địa chỉ email</li>
                            <li>- <strong class="text-danger">PHONE</strong>: số điện thoại</li>
                            <li>- <strong class="text-danger">ADD</strong>: địa chỉ</li>
                            <li><b><u>Sử dụng</u></b></li>
                            <li class="text-danger">[từ khóa]:[cụm từ cần tìm]</li>
                            <li><i><u>Ví dụ:</u> PHONE:093</i></li>
                            <li class="text-success">* Mặc định không sử dụng từ khóa thì tìm kiếm theo tên</li>
                        </ul>
                        <span class="input-group-btn">
                            <asp:LinkButton ID="ButtonSearch" runat="server" Text="" CssClass="btn btn-primary"><i class="fa fa-search"></i>
                            </asp:LinkButton>
                        </span>
                    </div>
                </div>
                <div class="col-sm-2 m-b-5 p-w-5 pull-right">
                    <p class="pull-right">
                       <%-- <asp:LinkButton ID="LinkButtonExcel" runat="server" Text="" CssClass="btn btn-primary btn-outline"><i class="fa fa-file-excel-o"></i>
                        </asp:LinkButton>--%>
                        <asp:LinkButton ID="LinkButtonExcel" runat="server" class="btn-excel"><i class="fa fa-file-excel-o"></i>&nbsp;Xuất excel
                        </asp:LinkButton>
                    </p>
                </div>
            </div>
        </asp:Panel>
        <div class="row">
            <div class="col-sm-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-content">
                        <div class="table-responsive">
                            <table class="table table-striped">
                                <thead>
                                    <tr>
                                        <th class="text-center">
                                            STT
                                        </th>
                                        <th>
                                            Doanh nghiệp
                                        </th>
                                        <th>
                                            Tên tiếng Anh
                                        </th>
                                        <th>
                                            Viết tắt
                                        </th>
                                        <th>
                                            Ngày thành lập
                                        </th>
                                        <th>
                                            Mã số thuế
                                        </th>
                                        <th>
                                            Địa chỉ
                                        </th>
                                        <th>
                                            Email
                                        </th>
                                        <th>
                                            Điện thoại
                                        </th>
                                        <th>
                                            Website
                                        </th>
                                        <th>
                                            Mô tả
                                        </th>
                                        <th>
                                            Quy mô
                                        </th>
                                        <th>
                                            Loại hình
                                        </th>
                                        <th>
                                            Ngành nghề
                                        </th>
                                        <th>
                                            Lĩnh vực
                                        </th>
                                        <th>
                                            Liên hệ
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="RepeaterDoanhNghiep" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td class="text-center">
                                                    <%# Container.ItemIndex + 1 + (PageNumber - 1) * PageSize%>
                                                </td>
                                                <td>
                                                    <a href="<%=ResolveUrl("~/Page/10042014_HDHTDoanhNghiep/FolderPageThongTinDoanhNghiep/") %>PageThongTinChiTietDoanhNghiep.aspx?peihgnhnaoddiug=<%# Eval("DoanhNghiepGuid")%>">
                                                        <%# Eval("DoanhNghiepNameVN")%>
                                                    </a>
                                                </td>
                                                <td class="text-center">
                                                    <%# Eval("DoanhNghiepNameEN").ToString() == "" ? "<i class='text-danger'>X</i>" : "-"%>
                                                </td>
                                                <td class="text-center">
                                                    <%# Eval("DoanhNghiepID").ToString() == "" ? "<i class='text-danger'>X</i>" : "-"%>
                                                </td>
                                                <td class="text-center">
                                                    <%# Eval("NgayThanhLap") == null ? "<i class='text-danger'>X</i>" : "-"%>
                                                </td>
                                                <td class="text-center">
                                                    <%# Eval("MaSoThue").ToString() == "" ? "<i class='text-danger'>X</i>" : "-"%>
                                                </td>
                                                <td class="text-center">
                                                    <%# Eval("DiaChi").ToString() == "" ? "<i class='text-danger'>X</i>" : "-"%>
                                                </td>
                                                <td class="text-center">
                                                    <%# Eval("Email").ToString() == "" ? "<i class='text-danger'>X</i>" : "-"%>
                                                </td>
                                                <td class="text-center">
                                                    <%# Eval("DienThoai").ToString() == "" ? "<i class='text-danger'>X</i>" : "-"%>
                                                </td>
                                                <td class="text-center">
                                                    <%# Eval("Website").ToString() == "" ? "<i class='text-danger'>X</i>" : "-"%>
                                                </td>
                                                <td class="text-center">
                                                    <%# Eval("MoTa").ToString() == "" ? "<i class='text-danger'>X</i>" : "-"%>
                                                </td>
                                                <td class="text-center">
                                                    <%# Eval("QuyMoDoanhNghiepName").ToString() == "" ? "<i class='text-danger'>X</i>" : "-"%>
                                                </td>
                                                <td class="text-center">
                                                    <%# Eval("LoaiHinhDoanhNghiepName").ToString() == "" ? "<i class='text-danger'>X</i>" : "-"%>
                                                </td>
                                                <td class="text-center">
                                                    <%# Eval("NganhNgheHoatDongName").ToString() == "" ? "<i class='text-danger'>X</i>" : "-"%>
                                                </td>
                                                <td class="text-center">
                                                    <%# Eval("LinhVucKinhDoanhName").ToString() == "" ? "<i class='text-danger'>X</i>" : "-"%>
                                                </td>
                                                <td class="text-center">
                                                    <%# Eval("ThongTinLienHe").ToString() == "" ? "<i class='text-danger'>X</i>" : "-"%>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <td colspan="16">
                                            <div class="pull-right">
                                                <asp:DropDownList ID="DropDownListPageNumber" runat="server" AutoPostBack="true"
                                                    CssClass="form-control input-sm">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="pull-left">
                                                <MyC:mojoCutePager ID="mojoCutePager1" runat="server" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="16">
                                            <span class="badge badge-danger">&nbsp;X&nbsp;</span>&nbsp;<span class="text-danger">Thông
                                                tin của doanh nghiệp rỗng, cần bổ sung.</span>
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
        <asp:PostBackTrigger ControlID="LinkButtonExcel" />
        <asp:AsyncPostBackTrigger ControlID="ButtonSearch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="DropDownListPageNumber" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="mojoCutePager1" EventName="Command" />
    </Triggers>
</asp:UpdatePanel>
