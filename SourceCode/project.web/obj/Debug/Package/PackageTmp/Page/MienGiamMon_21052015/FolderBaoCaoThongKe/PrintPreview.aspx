<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintPreview.aspx.cs" Inherits="project.web.Page.MienGiamMon_21052015.FolderBaoCaoThongKe.PrintPreview" %>

<%@ Register Src="PrintChuongTrinhDaoTaoSinhVienControl.ascx" TagName="PrintChuongTrinhDaoTaoSinhVienControl"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>In Chương trình đào tạo Sinh viên</title>
    <style type="text/css" media="print">
        @media print
        {
            thead
            {
                display: table-header-group !important;
            }
            tbody
            {
                display: table-row-group !important;
            }
            /*tr {page-break-inside: avoid;}*/
        }
       
    </style>
</head>
<body>
    <form id="form1" runat="server">


    <link id="MyStyleSheet" rel="stylesheet" type="text/css" runat="server" />


    <asp:Button ID="ButtonPrint" runat="server" Text="Print" CssClass="btn btn-primary btn-sm btn-print"/>

    <uc1:PrintChuongTrinhDaoTaoSinhVienControl ID="PrintChuongTrinhDaoTaoSinhVienControl1"
        runat="server" />
    </form>
</body>
</html>
