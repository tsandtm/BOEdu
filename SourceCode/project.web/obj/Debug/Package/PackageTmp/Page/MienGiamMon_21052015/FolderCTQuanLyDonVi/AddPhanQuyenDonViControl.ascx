<%--   
Author:					Nguyen Thanh Dai
Created:				2015-5-11
Last Modified:			2015-5-11
--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddPhanQuyenDonViControl.ascx.cs"
    Inherits="project.web.Controls.AddPhanQuyenDonViControl" %>
<%@ Register Src="~/Page/MienGiamMon_21052015/FolderCTQuanLyDonVi/ListCTQuanLyDonViControl.ascx"
    TagName="ListCTQuanLyDonViControl" TagPrefix="uc2" %>
<%--Luu y phai dat id popup o ngoai de khong bi an khi thao tac xong--%>
<%--<div id="tspopup" runat="server" clientidmode="Static" class="bigbox-800">--%>
<%-- <div class="panel panel-default panel-popup">
        <div class="panel-heading">
            <h3 class="panel-title">
                Thông tin nhân viên</h3>
        </div>
        <div class="panel-body">--%>
<asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="UpdatePanelPopupAddPhanQuyenNhanVien_on">
    <ProgressTemplate>
        <span style="position: fixed; z-index: 9999; top: 48%; left: 48%;">
            <div class="div-img-center">
                <img src="<%=ResolveUrl("~/") %>Resources/img/waiting.gif" alt="Vui lòng đợi..."
                    class="img-responsive" height="80px" width="80px" />
            </div>
        </span>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanelPopupAddPhanQuyenNhanVien_on" runat="server" UpdateMode="Conditional"
    ChildrenAsTriggers="false">
    <ContentTemplate>
        <asp:Literal ID="LiteralNguoiDungGuid" Visible="false" runat="server"></asp:Literal>
        <asp:Literal ID="LiteralPosition" Visible="false" runat="server"></asp:Literal>
        <div id="seachPanel" runat="server" clientidmode="Static" class="col-md-5">
            <div class="form-inline">
                <asp:Panel runat="server" ID="panelseach" DefaultButton="LinkButtonSeach">
                    <asp:TextBox ID="TextBoxKeySeach" CssClass="width-size-200 form-control input-sm "
                        runat="server"></asp:TextBox>
                    <asp:LinkButton ID="LinkButtonSeach" runat="server" ToolTip="Tìm" CssClass="btn btn-primary width-size-110 btn-sm"><i class="fa fa-search"></i>&nbsp;Tìm</asp:LinkButton>
                </asp:Panel>
            </div>
            <table class="table table-stripped table-hover  table-bordered">
                <asp:Repeater ID="RepeaterUser" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td class="text-left">
                                <asp:LinkButton ID="LinkButtonItem" CssClass="fg-cyan" runat="server" ToolTip='<%# Eval("NguoiDungID")%>'
                                    CommandName="EDIT" CommandArgument='<%# Eval("NguoiDungGuid")%>'><%# Eval("UserNameFullShow")%> </asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <div id="PanelThongTin" runat="server" clientidmode="Static" class="col-md-7">
            <div class="row">
                <div class="col-md-4">
                    <div class="">
                        Người dùng ID
                    </div>
                </div>
                <div class="col-md-8">
                    <div class="form-group">
                        <asp:Label ID="TextBoxnguoiDungID" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <div class="">
                        Tên người dùng
                    </div>
                </div>
                <div class="col-md-8">
                    <div class="form-group">
                        <asp:Label ID="TextBoxnguoiDungName" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <div class="">
                        Đơn vị
                    </div>
                </div>
                <div class="col-md-8">
                    <div class="form-group">
                        <asp:Label ID="LabelDonVi" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
            <asp:Panel  runat="server" Visible="false" ID="pnlquyen">
            <div class="row">
                <div class="col-md-4">
                    <div class="">
                        Quyền quản lý chưa có
                    </div>
                </div>
                <div class="col-md-8">
                    <div class="form-group">
                        <asp:DropDownList ID="DropDownListDonVi" runat="server" CssClass="form-control input-sm w-full">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

           
                <div class="text-right m-b-5">
                    <asp:LinkButton ID="ButtonSave" runat="server" ToolTip="Lưu trữ" CssClass="btn btn-add"><i class="fa fa-floppy-o"></i>&nbsp;Thêm vào danh sách</asp:LinkButton>
                </div>
            
            <div class="row">
            Danh sách quyền quản lý đơn vị
                <uc2:ListCTQuanLyDonViControl ID="ListCTQuanLyDonViControl1" runat="server" />
            </div>
            </asp:Panel>
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ButtonSave" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>
<%--      </div>
    </div>
</div>
--%>