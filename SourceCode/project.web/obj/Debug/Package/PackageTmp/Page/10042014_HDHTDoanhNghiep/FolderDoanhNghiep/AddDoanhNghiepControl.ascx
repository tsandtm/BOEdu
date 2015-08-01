<%--   
Author:					Le Hoang Nam
Created:				2015-4-13
Last Modified:			2015-4-13
--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddDoanhNghiepControl.ascx.cs"
    Inherits="project.web.Controls.AddDoanhNghiepControl" %>
<%@ Register Src="~/Page/FolderUploadFile/UploadFileDropxoneControl.ascx" TagName="UploadFileDropxoneControl"
    TagPrefix="uc1" %>
<div class="box-action">
    <span class="pull-left"><span class="lbl-valid p-r-5">(*)</span><span class="text-italic">Thông
        tin bắt buộc phải nhập</span> </span>
    <div class="pull-right">
        <asp:LinkButton ID="LinkButtonDel" runat="server" OnClientClick="return confirm('Ban có chắc chắn muốn xóa doanh nghiệp')"
            ToolTip="Xóa doanh nghiệp" CssClass="btn btn-delete m-r-10"><i class="fa fa-trash-o"></i>&nbsp;Xóa doanh nghiệp</asp:LinkButton>
        <asp:LinkButton ID="ButtonSave" runat="server" OnClientClick="return validation_tencongty()"
            ToolTip="Lưu" CssClass="btn btn-add"><i class="fa fa-floppy-o"></i>&nbsp;Lưu trữ</asp:LinkButton>&nbsp;hoặc&nbsp;
        <a href="<%=ResolveUrl("~/Page/10042014_HDHTDoanhNghiep/FolderDoanhNghiep/") %>PageQuanLyThongTinDoanhNghiep.aspx"
            class="btn btn-link btn-sm btn-cancel" style="display: inline-block;">Hủy thao tác</a></div>
    <asp:Literal ID="LiteralDoanhNghiepGuid" runat="server" Visible="false"></asp:Literal>
</div>
<div class="wrapper animated fadeInRight">
    <div class="row box-title">
        <h4 class="m-l">
            Thông tin cơ bản</h4>
    </div>
    <div class="form-horizontal">
        <div class="form-group">
            <label class="col-sm-2 control-label">
                Công ty<span class="lbl-valid">(*)</span>
            </label>
            <div class="col-sm-4">
                <asp:TextBox ID="TextBoxDoanhNghiepNameVN" runat="server" CssClass="form-control w-full required"
                    ClientIDMode="Static"></asp:TextBox>
                <%--<asp:UpdatePanel ID="UpdatePanelGoiYTen" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>--%>
                <asp:Label ID="LabelGoiYTen" runat="server" ClientIDMode="Static"></asp:Label>
                <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
            </div>
            <label class="col-sm-2 control-label">
                Loại hình hoạt động
            </label>
            <div class="col-sm-4">
                <asp:DropDownList ID="DropDownListLoaiHinhDoanhNghiep" runat="server" CssClass="form-control w-full">
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <div class="form-horizontal">
        <div class="form-group">
            <label class="col-sm-2 control-label">
                Email
            </label>
            <div class="col-sm-4">
                <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="form-control w-full"></asp:TextBox>
            </div>
            <label class="col-sm-2 control-label">
                Lĩnh vực
            </label>
            <div class="col-sm-4">
                <asp:DropDownList ID="DropDownListLinhVucKinhDoanh" runat="server" CssClass="form-control w-full">
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <div class="form-horizontal">
        <div class="form-group">
            <label class="col-sm-2 control-label">
                Website
            </label>
            <div class="col-sm-4">
                <asp:TextBox ID="TextBoxWebsite" runat="server" CssClass="form-control w-full"></asp:TextBox>
            </div>
            <label class="col-sm-2 control-label">
                Ngành nghề
            </label>
            <div class="col-sm-4">
                <asp:DropDownList ID="DropDownListNganhNgheHoatDong" runat="server" CssClass="form-control w-full">
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <div class="form-horizontal">
        <div class="form-group">
            <label class="col-sm-2 control-label">
                Facebook
            </label>
            <div class="col-sm-4">
                <asp:TextBox ID="TextBoxFacebook" CssClass="form-control w-full" runat="server"></asp:TextBox>
            </div>
            <label class="col-sm-2 control-label">
                Điện thoại
            </label>
            <div class="col-sm-4">
                <asp:TextBox ID="TextBoxPhone" runat="server" CssClass="form-control w-full"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="row box-title">
        <h4 class="m-l">
            <a data-toggle="collapse" href="#collapseOne" style="text-decoration: none; color: #676a6c;">
                Thông tin chi tiết<span class="pull-right"><i class="fa fa-chevron-down"></i></span></a>
        </h4>
    </div>
    <div id="collapseOne" class="panel-collapse collapse">
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-sm-2 control-label">
                    Tên viết tắt
                </label>
                <div class="col-sm-4">
                    <asp:TextBox ID="TextBoxDoanhNghiepID" runat="server" CssClass="form-control w-full"></asp:TextBox>
                </div>
                <label class="col-sm-2 control-label">
                    Tiếng Anh
                </label>
                <div class="col-sm-4">
                    <asp:TextBox ID="TextBoxDoanhNghiepNameEN" runat="server" CssClass="form-control w-full"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-sm-2 control-label">
                    Ngày thành lập
                </label>
                <div class="col-sm-4">
                    <div class="" id="data_ngaythanhlap_thongtindoanhnghiep">
                        <div class="input-group date">
                            <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                            <asp:TextBox ID="TextBoxNgayThanhLap" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <label class="col-sm-2 control-label">
                    Địa chỉ
                </label>
                <div class="col-sm-4" id="data_doanhnghiep_thanhlap">
                    <asp:TextBox ID="TextBoxDiaChi" runat="server" CssClass="form-control w-full"></asp:TextBox>
                </div>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanelPopupAddCatologie_on" runat="server" UpdateMode="Conditional"
            ChildrenAsTriggers="false">
            <ContentTemplate>
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-sm-2 control-label">
                            Tỉnh thành
                        </label>
                        <div class="col-sm-4">
                            <asp:DropDownList ID="DropDownListThanhPho" AutoPostBack="true" runat="server" CssClass="form-control w-full">
                            </asp:DropDownList>
                        </div>
                        <label class="col-sm-2 control-label">
                            Quận huyện
                        </label>
                        <div class="col-sm-4">
                            <asp:DropDownList ID="DropDownListQuanHuyen" runat="server" CssClass="form-control w-full">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="DropDownListThanhPho" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-sm-2 control-label">
                    Mã số thuế
                </label>
                <div class="col-sm-4">
                    <asp:TextBox ID="TextBoxMaSoThue" runat="server" CssClass="form-control w-full"></asp:TextBox>
                </div>
                <label class="col-sm-2 control-label">
                    Quốc gia</label>
                <div class="col-sm-4">
                    <asp:DropDownList ID="DropDownListQuocGia" runat="server" CssClass="form-control w-full">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-sm-2 control-label">
                    Fax</label>
                <div class="col-sm-4">
                    <asp:TextBox ID="TextBoxFax" runat="server" CssClass="form-control w-full"></asp:TextBox>
                </div>
                <label class="col-sm-2 control-label">
                    Quy Mô</label>
                <div class="col-sm-4">
                    <asp:DropDownList ID="DropDownListQuyMo" runat="server" CssClass="form-control w-full">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <%--<div class="form-horizontal">
            <div class="form-group">
              <label class="col-sm-2 control-label">
                                Trạng thái</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="DropDownListTrangThai" runat="server" CssClass="form-control w-full">
                                </asp:DropDownList>
                            </div>
                <label class="col-sm-2 control-label">
                                        Map</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="TextBoxGoogleMap" runat="server" CssClass="form-control w-full"></asp:TextBox>
                                    </div>
            </div>
        </div>--%>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-sm-2 control-label">
                    Giới thiệu</label>
                <div class="col-sm-10">
                    <div id="summernote_doanhnghiep_gioithieu_baongoai" class="h-editor-250">
                        <div id="summernote_doanhnghiep_gioithieu" runat="server" clientidmode="Static">
                        </div>
                    </div>
                    <asp:HiddenField ID="summernote_doanhnghiep_gioithieu_dulieu" runat="server" ClientIDMode="Static" />
                </div>
            </div>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-sm-2 control-label">
                    Ghi chú
                </label>
                <div class="col-sm-10">
                    <div id="summernote_doanhnghiep_ghichu_baongoai">
                        <div id="summernote_doanhnghiep_ghichu" runat="server" clientidmode="Static">
                        </div>
                    </div>
                    <asp:HiddenField ID="summernote_doanhnghiep_ghichu_dulieu" runat="server" ClientIDMode="Static" />
                </div>
            </div>
        </div>
        <div class="form-horizontal" id="DiveLogo" runat="server">
            <div class="form-group">
                <label class="col-sm-1 control-label">
                    Logo
                </label>
                <div class="col-sm-5">
                    <uc1:UploadFileDropxoneControl ID="UploadFileDropxoneControl1" runat="server" LoaiHinhAnh="3" />
                </div>
                <label class="col-sm-1 control-label">
                    Hình ảnh
                </label>
                <div class="col-sm-5">
                    <uc1:UploadFileDropxoneControl ID="UploadFileDropxoneControl2" runat="server" LoaiHinhAnh="1" />
                </div>
            </div>
        </div>
    </div>
    <div class="row box-title">
        <h4 class="m-l">
            <a data-toggle="collapse" href="#collapseTwo" style="text-decoration: none; color: #676a6c;">
                Thông tin liên hệ<span class="pull-right"><i class="fa fa-chevron-down"></i></span></a>
        </h4>
    </div>
    <div id="collapseTwo" class="panel-collapse collapse in">
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-sm-2 control-label">
                    Họ và tên
                </label>
                <div class="col-sm-1">
                    <asp:TextBox ID="TextBoxLienHeDanhXung" runat="server" CssClass="form-control w-full"
                        PlaceHolder="Ms/Mr/Mrs"></asp:TextBox>
                </div>
                <div class="p-l-none p-r-none col-sm-2 ">
                    <asp:TextBox ID="TextBoxLienHeHoLot" runat="server" CssClass="form-control w-full"
                        PlaceHolder="Họ, Tên đệm"></asp:TextBox>
                </div>
                <div class="p-l-none col-sm-1 ">
                    <asp:TextBox ID="TextBoxLienHeTen" runat="server" CssClass="form-control w-full"
                        PlaceHolder="Tên"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-sm-2 control-label">
                    Phòng ban
                </label>
                <div class="col-sm-4">
                    <asp:TextBox ID="TextBoxLienHePhongBan" runat="server" CssClass="form-control w-full"></asp:TextBox>
                </div>
                <label class="col-sm-2 control-label">
                    Chức danh</label>
                <div class="col-sm-4">
                    <asp:TextBox ID="TextBoxLienHeChucDanh" runat="server" CssClass="form-control w-full"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-sm-2 control-label">
                    Điện thoại
                </label>
                <div class="col-sm-4">
                    <asp:TextBox ID="TextBoxLienHePhone" runat="server" CssClass="form-control w-full"></asp:TextBox>
                </div>
                <label class="col-sm-2 control-label">
                    Email</label>
                <div class="col-sm-4">
                    <asp:TextBox ID="TextBoxLienHeEmail" runat="server" CssClass="form-control w-full"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-sm-2 control-label">
                    Địa chỉ</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="TextBoxLienHeDiaChi" runat="server" CssClass="form-control w-full"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-sm-2 control-label">
                    Ghi chú</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="TextBoxLienHeGhiChu" runat="server" CssClass="form-control w-full"
                        TextMode="MultiLine" Rows="3"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">

    function parseDate(input) {
        var parts = input.split('/');
        return new Date(parts[2], parts[1] - 1, parts[0]);
    }

    function IsEmail(email) {
        var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        return regex.test(email);
    }

    function IsNumbera(control) {
        var result = true;
        var testValue = control;
        testValue = testValue.toString().replace(/[ '.,]/g, "");
        if (testValue == "")
            return false;
        if (isNaN(testValue))
        { result = false; }
        return result;
    }




    function validation_tencongty() {
        if (!String.prototype.trim) {
            String.prototype.trim = function () {
                return this.replace(/^\s+|\s+$/g, '');
            };
        }
        saveGioiThieu();
        var TextBoxDoanhNghiepNameVN = document.getElementById('<%= TextBoxDoanhNghiepNameVN.ClientID %>');
        var TextBoxLienHeEmail = document.getElementById('<%= TextBoxLienHeEmail.ClientID %>');
        var TextBoxEmail = document.getElementById('<%= TextBoxEmail.ClientID %>');

        var TextBoxLienHePhone = document.getElementById('<%= TextBoxLienHePhone.ClientID %>');

        var meseges = "";
        var dateRegex = /^\d{1,2}\/\d{1,2}\/\d{4}$/;
        var fag = true;

        if (TextBoxEmail.value.trim().length != 0 && !IsEmail(TextBoxEmail.value.trim())) {

            meseges += 'Email công ty sai định dạng !\n';
            TextBoxEmail.style.background = "#FF0";
            fag = false;
        }

        if (TextBoxPhone.value.trim().length != 0 && !IsNumbera(TextBoxPhone.value.trim())) {

            meseges += 'Điện thoại công ty chỉ được nhập số !\n';
            TextBoxPhone.style.background = "#FF0";
            fag = false;
        }

        if (TextBoxLienHeEmail.value.trim().length != 0 && !IsEmail(TextBoxLienHeEmail.value.trim())) {

            meseges += 'Email người liên hệ sai định dạng !\n';
            TextBoxLienHeEmail.style.background = "#FF0";
            fag = false;
        }

        if (TextBoxDoanhNghiepNameVN.value.trim().length == 0) {

            meseges += 'Tên công ty chưa có !\n';
            TextBoxDoanhNghiepNameVN.style.background = "#FF0";
            fag = false;
        }
        if (meseges != "")
            alert(meseges);
        return fag;
    }
</script>
<script>
    function saveGioiThieu() {
        document.getElementById('summernote_doanhnghiep_gioithieu_dulieu').value = $('#summernote_doanhnghiep_gioithieu_baongoai .note-editor .note-editable').html();
        document.getElementById('summernote_doanhnghiep_ghichu_dulieu').value = $('#summernote_doanhnghiep_ghichu_baongoai .note-editor .note-editable').html();
    }
</script>
