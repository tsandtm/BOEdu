<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="project.web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    Dashboard
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <%--<div class="ibox float-e-margins">
        <div class="ibox-content">
            <iframe src="https://docs.google.com/spreadsheets/d/1xaEwRQk-j0z6N1uY2eOePfHmkv2HY-Z3LCmxGbqQSGo/edit?usp=sharing"
                width="100%" height="500px" frameborder="0"></iframe>
        </div>
    </div>--%>
    <div class="row">
        <div class="col-sm-12" style="text-align: center;">
            <div class="ibox float-e-margins">
                <div class="ibox-content">
                    <h2>
                        <span class="text-danger">Chức năng này đang được xây dựng</span><br />
                        <small>Vui lòng quay lại sau hoặc chuyển sang chức năng khác</small></h2>
                    <div class="div-img-center">
                        <img src="<%=ResolveUrl("~/") %>Resources/img/chucnangchuaxong.png" class="img-responsive" /></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
