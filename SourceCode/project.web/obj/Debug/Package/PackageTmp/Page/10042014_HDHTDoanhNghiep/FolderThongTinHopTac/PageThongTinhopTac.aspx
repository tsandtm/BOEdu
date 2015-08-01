<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="PageThongTinhopTac.aspx.cs" Inherits="project.web.Page.FolderThongTinHopTac.PageThongTinhopTac" %>

<%@ Register Src="~/Page/10042014_HDHTDoanhNghiep/FolderThongTinHopTac/ControlThongTinHopTac.ascx"
    TagName="ControlThongTinHopTac" TagPrefix="uc1" %>
<%@ Register Src="~/Page/10042014_HDHTDoanhNghiep/FolderThongTinDoanhNghiep/ControlThongTinDoanhNghiep.ascx"
    TagName="ControlThongTinDoanhNghiep" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    Thông tin hoạt động hợp tác
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
    <li><a href="../FolderDoanhNghiep/PageQuanLyThongTinDoanhNghiep.aspx">Quản lý doanh
        nghiệp</a></li>
    <li class="active">Thông tin hoạt động hợp tác</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row animated fadeInRight">
            <div class="col-sm-4">
                <uc2:ControlThongTinDoanhNghiep ID="ControlThongTinDoanhNghiep1" runat="server" />
            </div>
            <div class="col-sm-8">
                <uc1:ControlThongTinHopTac ID="ControlThongTinHopTac1" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
