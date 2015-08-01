<%--   
Author:					Le Hoang Nam
Created:				2015-4-13
Last Modified:			2015-4-13
--%>
<%--<style>
     #ctl00_ContentPlaceHolderContent_ListDoanhNghiepControl1_UpdatePanelBoLoc
     {display:inline-block;}
      #ctl00_ContentPlaceHolderContent_ListDoanhNghiepControl1_UpdatePanelNutTacVu
      {display:inline-block;}
 </style>--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListDoanhNghiepControl.ascx.cs"
    Inherits="project.web.Controls.ListDoanhNghiepControl" %>
<style type="text/css">
    .showme
    {
        display: none;
    }
    .showhim:hover .showme
    {
        display: block;
    }
    .showhim:hover .hideme
    {
        display: none;
    }
    .current
    {
        font-weight: bold;
    }
</style>
<div class="row p-b-10">
    <asp:UpdatePanel ID="UpdatePanelBoLoc" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <ContentTemplate>
            <%--<div class="col-sm-3" >--%>
            <asp:DropDownList ID="DropDownListDonVi" runat="server" CssClass="form-control w-full"
                Visible="false">
            </asp:DropDownList>
            <%--</div>--%>
            <div class="col-sm-3">
                <asp:DropDownList ID="DropDownListNganhNghe" runat="server" CssClass="form-control chosen-select w-full">
                </asp:DropDownList>
            </div>
            <div class="col-sm-3">
                <asp:Panel DefaultButton="ButtonSearch" runat="server" CssClass="tooltip-demo">
                    <div class="input-group">
                        <asp:TextBox ID="TextBoxDoanhNghiep" runat="server" placeholder="Tên doanh nghiệp"
                            CssClass="form-control w-full showtooltip"></asp:TextBox>
                        <ul id="elementToHide">
                            <li><b><u>Quy định khóa</u></b></li>
                            <li>- <strong class="text-danger">EMAIL</strong>: địa chỉ email</li>
                            <li>- <strong class="text-danger">PHONE</strong>: số điện thoại</li>
                            <li><b><u>Sử dụng</u></b></li>
                            <li class="text-danger">[từ khóa]:[cụm từ cần tìm]</li>
                            <li><i><u>Ví dụ:</u> PHONE:093</i></li>
                            <li class="text-success">* Mặc định không sử dụng từ khóa thì tìm kiếm theo tên</li>
                        </ul>
                        <span class="input-group-btn">
                            <asp:LinkButton ID="ButtonSearch" runat="server" ToolTip="Tìm kiếm" CssClass="btn btn-primary"><i class="fa fa-search"></i></asp:LinkButton>
                        </span>
                    </div>
                </asp:Panel>
            </div>
            <div class="col-sm-3">
            </div>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanelNutTacVu" runat="server" UpdateMode="Conditional"
        ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="col-sm-3">
                <div class="pull-right">
                    <a href="<%=ResolveUrl("~/Page/10042014_HDHTDoanhNghiep/FolderPageThongTinDoanhNghiep/") %>PageThongTinChiTietDoanhNghiep.aspx?peihgnhnaoddiug=00000000-0000-0000-0000-000000000000"
                        class="btn btn-add" title="Thêm mới doanh nghiệp"><i class="fa fa-file-o"></i>&nbsp;Thêm
                        mới </a>&nbsp;&nbsp;
                    <%-- <asp:LinkButton ID="ButtonExcel" runat="server" ToolTip="Xuất excel" CssClass="" Text="Xuất Excel">
                    <i class="fa fa-file-excel-o"></i>
                    </asp:LinkButton>--%>
                    <asp:LinkButton ID="ButtonExcel" runat="server" class="btn-excel"><i class="fa fa-file-excel-o"></i>&nbsp;Xuất excel
                    </asp:LinkButton>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ButtonSearch" EventName="Click" />
            <asp:PostBackTrigger ControlID="ButtonExcel" />
        </Triggers>
    </asp:UpdatePanel>
</div>
<div class="row">
    <div class="col-sm-12">
        <div class="ibox">
            <div class="ibox-content">
                <div class="table-responsive">
                    <asp:UpdatePanel ID="UpdatePanelShowDoanhNghiep_on" runat="server" UpdateMode="Conditional"
                        ChildrenAsTriggers="false">
                        <ContentTemplate>
                            <table class="table table-striped">
                                <thead>
                                    <tr class="">
                                        <th style="width: 50px;">
                                            #
                                        </th>
                                        <th>
                                            Doanh nghiệp
                                        </th>
                                        <th>
                                            Điện thoại
                                        </th>
                                        <th>
                                            Địa chỉ
                                        </th>
                                        <th>
                                            Người liên hệ
                                        </th>
                                        <th>
                                            Điện thoại
                                        </th>
                                        <th>
                                            Email
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="RepeaterDoanhNghiep" runat="server">
                                        <ItemTemplate>
                                            <tr class="showhim" data="<%# Eval("DoanhNghiepGuid")%>">
                                                <td style="height: 50px; text-align: center;">
                                                    <div>
                                                        <div class="hideme">
                                                            <%# Container.ItemIndex + 1 + (PageNumber - 1) * PageSize%>
                                                        </div>
                                                        <div class="showme">
                                                            <a href="<%=ResolveUrl("~/Page/10042014_HDHTDoanhNghiep/FolderPageThongTinDoanhNghiep/") %>PageThongTinChiTietDoanhNghiep.aspx?peihgnhnaoddiug=<%# Eval("DoanhNghiepGuid")%>"
                                                                class="btn btn-primary btn-circle btn-outline"><i class="fa fa-pencil"></i></a>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <a href="<%# ResolveUrl("~/") + "Page/10042014_HDHTDoanhNghiep/FolderThongTinHopTac/PageThongTinhopTac.aspx?index=" + Eval("DoanhNghiepGuid") %>">
                                                        <%# Eval("DoanhNghiepNameVN") == "" ? Eval("DoanhNghiepNameEN") : Eval("DoanhNghiepNameVN")%>
                                                    </a>
                                                </td>
                                                <td>
                                                    <%# Eval("DienThoai")%>
                                                </td>
                                                <td>
                                                    <%# Eval("DiaChi")%>
                                                </td>
                                                <td>
                                                    <%# Eval("DauMoi_DanhXung")%>&nbsp
                                                    <%# Eval("DauMoi_Ten")%>
                                                </td>
                                                <td>
                                                    <%# Eval("DauMoi_DienThoai")%>
                                                </td>
                                                <td>
                                                    <%# Eval("DauMoi_Email")%>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <td colspan="9">
                                            <div class="pull-right">
                                                <asp:DropDownList ID="DropDownListPageNumber" runat="server" AutoPostBack="true"
                                                    CssClass="form-control input-sm">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="pull-left">
                                                <MyC:mojoCutePager ID="mojoCutePager1" runat="server" />
                                            </div>
                                        </td>
                                    </tr>
                                </tfoot>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DropDownListPageNumber" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="mojoCutePager1" EventName="Command" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</div>
<script src="<%=ResolveUrl("~/") %>Resources/js/jquery-2.1.1.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $('.table a').click(function () {
            var bb = $(this).parents("tr").attr("data");
            $.cookie('aaa', bb);
        });

        var thisLink = $.cookie('aaa');
        if (thisLink) {
            var a = $('tr[data="' + thisLink + '"]');
            $(a).addClass('current');
        }
    });
    
</script>
