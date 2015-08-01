<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImportCATGVControl.ascx.cs"
    Inherits="DA.Web.Controls.ImportData.ImportCATGVControl" %>
<style type="text/css">
    .ErrorRow{color:Red;}

</style>
<div class="container">
<asp:Panel ID="PanelUploadFile" runat="server">

    <div class="importcontent">
        <div class="block-small">
            <div class="bs-header-2">
                Bước 1: Chọn và mở tập tin Excel</div>
            <div class="settingrow">
                <table class="metrouicss">
                 
                    <tr>
                        <td>
                            <label>
                                File excel&nbsp;
                            </label>
                        </td>
                        <td>
                            
                                <asp:FileUpload ID="FileUploadLevelTraining" runat="server" />
                            
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div class="bs-footer metrouicss">
                <div class="left">
                    
                        <asp:Button ID="ImageButtonUpload" CssClass="btn btn-primary width-size-110" runat="server" Text="Tải lên" />
                    
                    <div class="left">
                        <asp:Label ID="lblMessError" runat="server" CssClass="error"></asp:Label>
                        <asp:RegularExpressionValidator ID="regexFile" ControlToValidate="FileUploadLevelTraining"
                            ValidationExpression="(([^.;]*[.])+(xls|xlsx|XLS|XLSX); *)*(([^.;]*[.])+(xls|xlsx|XLS|XLSX))?$"
                            Display="Dynamic" EnableClientScript="True" runat="server" ErrorMessage="Chỉ import file excel"
                            CssClass="error" />
                    </div>
                </div>
                <%--<asp:HiddenField ID="hdnReturnUrl" runat="server" />--%>
            </div>
        </div>
        <div class="block-small1">
            <div class="imgdulieumau">
                <a href="<%=ResolveUrl("~/") %>Resources/temp/Mau_import_GV.xls">
                    <img src="<%=ResolveUrl("~/") %>Resources/img/dulieumau.gif" alt="" style="height:48px;" />
                </a>
            </div>
            <br />
            <img src="<%=ResolveUrl("~/") %>Resources/img/huongdan.gif" alt="" style="height:100px;" />
        </div>
    </div>
</asp:Panel>
<asp:Panel ID="PanelSaveData" runat="server">
    <div class="importcontent">
        <div class="block-large">
            <div class="bs-header-2">
                Bước 2: Kiểm ta dữ liệu</div>
            <br />
            <div class="settingrow metrouicss">
                <asp:Button ID="ImageButtonBack" runat="server" CssClass="btn btn-primary width-size-110 floatleft" Text="Quay lại" />
                <asp:Button ID="ImageButtonSave" runat="server" CssClass="btn btn-primary width-size-110 floatleft" Text="Lưu" />
                <div class="left">
                    <asp:Label ID="lblMessageError" runat="server" CssClass="error" /></div>
            </div>
            <div class="settingrow-l metrouicss">
                <table class="table hovered boderline">
                    <thead class="headertable ">
                        <tr>
                            <th style="text-align: center!important; width: 30px; ">
                                STT
                            </th>
                            <th style="text-align: center!important; width: 100px; ">
                               Mã nhân viên
                            </th>
                           
                          
                             <th style="text-align: center!important; ">
                              Họ và tên 
                            </th>
                           
                            <th style="text-align: center!important; ">
                                Nội dung lỗi
                            </th>
                        </tr>
                    </thead>
                    <tbody class="boderline">
                        <asp:Repeater ID="GridViewPreview" runat="server">
                            <ItemTemplate>
                                <tr class="t-right">
                                    <td style="text-align: center!important;">
                                        <span class='<%# GetCssClass(Eval("IsDongLoi")) %>'>
                                            <%# Eval("STT") %></span>
                                    </td>
   
                                    <td style="text-align: left!important;">
                                        <span class='<%# GetCssClass(Eval("IsDongLoi")) %>'>
                                            <%# Eval("manv")%></span>
                                    </td>
                                    <td style="text-align: center!important;">
                                        <span class='<%# GetCssClass(Eval("IsDongLoi")) %>'>
                                            <%# Eval("hovaten")%></span>
                                    </td>
                                    

                                    <td style="text-align: left!important;">
                                        <span class='<%# GetCssClass(Eval("IsDongLoi")) %>'>
                                            <%# Eval("ErrorContent")%></span>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                    <tfoot class="footertable">
                        <tr>
                            <td colspan="11" style="vertical-align: middle;">
                            </td>
                        </tr>
                    </tfoot>
                </table>
            </div>
        </div>
    </div>
</asp:Panel>
<asp:Panel ID="PanelMessage" runat="server">
    <div class="importcontent">
        <div class="block-large">
            <div class="bs-header-2">
                Bước 3: Kết thúc</div>
            
            <div class="settingrow metrouicss">
                <asp:Button ID="ImageButtonExit" CssClass="btn btn-primary width-size-110 floatleft" runat="server" Text="Quay lại" />
                <div class="left">
                    <asp:Label ID="lblMessageError1" runat="server" CssClass="error" /></div>
            </div>
            <div class="settingrow-l metrouicss">
                
                <table class="table hovered boderline">
                    <thead class="headertable">
                        <tr>
                            <th style="text-align: center!important; width: 30px; color: #FFFFFF;">
                                STT
                            </th>
                            <th style="text-align: center!important; color: #FFFFFF;">
                                Kết quả thao tác
                            </th>
                        </tr>
                    </thead>
                    <tbody class="boderline">
                        <asp:Repeater ID="GridViewSaveOK" runat="server">
                            <ItemTemplate>
                                <tr class="t-right">
                                    <td style="text-align: center!important;">
                                        <span class='<%# GetCssClass(Eval("IsDongLoi")) %>'>
                                            <%# Eval("STT") %></span>
                                    </td>
                                    <td style="text-align: left!important;">
                                        <span class='<%# GetCssClass(Eval("IsDongLoi")) %>'>
                                            <%# Eval("ErrorContent")%></span>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                    <tfoot class="footertable">
                        <tr>
                            <td colspan="11" style="vertical-align: middle;">
                            </td>
                        </tr>
                    </tfoot>
                </table>
            </div>
        </div>
    </div>
</asp:Panel>
</div>