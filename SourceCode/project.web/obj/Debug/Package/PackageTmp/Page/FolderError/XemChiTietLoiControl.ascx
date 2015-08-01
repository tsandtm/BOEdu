<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="XemChiTietLoiControl.ascx.cs"
    Inherits="project.web.Page.FolderError.XemChiTietLoiControl" %>
<div class="row">
    <div class="col-sm-12">
        <div class="ibox">
            <div class="ibox-content">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-sm-2 control-label p-t-none">
                            Ngày</label>
                        <div class="col-sm-8">
                            <asp:Label runat="server" ID="lblNgayBaoLoi"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-sm-2 control-label p-t-none">
                            Mô tả lỗi</label>
                        <div class="col-sm-8">
                            <asp:Label runat="server" ID="TextBoxMoTa"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-sm-2 control-label p-t-none">
                            Kết quả mong muốn
                        </label>
                        <div class="col-sm-8">
                            <asp:Label runat="server" ID="TextBoxKetQua"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-sm-2 control-label p-t-none">
                            Hình ảnh
                        </label>
                        <div class="col-sm-8">
                            <div class=" row well m-w-none">
                                <div class="ibox-content">
                                    <asp:Repeater ID="RepeaterListFile" runat="server">
                                        <ItemTemplate>
                                            <a class="fancybox" href="<%# ResolveUrl("~")+ Eval("TableName").ToString() +Eval("ServerFileName")%>"
                                                title="<%# Eval("ClientFileName")%>" rel="xemchitietloi">
                                                <img alt="image" src="<%# ResolveUrl("~")+ Eval("TableName").ToString() + Eval("ServerFileName")%>" />
                                            </a>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:Panel ID="panelPhanHoi" runat="server">
                    <hr />
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label class="col-sm-2 control-label p-t-none">
                                Ngày phản hồi
                            </label>
                            <div class="col-sm-8">
                                <asp:Label runat="server" ID="TextBoxNgayPhanHoi"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label class="col-sm-2 control-label p-t-none">
                                Người phản hồi
                            </label>
                            <div class="col-sm-8">
                                <asp:Label runat="server" ID="TextBoxNguoiPhanHoi"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label p-t-none">
                            Nội dung phản hồi
                        </label>
                        <div class="col-sm-8">
                            <asp:Label runat="server" ID="TextBoxNoiDungPhanHoi"></asp:Label></div>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</div>
