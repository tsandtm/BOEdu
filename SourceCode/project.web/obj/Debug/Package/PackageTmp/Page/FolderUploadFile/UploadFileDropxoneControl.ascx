<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadFileDropxoneControl.ascx.cs"
    Inherits="project.web.Page.UploadFileDropxoneControl" %>
<div class="col-sm-12">
    <asp:Panel runat="server" ID="PanelDropZone" CssClass="dropzone">
        <button type="submit" class="btn btn-primary btn-sm pull-right btn-uploadfile">
            Upload</button>
    </asp:Panel>
    <asp:HiddenField ID="HiddenFieldLoaiHinhAnh" runat="server" />
</div>
<div class="col-sm-12">
    <asp:Panel ID="PanelLoadGallery" runat="server">
    </asp:Panel>
</div>
