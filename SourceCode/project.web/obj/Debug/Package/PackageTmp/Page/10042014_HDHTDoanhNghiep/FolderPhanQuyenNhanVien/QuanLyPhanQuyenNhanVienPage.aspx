<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="QuanLyPhanQuyenNhanVienPage.aspx.cs" Inherits="project.web.Admin.QuanLyPhanQuyenNhanVienPage" %>

<%@ Register src="ListPhanQuyenNhanVienControl.ascx" tagname="ListPhanQuyenNhanVienControl" tagprefix="uc1" %>
<%@ Register src="AddPhanQuyenNhanVienControl.ascx" tagname="AddPhanQuyenNhanVienControl" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    Phân quyền nhân viên
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
   
    <li class="active">Phân quyền nhân viên</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
  
    <uc2:AddPhanQuyenNhanVienControl ID="AddPhanQuyenNhanVienControl1" 
        runat="server" />
    <uc1:ListPhanQuyenNhanVienControl ID="ListPhanQuyenNhanVienControl1" 
        runat="server" />
  
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
