<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Portal.Master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="project.web.Secure.Register" %>


<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
 <div class="col-md-12">
        <!--breadcrumbs start -->
        <ul class="breadcrumb">
            <li><a href="#"><i class="fa fa-home"></i>Trang chủ</a></li>
            <li class="active">Thêm mới người dùng</li>
        </ul>
        <!--breadcrumbs end -->
    </div>
    <asp:Panel ID="pnlRegister" runat="server" CssClass="securityroles">
        <div class="row-fluid">
            <div class="block span6">
                <a href="#" class="block-heading">Thêm mới quyền người dùng</a>
                <div class="block-body collapse in">
                    <h2>
                    </h2>
                    <label>
                        Full Name</label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="input-xlarge"></asp:TextBox><br />
                    <label>
                        Login name</label>
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="input-xlarge"></asp:TextBox><br />
                    <label>
                        Password</label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="input-xlarge"></asp:TextBox><br />
                    <label>
                        Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="input-xlarge"></asp:TextBox>
                    <br />
                    <asp:LinkButton ID="ImageButtonAddNew" CssClass="btn btn-primary" runat="server"
                        Text="Thêm mới tài khoản" ToolTip="Thêm mới" />
                    <br />
                    <br />
                </div>
            </div>
        </div>
        <%--<i class="linehieght">Chú ý: Chức năng Xoá sẽ ảnh hưởng đến quyền hạn của User. Vui lòng cẩn trọng khi thêm mới hoặc xóa.</i>--%>
        <asp:Label ID="CreateAccountResults" runat="server" ForeColor="Red" /></asp:Label>
        </div> </div>
    </asp:Panel>
    </asp:Content>
