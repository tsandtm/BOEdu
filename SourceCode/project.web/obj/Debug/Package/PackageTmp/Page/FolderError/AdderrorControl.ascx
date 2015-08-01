<%@ Register Src="../FolderUploadFile/UploadFileDropxoneControl.ascx" TagName="UploadFileDropxoneControl"
    TagPrefix="uc1" %>
<%--   
Author:					namdt
Created:				2015-5-13
Last Modified:			2015-5-13
--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdderrorControl.ascx.cs"
    Inherits="project.web.Controls.AdderrorControl" %>
<%--Luu y phai dat id popup o ngoai de khong bi an khi thao tac xong--%>
<div class="row">
    <div class="col-sm-12">
        <div class="ibox">
            <div class="ibox-content">
                <div class="box-action">
                    <div class="pull-left">
                        <a class="text-info" href="../HelperFolder/HuongDanBaoLoiUngDung.html" target="_blank">
                            <span class="btn btn-info btn-circle m-r-5"><i class="fa fa-question"></i></span>Hướng
                            dẫn tạo Báo lỗi mới</a></div>
                    <div class="pull-right">
                        <asp:LinkButton ID="ButtonSave" runat="server" OnClientClick="return saveLogLoi()"
                            ToolTip="Lưu trữ" CssClass="btn btn-add"><i class="fa fa-floppy-o p-r-5"></i>Lưu trữ</asp:LinkButton>
                    </div>
                </div>
                <div class="wrapper animated fadeInRight">
                    <%-- <div class="row box-title">
                        <h4>
                            Mô tả lỗi</h4>
                    </div>--%>
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label class="col-sm-2 control-label">
                                Mô tả lỗi (Lưu ý: cần chú thích rõ mục nào, hoặc trang nào)</label>
                            <div class="col-sm-8">
                                <div id="summernote_logerror_motaloi_baongoai">
                                    <div id="summernote_logerror_motaloi" runat="server" clientidmode="Static">
                                    </div>
                                </div>
                                <asp:HiddenField ID="summernote_logerror_motaloi_dulieu" runat="server" ClientIDMode="Static" />
                            </div>
                        </div>
                    </div>
                    <%--</div>--%>
                    <%-- <div class="wrapper animated fadeInRight">
                    <div class="row box-title">
                        <h4>
                            Chi tiết lỗi</h4>
                    </div>--%>
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label class="col-sm-2 control-label">
                                Hình ảnh</label>
                            <div class="col-sm-8">
                                <uc1:UploadFileDropxoneControl ID="UploadFileDropxoneControl1" runat="server" LoaiHinhAnh="6" />
                            </div>
                        </div>
                    </div>
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label class="col-sm-2 control-label">
                                Kết quả mong muốn</label>
                            <div class="col-sm-8">
                                <div id="summernote_logerror_ketquamongmuon_baongoai">
                                    <div id="summernote_logerror_ketquamongmuon" runat="server" clientidmode="Static">
                                    </div>
                                </div>
                                <asp:HiddenField ID="summernote_logerror_ketquamongmuon_dulieu" runat="server" ClientIDMode="Static" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    function removeHTMLTags(strInputCode) {

        strInputCode = strInputCode.replace(/&(lt|gt);/g, function (strMatch, p1) {
            return (p1 == "lt") ? "<" : ">";
        });
        var strTagStrippedText = strInputCode.replace(/<\/?[^>]+(>|$)/g, "");
        return strTagStrippedText;

    }
    function saveLogLoi() {
        if (!String.prototype.trim) {
            String.prototype.trim = function () {
                return this.replace(/^\s+|\s+$/g, '');
            };
        }
        var fag = true;
        document.getElementById('summernote_logerror_motaloi_dulieu').value = $('#summernote_logerror_motaloi_baongoai .note-editor .note-editable').html();
        document.getElementById('summernote_logerror_ketquamongmuon_dulieu').value = $('#summernote_logerror_ketquamongmuon_baongoai .note-editor .note-editable').html();
        var stringss = $('#summernote_logerror_motaloi_baongoai .note-editor .note-editable').html();
        var stringketqua = removeHTMLTags(stringss);
        if (stringketqua.trim().length == 0) {
            alert('Chưa nhập mô tả');
            fag = false;
        }
        else alert('Cảm ơn bạn đã đóng góp ý kiến');
        return fag;
    }
</script>
