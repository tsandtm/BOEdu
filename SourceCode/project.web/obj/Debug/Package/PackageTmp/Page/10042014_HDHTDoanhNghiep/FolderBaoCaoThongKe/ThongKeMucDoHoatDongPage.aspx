<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="ThongKeMucDoHoatDongPage.aspx.cs" Inherits="project.web.Page.FolderBaoCaoThongKe.ThongKeMucDoHoatDongPage" %>

<%@ Register Src="ListThongTinHopTacControl.ascx" TagName="ListThongTinHopTacControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    Thống kê mức độ hoạt động của doanh nghiệp
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
    <li><a href="#">Báo cáo - Thống kê</a></li>
    <li class="active">Mức độ hoạt động doanh nghiệp</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <uc1:ListThongTinHopTacControl ID="ListThongTinHopTacControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
    <script type="text/javascript">
        var loadDataDateTime = function () {
            $('#data_TuNgay_ThongTinHopTac .input-group.date').datepicker({
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                calendarWeeks: true,
                autoclose: true, format: "dd/mm/yyyy"
            });

            $('#data_DenNgay_ThongTinHopTac .input-group.date').datepicker({
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                calendarWeeks: true,
                autoclose: true, format: "dd/mm/yyyy"
            });
        }
        $(document).ready(function () {
            loadDataDateTime();
        });
    </script>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(loadDataDateTime);
    </script>
</asp:Content>
