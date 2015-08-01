<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftMenuControl.ascx.cs"
    Inherits="project.web.Controls.FolderMain.LeftMenuControl" %>
<link href="<%=ResolveUrl("~/") %>Resources/plugins/menu-left/css/dcaccordion.css"
    rel="stylesheet" type="text/css" />
<link href="<%=ResolveUrl("~/") %>Resources/plugins/menu-left/css/skins/blue.css"
    rel="stylesheet" type="text/css" />
<div class="blue ">
    <ul class="accordion nav" id="accordion-3">
        <li id="Dashboard" runat="server"><a href="<%=ResolveUrl("~/") %>Default.aspx"><i
            class="fa fa-th-large"></i><span class="nav-label">Dashboard</span></a> </li>
        <li id="DoanhNghiep" runat="server"><a href="<%=ResolveUrl("~/") %>Page/FolderCatologies/QuanLyDanhMucThongTinPage.aspx">
            <i class="fa fa-cubes"></i><span class="nav-label">Danh mục tài khoản</span></a> </li>
       
   
         <li id="Li1" runat="server" runat="server"><a href="<%=ResolveUrl("~/") %>Page/FolderCatologies/ImportCAT.aspx">
            <i class="fa fa-exclamation-triangle"></i><span class="nav-label">Import sinh viên</span></a>
        </li>
        <li id="QuanLyLoi" runat="server" runat="server"><a href="<%=ResolveUrl("~/") %>Page/FolderCatologies/ImportCATGV.aspx">
            <i class="fa fa-exclamation-triangle"></i><span class="nav-label">Import giảng viên</span></a>
        </li>
    </ul>
</div>
