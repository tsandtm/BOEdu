<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintPDF.aspx.cs" Inherits="project.web.Page.MienGiamMon_21052015.FolderBaoCaoThongKe.PrintPDF" %>

<%@ Register Src="PrintChuongTrinhDaoTaoSinhVienControl.ascx" TagName="PrintChuongTrinhDaoTaoSinhVienControl"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>In Chương trình đào tạo Sinh viên</title>
    <style type="text/css" media="print">
        @media print {
            thead {
                display: table-header-group !important;
            }

            tbody {
                display: table-row-group !important;
            }
            /*tr {page-break-inside: avoid;}*/
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:PrintChuongTrinhDaoTaoSinhVienControl ID="PrintChuongTrinhDaoTaoSinhVienControl1"
            runat="server" />
    </form>
</body>
</html>
