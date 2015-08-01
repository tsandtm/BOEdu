<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="BaoCaoThongKePage.aspx.cs" Inherits="project.web.Page.MienGiamMon_21052015.FolderBaoCaoThongKe.BaoCaoThongKePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    Báo cáo thống kê
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
    <li class="active">Báo cáo thống kê</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <div class="ibox float-e-margins">
                <%--  <div class="ibox-title">
                    <h5>
                       Danh mục báo cáo thống kê</h5>
                    <div class="ibox-tools">
                        <a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </div>
                </div>--%>
                <div class="ibox-content">
                    <div class="row">
                        <div class="col-sm-3">
                            <a href="<%=ResolveUrl("~/") %>Page/MienGiamMon_21052015/FolderBaoCaoThongKe/ThongKeTheoLopPage.aspx"
                                class="text-nodecoration">
                                <div class="panel status panel-success">
                                    <div class="panel-heading">
                                        <h1 class="panel-title text-center">
                                            01</h1>
                                    </div>
                                    <div class="panel-body text-center">
                                        <strong>Thống kê môn miễn theo lớp</strong>
                                    </div>
                                </div>
                            </a>
                        </div>
                        <div class="col-sm-3">
                            <a href="<%=ResolveUrl("~/") %>Page/MienGiamMon_21052015/FolderBaoCaoThongKe/ThongKeToanTruongPage.aspx"
                                class="text-nodecoration">
                                <div class="panel status panel-success">
                                    <div class="panel-heading">
                                        <h1 class="panel-title text-center">
                                            02</h1>
                                    </div>
                                    <div class="panel-body text-center">
                                        <strong>Thống kê môn miễn toàn trường</strong>
                                    </div>
                                </div>
                            </a>
                        </div>
                        <%--<div class="col-sm-3">
                            <a href="<%=ResolveUrl("~/") %>Page/MienGiamMon_21052015/FolderBaoCaoThongKe/TongHopSinhVienMienMonPage.aspx"
                                class="text-nodecoration">
                                <div class="panel status panel-success">
                                    <div class="panel-heading">
                                        <h1 class="panel-title text-center">
                                            03</h1>
                                    </div>
                                    <div class="panel-body text-center">
                                        <strong>Tổng hợp sinh viên miễn môn</strong>
                                    </div>
                                </div>
                            </a>
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
