<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlThemThucTap.ascx.cs"
    Inherits="project.web.Page._10042014_HDHTDoanhNghiep.FolderQuanLyHopTac.ControlThemThucTap" %>
<%@ Register Src="~/Page/FolderUploadFile/UploadFileDropxoneControl.ascx" TagName="UploadFileDropxoneControl"
    TagPrefix="uc1" %>
<%@ Register Src="~/Page/FolderUploadFile/UploadFileAttachDropxoneControl.ascx" TagName="UploadFileAttachDropxoneControl"
    TagPrefix="uc2" %>
<div class="box-action">
    <span class="pull-left"><span class="lbl-valid p-r-5">(*)</span><span class="text-italic">Thông
        tin bắt buộc phải nhập</span> </span>
    <div class="pull-right">
        <asp:LinkButton ID="buttonLuuTru" runat="server" ToolTip="Lưu trữ" CssClass="btn btn-add"
            OnClientClick="return validation_thongtinthuctap()"><i
                        class="fa fa-floppy-o"></i>&nbsp;Lưu trữ</asp:LinkButton>&nbsp;hoặc&nbsp;
        <asp:LinkButton ID="buttonThoat" runat="server" ToolTip="Thoát" class="btn btn-link btn-cancel btn-sm"> Hủy thao tác</asp:LinkButton>
    </div>
</div>
<div class="wrapper animated fadeInRight">
    <div class="row box-title">
        <h4 class="m-l">
            Thông tin thực tập
        </h4>
    </div>
    <div class="form-horizontal">
        <div class="form-group">
            <label class="col-sm-2 control-label">
                Mã số<span class="lbl-valid">(*)</span>
            </label>
            <div class="col-sm-4">
                <asp:HiddenField ID="HiddenFieldThongTinHopTacGuid" runat="server" />
                <asp:TextBox runat="server" ID="txtMaSo" class="form-control w-full"></asp:TextBox>
                <div id="error_txtMaSo">
                    <%--dung cho validate ko xoa--%>
                </div>
            </div>
            <label class="col-sm-2 control-label">
                Đối tượng
            </label>
            <div class="col-sm-4">
                <div>
                    <div class="input-group p-b-5">
                        <select id="selectBoxtt" name="selectBox" class="form-control w-full">
                        </select>
                        <span class="input-group-btn">
                            <asp:Button ID="AddDoiTuong" OnClientClick="return AddDoiTuongClickThucTap()" Text="Thêm"
                                runat="server" CssClass="btn btn-add btn-sm" />
                        </span>
                    </div>
                    <div id="region_DoiTuong">
                        <asp:Literal ID="LiteralDoiTuong" runat="server"></asp:Literal>
                    </div>
                    <asp:HiddenField runat="server" ID="HiddenFieldDoiTuongValue"></asp:HiddenField>
                    <asp:HiddenField runat="server" ID="HiddenFieldDoiTuongName"></asp:HiddenField>
                </div>
            </div>
        </div>
    </div>
    <div class="form-horizontal">
        <div class="form-group">
            <label class="col-sm-2 control-label">
                Số lượng<span class="lbl-valid">(*)</span>
            </label>
            <div class="col-sm-4">
                <asp:TextBox ID="TextBoxSoLuong" runat="server" CssClass="form-control w-full"></asp:TextBox>
                <div id="error_TextBoxSoLuong">
                    <%--dung cho validate ko xoa--%>
                </div>
            </div>
            <label class="col-sm-2 control-label">
                Lương
            </label>
            <div class="col-sm-4">
                <asp:TextBox ID="TextBoxLuong" runat="server" CssClass="form-control w-full"></asp:TextBox>
                <div id="error_TextBoxLuong">
                    <%--dung cho validate ko xoa--%>
                </div>
            </div>
        </div>
    </div>
    <div class="form-horizontal">
        <div class="form-group">
            <label class="col-sm-2 control-label">
                Hình thức làm việc
            </label>
            <div class="col-sm-4">
                <asp:DropDownList ID="ddlHinhThucLamViec" runat="server" CssClass="form-control w-full">
                </asp:DropDownList>
            </div>
            <label class="col-sm-2 control-label">
                Nơi làm
            </label>
            <div class="col-sm-4">
                <asp:TextBox runat="server" ID="TextBoxNoiLam" CssClass="form-control w-full"></asp:TextBox>
            </div>
        </div>
    </div>
    <%--<div class="form-horizontal">
        <div class="form-group">
            <label class="col-sm-2 control-label">
                Quyền lợi</label>
            <div class="col-sm-10">
                <asp:TextBox ID="TextBoxQuyenLoi" runat="server" CssClass="form-control w-full"
                    TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
    </div>--%>
    <div class="form-horizontal">
        <div class="form-group">
            <label class="col-sm-2 control-label">
                Từ ngày<span class="lbl-valid">(*)</span>
            </label>
            <div class="col-sm-4">
                <div class="" id="data_thuctap_TextBoxTuNgay">
                    <div class="input-group date">
                        <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                        <asp:TextBox runat="server" ID="TextBoxTuNgay" CssClass="form-control w-full" data-mask="99/99/9999" />
                        <%--dung cho validate ko xoa--%>
                    </div>
                </div>
                <div id="error_TextBoxTuNgay" class="text-danger">
                </div>
            </div>
            <label class="col-sm-2 control-label">
                Đến ngày<span class="lbl-valid">(*)</span>
            </label>
            <div class="col-sm-4">
                <div class="" id="data_thuctap_TextBoxDenNgay">
                    <div class="input-group date">
                        <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                        <asp:TextBox runat="server" ID="TextBoxDenNgay" CssClass="form-control w-full" data-mask="99/99/9999" />
                        <%--dung cho validate ko xoa--%>
                    </div>
                </div>
                <div id="error_TextBoxDenNgay" class="text-danger">
                </div>
            </div>
        </div>
    </div>
    <div class="form-horizontal">
        <div class="form-group">
            <label class="col-sm-2 control-label">
                Mô tả
            </label>
            <div class="col-sm-10">
                <div id="summernote_thuctap_mota_baongoai">
                    <div id="summernote_thuctap_mota" runat="server" clientidmode="Static">
                    </div>
                </div>
                <asp:HiddenField ID="summernote_thuctap_mota_dulieu" runat="server" ClientIDMode="Static" />
            </div>
        </div>
    </div>
    <div id="panelFile" runat="server" visible="false">
        <div class="row box-title">
            <h4 class="m-l">
                <a data-toggle="collapse" href="#collapseOne3" style="text-decoration: none; color: #676a6c;">
                    File minh chứng<span class="pull-right"><i class="fa fa-chevron-down"></i></span></a></h4>
        </div>
        <div id="collapseOne3" class="panel-collapse collapse in">
            <div class="row">
                <div class="col-sm-6">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="col-sm-12">
                                <uc2:UploadFileAttachDropxoneControl ID="UploadFileAttachDropxoneControl1" LoaiHinhAnh="5"
                                    runat="server" />
                            </div>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="UpDatecollapseOne2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">
                                        Tiêu đề<span class="lbl-valid">(*)</span>
                                    </label>
                                    <div class="col-sm-10">
                                        <asp:TextBox runat="server" ID="TextBoxTieuDeVanBan" CssClass="form-control w-full" />
                                        <div id="error_TextBoxTieuDeVanBan">
                                            <%--dung cho validate ko xoa--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">
                                        Số VB
                                    </label>
                                    <div class="col-sm-4">
                                        <asp:TextBox runat="server" ID="TextBoxSoVanBan" CssClass="form-control w-full" />
                                    </div>
                                    <label class="col-sm-2 control-label">
                                        Người ký
                                    </label>
                                    <div class="col-sm-4">
                                        <asp:TextBox runat="server" ID="TextBoxNguoiKy" CssClass="form-control w-full" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">
                                        Trích dẫn
                                    </label>
                                    <div class="col-sm-10">
                                        <asp:TextBox runat="server" ID="TextBoxTrichDan" CssClass="form-control w-full" Style="height: 85px"
                                            TextMode="MultiLine" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">
                                        Ngày ký<span class="lbl-valid">(*)</span>
                                    </label>
                                    <div class="col-sm-4">
                                        <div class="" id="data_thuctap_ngaykyfile">
                                            <div class="input-group date">
                                                <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                                <asp:TextBox runat="server" ID="TextBoxNgayKy" CssClass="form-control w-full" />
                                            </div>
                                        </div>
                                        <div id="error_TextBoxNgayKy" class="text-danger">
                                            <%--dung cho validate ko xoa--%>
                                        </div>
                                    </div>
                                    <label class="col-sm-2 control-label">
                                        Thời hạn</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox runat="server" ID="TextBoxThoiHan" CssClass="form-control w-full" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-sm-12">
                                        <div class="pull-right">
                                            <asp:Button runat="server" ID="buttonThemFile" CssClass="btn btn-primary btn-sm"
                                                Text="Thêm file" OnClientClick="return validation_thongtinthuctapfile()" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="col-sm-6">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Repeater ID="RepeaterListFile" runat="server">
                                <ItemTemplate>
                                    <div class="file-box">
                                        <div class="file">
                                            <a id="a_FileName" runat="server"><span class="corner"></span>
                                                <div class="icon">
                                                    <i class='fa fa-file'></i>
                                                </div>
                                                <div class="file-name">
                                                    <%# Eval("ClientFileName")%>
                                                    <br />
                                                    <small>
                                                        <%# Eval("NgayKy")%></small>
                                                    <br />
                                                    <small>
                                                        <asp:LinkButton ID="LinkButtonDelete" runat="server" CommandName="DEL" CommandArgument='<%# Eval("FileAttachGuid")%>'
                                                            Text='Xóa file'></asp:LinkButton>
                                                    </small>
                                                </div>
                                            </a>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="RepeaterListFile" EventName="ItemCommand" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <div id="panelHinhAnh" runat="server" visible="false">
        <div class="row box-title">
            <h4 class="m-l">
                <a data-toggle="collapse" href="#collapseOne13" style="text-decoration: none; color: #676a6c;">
                    Hình ảnh hoạt động<span class="pull-right"><i class="fa fa-chevron-down"></i></span></a></h4>
        </div>
        <div id="collapseOne13" class="panel-collapse collapse">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-sm-12">
                        <uc1:UploadFileDropxoneControl ID="UploadFileDropxoneControl1" runat="server" LoaiHinhAnh="4" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<script language="javascript">
    var dtCh = "/";
    var minYear = 1900;
    var maxYear = 2100;
    function isInteger(s) {
        var i;
        for (i = 0; i < s.length; i++) {
            // Check that current character is number.
            var c = s.charAt(i);
            if (((c < "0") || (c > "9"))) return false;
        }
        // All characters are numbers.
        return true;
    }
    function stripCharsInBag(s, bag) {
        var i;
        var returnString = "";
        // Search through string's characters one by one.
        // If character is not in bag, append to returnString.
        for (i = 0; i < s.length; i++) {
            var c = s.charAt(i);
            if (bag.indexOf(c) == -1) returnString += c;
        }
        return returnString;
    }
    function daysInFebruary(year) {
        // February has 29 days in any year evenly divisible by four,
        // EXCEPT for centurial years which are not also divisible by 400.
        return (((year % 4 == 0) && ((!(year % 100 == 0)) || (year % 400 == 0))) ? 29 : 28);
    }
    function DaysArray(n) {
        for (var i = 1; i <= n; i++) {
            this[i] = 31
            if (i == 4 || i == 6 || i == 9 || i == 11) { this[i] = 30 }
            if (i == 2) { this[i] = 29 }
        }
        return this
    }
    function isDate(dtStr) {
        var daysInMonth = DaysArray(12)
        var pos1 = dtStr.indexOf(dtCh)
        var pos2 = dtStr.indexOf(dtCh, pos1 + 1)
        var strDay = dtStr.substring(0, pos1)
        var strMonth = dtStr.substring(pos1 + 1, pos2)
        var strYear = dtStr.substring(pos2 + 1)
        strYr = strYear
        if (strDay.charAt(0) == "0" && strDay.length > 1) strDay = strDay.substring(1)
        if (strMonth.charAt(0) == "0" && strMonth.length > 1) strMonth = strMonth.substring(1)
        for (var i = 1; i <= 3; i++) {
            if (strYr.charAt(0) == "0" && strYr.length > 1) strYr = strYr.substring(1)
        }
        month = parseInt(strMonth)
        day = parseInt(strDay)
        year = parseInt(strYr)
        if (pos1 == -1 || pos2 == -1) {
            // alert("The date format should be : dd/mm/yyyy")
            return false
        }
        if (strMonth.length < 1 || month < 1 || month > 12) {
            //  alert("Please enter a valid month")
            return false
        }
        if (strDay.length < 1 || day < 1 || day > 31 || (month == 2 && day > daysInFebruary(year)) || day > daysInMonth[month]) {
            // alert("Please enter a valid day")
            return false
        }
        if (strYear.length != 4 || year == 0 || year < minYear || year > maxYear) {
            // alert("Please enter a valid 4 digit year between " + minYear + " and " + maxYear)
            return false
        }
        if (dtStr.indexOf(dtCh, pos2 + 1) != -1 || isInteger(stripCharsInBag(dtStr, dtCh)) == false) {
            // alert("Please enter a valid date")
            return false
        }
        return true
    }
</script>
<script type="text/javascript">

    function parseDate_hotro(input) {
        var parts = input.split('/');
        return new Date(parts[2], parts[1] - 1, parts[0]);
    }
    function validateIsNumber(control) {
        var result = true;
        var testValue = control.value;
        testValue = testValue.toString().replace(/[ '.,]/g, "");
        if (testValue == "")
            return false;
        if (isNaN(testValue))
        { result = false; }
        return result;
    }
    function validation_thongtinthuctap() {
        if (!String.prototype.trim) {
            String.prototype.trim = function () {
                return this.replace(/^\s+|\s+$/g, '');
            };
        }
        savethuctapmota();
        var txtMaSo = document.getElementById('<%= txtMaSo.ClientID %>');
        var TextBoxSoLuong = document.getElementById('<%= TextBoxSoLuong.ClientID %>');
        var TextBoxLuong = document.getElementById('<%= TextBoxLuong.ClientID %>');
        var TextBoxTuNgay = document.getElementById('<%= TextBoxTuNgay.ClientID %>');
        var TextBoxDenNgay = document.getElementById('<%= TextBoxDenNgay.ClientID %>');


        var meseges = "";
        var dateRegex = /^\d{1,2}\/\d{1,2}\/\d{4}$/;
        var fag = true;
        var fDate = null;
        var cDate = null;

        if (txtMaSo.value == "") {
            $("#error_txtMaSo").html("<small><i>yêu cầu nhập <b>không để trống</b></i></small>");
            txtMaSo.style.background = "#FF0";
            fag = false;
        }
        if (TextBoxSoLuong.value == "") {
            $("#error_TextBoxSoLuong").html("<small><i>yêu cầu nhập <b>không để trông</b></i></small>");
            TextBoxSoLuong.style.background = "#FF0";
            fag = false;
        }
        if (TextBoxLuong.value == "") {
            $("#error_TextBoxLuong").html("<small><i>yêu cầu nhập <b>không để trông</b></i></small>");
            TextBoxLuong.style.background = "#FF0";
            fag = false;
        }
        if (!isDate(TextBoxTuNgay.value)) {
            $("#error_TextBoxTuNgay").html("<small><i>yêu cầu nhập <b>dd/mm/yyyy</b></i></small>");
            TextBoxTuNgay.style.background = "#FF0";
            fag = false;
        }
        if (!isDate(TextBoxDenNgay.value)) {
            $("#error_TextBoxDenNgay").html("<small><i>yêu cầu nhập <b>dd/mm/yyyy</b></i></small>");
            TextBoxDenNgay.style.background = "#FF0";
            fag = false;
        }
        else {
            fDate = parseDate(TextBoxTuNgay.value);
            cDate = parseDate(TextBoxDenNgay.value);
            if (fDate > cDate) {
                $("#error_TextBoxTuNgay").html("<small><i>lỗi ngày bắt đầu <b>lớn hơn</b> kết thúc</i></small>");
                $("#error_TextBoxDenNgay").html("<small><i>lỗi ngày kết thúc <b>nhỏ hơn</b> bắt đầu</i></small>");
                TextBoxTuNgay.style.background = "#FF0";
                TextBoxDenNgay.style.background = "#FF0";
                fag = false;
            }
        }
        return fag;
    }

    function validation_thongtinthuctapfile() {
        if (!String.prototype.trim) {
            String.prototype.trim = function () {
                return this.replace(/^\s+|\s+$/g, '');
            };
        }

        var TextBoxTieuDeVanBan = document.getElementById('<%= TextBoxTieuDeVanBan.ClientID %>');
        var TextBoxNgayKy = document.getElementById('<%= TextBoxNgayKy.ClientID %>');


        var meseges = "";
        var dateRegex = /^\d{1,2}\/\d{1,2}\/\d{4}$/;
        var fag = true;

        if (TextBoxTieuDeVanBan.value == "") {
            $("#error_TextBoxTieuDeVanBan").html("<small><i>yêu cầu nhập <b>tiêu đề</b></i></small>");
            TextBoxTieuDeVanBan.style.background = "#FF0";
            fag = false;
        }
        if (!isDate(TextBoxNgayKy.value)) {
            $("#error_TextBoxNgayKy").html("<small><i>yêu cầu nhập <b>dd/mm/yyyy</b></i></small>");
            TextBoxNgayKy.style.background = "#FF0";
            fag = false;

        }
        return fag;
    }
//    $(document).ready(function () {
//        LoadDataCatologieThucTap();
//    });

    function AddDoiTuongClickThucTap() {
        var HiddenFieldDoiTuongValue = document.getElementById('<%= HiddenFieldDoiTuongValue.ClientID %>');
        var HiddenFieldDoiTuongName = document.getElementById('<%=  HiddenFieldDoiTuongName.ClientID %>');
        var strValue = $('#selectBoxtt').val();
        var strText = $('#selectBoxtt :selected').text();
        var lastValue = HiddenFieldDoiTuongValue.value;
        var lastText = HiddenFieldDoiTuongName.value;
        if (strText != "") {

            if (lastValue != "") {
                $("#region_DoiTuong").append("<span class='chuongtvdiv badge'><i>" + strText + "</i></span>");
                HiddenFieldDoiTuongValue.value = lastValue + ";" + strValue;
                HiddenFieldDoiTuongName.value = lastText + ";" + strText;
            }
            else {
                HiddenFieldDoiTuongValue.value = strValue;
                HiddenFieldDoiTuongName.value = strText;
                $("#region_DoiTuong").append("<div class='chuongtvdiv'><button type='button' class='btn btn-outline btn-danger btn-sm' onclick=\"DeleteDoiTuongThucTap()\"><i class='fa fa-trash'>&nbsp;Xóa tất cả</i></button></div>");
                $("#region_DoiTuong").append("<span class='chuongtvdiv badge'><i>" + strText + "</i></span>");
            }
            $('#selectBoxtt option[value=' + strValue + ']').remove();
        }
        return false;
    }

    function DeleteDoiTuongThucTap() {
        var HiddenFieldDoiTuongValue = document.getElementById('<%= HiddenFieldDoiTuongValue.ClientID %>');
        var HiddenFieldDoiTuongName = document.getElementById('<%=  HiddenFieldDoiTuongName.ClientID %>');
        $("div").remove(".chuongtvdiv");
        $("span").remove(".chuongtvdiv");
        LoadDataCatologieThucTap();
        HiddenFieldDoiTuongValue.value = "";
        HiddenFieldDoiTuongName.value = "";
    }
</script>
<script>
    function savethuctapmota() {
        document.getElementById('summernote_thuctap_mota_dulieu').value = $('#summernote_thuctap_mota_baongoai .note-editor .note-editable').html();
    }
</script>
