<%--   
Author:					Nguyen Van Ngoc
Created:				2014-3-11
Last Modified:			2014-3-11
--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddDoiTuongThucTapControl.ascx.cs"
    Inherits="project.web.Controls.AddDoiTuongThucTapControl" %>
<%--Luu y phai dat id popup o ngoai de khong bi an khi thao tac xong--%>
<div id="ts-popup" class="bigbox">
    <asp:UpdatePanel ID="UpdatePanelPopupAddCatologie_on" runat="server" UpdateMode="Conditional"
        ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="panel panel-default panel-popup">
                <div class="panel-heading">
                    <h3 class="panel-title">Thông tin đối tượng thực tập</h3>
                </div>
                <div class="panel-body">
                    <asp:Literal ID="LiteralCatologyGuid" runat="server" Visible="false"></asp:Literal>
                    <asp:Literal ID="LiteralSettingGuid" runat="server" Visible="false"></asp:Literal>
                    <div class="row">
                        <div class="col-sm-5">
                            <div class="form-group">
                                Mã danh mục
                            </div>
                        </div>
                        <div class="col-sm-7">
                            <div class="form-group">
                                <asp:Label ID="LableCatologyID" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-5">
                            <div class="form-group">
                                Tên danh mục
                            </div>
                        </div>
                        <div class="col-sm-7">
                            <div class="form-group">
                                <asp:TextBox ID="TextBoxCatologyName" runat="server" CssClass="form-control input-sm w-full"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-5">
                            <div class="form-group">
                                Mô tả
                            </div>
                        </div>
                        <div class="col-sm-7">
                            <div class="form-group">
                                <asp:TextBox ID="TextBoxDescription" runat="server" CssClass="form-control input-sm w-full"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-5">
                            <div class="form-group">
                                Thứ tự hiển thị
                            </div>
                        </div>
                        <div class="col-sm-7">
                            <div class="form-group">
                                <asp:TextBox ID="TextBoxPosition" runat="server" CssClass="form-control input-sm w-full"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-5">
                            <div class="form-group">
                                Danh mục
                            </div>
                        </div>
                        <div class="col-sm-7">
                            <div class="form-group">
                                <asp:DropDownList ID="DropDownListCatologies" runat="server" CssClass="form-control input-sm w-full">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4"></div>
                        <div class="col-sm-8">
                            <div class="form-group">
                                <asp:CheckBox ID="CheckBoxIsActive" runat="server" />
                                <label class="checkbox-inline">
                                    Cho phép sử dụng
                                </label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Panel ID="PanelFileUpload" runat="server">
                                <!--- Begin save file thumbnail -->
                                <script type="text/javascript">

                                    function uploadError(sender, args) {
                                        addToClientTable(args.get_fileName(), "<span style='color:red;'>" + args.get_errorMessage() + "</span>");
                                    }
                                    function uploadComplete(sender, args) {
                                        var contentType = args.get_contentType();
                                        var text = args.get_length() + " bytes";
                                        if (contentType.length > 0) {
                                            text += ", '" + contentType + "'";
                                        }
                                        $('#img_prev').attr('src', '<%=ResolveUrl("~/Data/ImageCatology/") %>' + args.get_fileName());
                                        //addToClientTable(args.get_fileName(), text);
                                    }

                                </script>
                                <div class="demoarea">
                                    <ajaxToolkit:AsyncFileUpload OnClientUploadError="uploadError" OnClientUploadComplete="uploadComplete"
                                        runat="server" ID="AsyncFileUpload1" UploadingBackColor="#CCFFFF" ThrobberID="myThrobber" CssClass="w-full"/>
                                    <%--<asp:Label runat="server" ID="myThrobber" Style="display: none;"><img align="absmiddle" alt="" src="uploading.gif" /></asp:Label>--%>
                                    <asp:Label runat="server" Text="&nbsp;" ID="uploadResult"  CssClass="w-full"/>
                                    <br />
                                    <%--<table style="border-collapse: collapse; border-left: solid 1px #aaaaff; border-top: solid 1px #aaaaff;"
                    runat="server" cellpadding="3" id="clientSide" />--%>
                                    <img id="img_prev" runat="server" src="" clientidmode="Static" alt="" width="100"
                                        height="100" />
                                </div>
                                <!--- The end save file thumbnail -->
                            </asp:Panel>
                        </div>
                    </div>
                </div>
                <div class="panel-footer text-right">
                    <asp:Button ID="ButtonSave" runat="server" Text="Lưu" CssClass="btn btn-primary btn-sm" />
                    <asp:Button ID="ButtonExit" runat="server" Text="Thoát" CssClass="btn btn-warning btn-sm" />
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ButtonSave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ButtonExit" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</div>
