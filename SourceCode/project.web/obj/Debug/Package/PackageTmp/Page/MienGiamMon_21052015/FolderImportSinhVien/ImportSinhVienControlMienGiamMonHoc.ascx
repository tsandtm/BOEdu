<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImportSinhVienControlMienGiamMonHoc.ascx.cs"
    Inherits="project.web.Controls.ImportSinhVienControlMienGiamMonHoc" %>
<div class="ibox float-e-margins">
    <div class="ibox-content">
        <div class="steps-box clearfix">
            <div class="ghichu">
                Import thông tin chi tiết của Sinh viên xét miễn môn học
            </div>
            <asp:Label ID="LabelLoi" runat="server" CssClass="error"></asp:Label>
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
                                    Chọn niên khóa
                                </div>
                            </div>
                            <div class="col-sm-9">
                                <div class="form-group">
                                    <asp:DropDownList runat="server" ID="DropDownListNienKhoa" CssClass="form-control w-200">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    File excel
                                </div>
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
                                    <a href="<%=ResolveUrl("~/") %>Resources/temp/Import_SinhVien.xls">ImportSinhVien</a>
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
                                    <th rowspan="2">#
                                    </th>
                                    <th colspan="3">Tuyển sinh
                                    </th>
                                    <th colspan="6">Sinh viên
                                    </th>
                                    <th colspan="2">Liên hệ
                                    </th>
                                    <th colspan="4">Đã tốt nghiệp
                                    </th>
                                    <th rowspan="2">Nội dung lỗi
                                    </th>
                                </tr>
                                <tr>
                                    <th>Trình độ
                                    </th>
                                    <th>Hình thức
                                    </th>
                                    <th>Ngành
                                    </th>
                                    <th>Mã SV
                                    </th>
                                    <th>Họ tên
                                    </th>
                                    <th>Ngày sinh
                                    </th>
                                    <th>Lớp
                                    </th>
                                    <th>Khoa
                                    </th>
                                    <th>SBD
                                    </th>
                                    <th>Địa chỉ
                                    </th>
                                    <th>Điện thoại
                                    </th>
                                    <th>Trường
                                    </th>
                                    <th>Ngành
                                    </th>
                                    <th>Trình độ
                                    </th>
                                    <th>Hình thức
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="GridViewPreview" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td class="text-center">
                                                <span class='<%# GetCssClass(Eval("IsDongLoi")) %>'>
                                                    <%# Eval("STT") %></span>
                                            </td>
                                            <td>
                                                <span class='<%# GetCssClass(Eval("IsDongLoi")) %>'>
                                                    <%# Eval("TrinhDoDT")%></span>
                                            </td>
                                            <td style="text-align: center!important;">
                                                <span class='<%# GetCssClass(Eval("IsDongLoi")) %>'>
                                                    <%# Eval("HinhThucDT")%></span>
                                            </td>
                                            <td>
                                                <span class='<%# GetCssClass(Eval("IsDongLoi")) %>'>
                                                    <%# Eval("nganh")%></span>
                                            </td>
                                            <td>
                                                <span class='<%# GetCssClass(Eval("IsDongLoi")) %>'>
                                                    <%# Eval("MaSV")%></span>
                                            </td>
                                            <td>
                                                <span class='<%# GetCssClass(Eval("IsDongLoi")) %>'>
                                                    <%# Eval("hoten")%></span>
                                            </td>
                                            <td>
                                                <span class='<%# GetCssClass(Eval("IsDongLoi")) %>'>
                                                    <%# Eval("ngaysinh")%></span>
                                            </td>
                                            <td>
                                                <span class='<%# GetCssClass(Eval("IsDongLoi")) %>'>
                                                    <%# Eval("Lop")%></span>
                                            </td>
                                            <td>
                                                <span class='<%# GetCssClass(Eval("IsDongLoi")) %>'>
                                                    <%# Eval("Khoa")%></span>
                                            </td>
                                            <td>
                                                <span class='<%# GetCssClass(Eval("IsDongLoi")) %>'>
                                                    <%# Eval("sobaodanh")%></span>
                                            </td>
                                            <td>
                                                <span class='<%# GetCssClass(Eval("IsDongLoi")) %>'>
                                                    <%# Eval("DCLL")%></span>
                                            </td>
                                            <td>
                                                <span class='<%# GetCssClass(Eval("IsDongLoi")) %>'>
                                                    <%# Eval("DTLL")%></span>
                                            </td>
                                            <td>
                                                <span class='<%# GetCssClass(Eval("IsDongLoi")) %>'>
                                                    <%# Eval("TruongTN")%></span>
                                            </td>
                                            <td>
                                                <span class='<%# GetCssClass(Eval("IsDongLoi")) %>'>
                                                    <%# Eval("NganhTN")%></span>
                                            </td>
                                            <td>
                                                <span class='<%# GetCssClass(Eval("IsDongLoi")) %>'>
                                                    <%# Eval("TrinhDoDT_Old")%></span>
                                            </td>
                                            <td>
                                                <span class='<%# GetCssClass(Eval("IsDongLoi")) %>'>
                                                    <%# Eval("HinhThucDT_Old")%></span>
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
                                    <th>#
                                    </th>
                                    <th class="text-left">Kết quả thao tác
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
