<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImportChuongTrinhDaoTaoControl.ascx.cs"
    Inherits="project.web.Controls.ImportChuongTrinhDaoTaoControl" %>
<div class="ibox float-e-margins">
    <div class="ibox-content">
        <div class="steps-box clearfix">
            <div class="ghichu">
                Import thông tin chi tiết của Chương trình đào tạo</div>
            <%--step 1--%>
            <asp:Panel ID="PanelUploadFile" runat="server">
                <div class="steps-bar clearfix">
                    <ul>
                        <li class="current"><a><span>1. Chọn và mở tập tin Excel</span> </a></li>
                        <li><a><span>2. Kiểm tra dữ liệu</span></a></li>
                        <li><a><span>3. Kết thúc</span></a></li>
                    </ul>
                </div>
                <div class="steps-action clearfix">
                    <asp:LinkButton ID="ImageButtonUpload" CssClass="btn btn-sm btn-primary" runat="server"
                        ToolTip="Tải lên"><i class="fa fa-upload"></i>
 Tải lên</asp:LinkButton>
                </div>
                <div class="steps-content clearfix">
                    <asp:Label ID="lblMessError" runat="server" CssClass="error"></asp:Label>
                    <asp:RegularExpressionValidator ID="regexFile" ControlToValidate="FileUploadLevelTraining"
                        ValidationExpression="(([^.;]*[.])+(xls|xlsx|XLS|XLSX); *)*(([^.;]*[.])+(xls|xlsx|XLS|XLSX))?$"
                        Display="Dynamic" EnableClientScript="True" runat="server" ErrorMessage="Chỉ import file excel"
                        CssClass="error" />
                    <div class="steps-body">
                        <div class="">
                            <div class="col-sm-3">
                                <div class="form-group">
                                    Chương trình đào tạo
                                </div>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanelShowSinhVien_on" runat="server" UpdateMode="Conditional"
                                ChildrenAsTriggers="false">
                                <ContentTemplate>
                                    <div class="col-sm-9">
                                        <div class="form-group">
                                            <asp:DropDownList ID="DropDownListNienKhoa" AutoPostBack="true" CssClass="form-control w-200"
                                                runat="server">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <asp:DropDownList ID="DropDownListKhoa" AutoPostBack="true" CssClass="form-control w-200"
                                                runat="server">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <asp:DropDownList ID="DropDownListChuyenNganh" AutoPostBack="true" CssClass="form-control w-200"
                                                runat="server">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <asp:DropDownList ID="DropDownListChuongTrinhDaotao" runat="server" CssClass="form-control w-200">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            
                            <div class="col-sm-3">
                                <div class="form-group">
                                    File excel</div>
                            </div>
                            <div class="col-sm-9">
                                <div class="form-group">
                                    <asp:FileUpload ID="FileUploadLevelTraining" runat="server" />
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    File mẫu
                                </div>
                            </div>
                            <div class="col-sm-9">
                                <div class="form-group">
                                    <a href="<%=ResolveUrl("~/") %>Resources/temp/import_ChiTietChuongTrinhDaoTao.xls">ImportChuongTrinhDaoTao</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <%--end step 1--%>
            <%--step 2--%>
            <asp:Panel ID="PanelSaveData" runat="server">
                <div class="steps-bar clearfix">
                    <ul>
                        <li><a><span>1. Chọn và mở tập tin Excel</span> </a></li>
                        <li class="current"><a><span>2. Kiểm tra dữ liệu</span></a></li>
                        <li><a><span>3. Kết thúc</span></a></li>
                    </ul>
                </div>
                <div class="steps-action clearfix">
                    <asp:LinkButton ID="ImageButtonBack" runat="server" CssClass="btn btn-sm btn-primary disable"
                        ToolTip="Quay lại"><i class="fa fa-reply"></i>
 Quay lại</asp:LinkButton>
                    <asp:LinkButton ID="ImageButtonSave" runat="server" CssClass="btn btn-sm btn-primary"
                        ToolTip="Lưu"><i class="fa fa-floppy-o"></i>
 Lưu trữ</asp:LinkButton>
                </div>
                <div class="steps-content clearfix">
                    <asp:Label ID="lblMessageError" runat="server" CssClass="error" />
                    <div class="steps-body">
                        <table class="table table-bordered">
                            <thead class="td-center">
                                <tr>
                                    <th>
                                        #
                                    </th>
                                    <th>
                                        Loại môn học
                                    </th>
                                    <th>
                                        Nhóm môn học
                                    </th>
                                    <th>
                                        Mô tả
                                    </th>
                                    <th>
                                        Nội dung lỗi
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="GridViewPreview" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td class="t-center">
                                                <span class='<%# GetCssClass(Eval("IsDongLoi")) %>'>
                                                    <%# Eval("STT") %></span>
                                            </td>
                                            <td>
                                                <span class='<%# GetCssClass(Eval("IsDongLoi")) %>'>
                                                    <%# Eval("f_loaiMonHoc")%>
                                                    </span>
                                            </td>
                                            <td>
                                                <span class='<%# GetCssClass(Eval("IsDongLoi")) %>'>
                                                    <%# Eval("f_nhomMonHoc")%></span>
                                            </td>
                                            <td>
                                                <span class='<%# GetCssClass(Eval("IsDongLoi")) %>'>
                                                    <%# Eval("f_moTa")%></span>
                                            </td>
                                            <td>
                                                <span class='<%# GetCssClass(Eval("IsDongLoi")) %>'>
                                                    <%# Eval("ErrorContent")%></span>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </asp:Panel>
            <%--end step 2--%>
            <%--step 3--%>
            <asp:Panel ID="PanelMessage" runat="server">
                <div class="steps-bar clearfix">
                    <ul>
                        <li><a><span>1. Chọn và mở tập tin Excel</span> </a></li>
                        <li><a><span>2. Kiểm tra dữ liệu</span></a></li>
                        <li class="current"><a><span>3. Kết thúc</span></a></li>
                    </ul>
                </div>
                <div class="steps-action clearfix">
                    <asp:LinkButton ID="ImageButtonExit" runat="server" CssClass="btn btn-sm btn-primary disable"
                        ToolTip="Quay lại"><i class="fa fa-reply"></i>
 Quay lại</asp:LinkButton>
                </div>
                <div class="steps-content clearfix">
                    <asp:Label ID="lblMessageError1" runat="server" CssClass="error" />
                    <div class="steps-body">
                        <table class="table">
                            <thead class="td-center">
                                <tr>
                                    <th>
                                        #
                                    </th>
                                    <th class="text-left">
                                        Kết quả thao tác
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="GridViewSaveOK" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td class="text-center">
                                                <span class='<%# GetCssClass(Eval("IsDongLoi")) %>'>
                                                    <%# Eval("STT") %></span>
                                            </td>
                                            <td>
                                                <span class='<%# GetCssClass(Eval("IsDongLoi")) %>'>
                                                    <%# Eval("ErrorContent")%></span>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
</div>
