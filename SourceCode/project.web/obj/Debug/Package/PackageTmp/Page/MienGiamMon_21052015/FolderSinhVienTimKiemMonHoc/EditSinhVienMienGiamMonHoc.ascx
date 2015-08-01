<%--   
Author:					Nguyen Thanh Dai
Created:				2015-6-9
Last Modified:			2015-6-9
--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditSinhVienMienGiamMonHoc.ascx.cs"
    Inherits="project.web.EditSinhVienMienGiamMonHoc" %>
<%--Luu y phai dat id popup o ngoai de khong bi an khi thao tac xong--%>
<div id="ts-popup-editdulieusinhvien" class="bigbox-600">
    <div class="panel panel-default panel-popup">
        <div class="panel-heading">
            <h3 class="panel-title">
                Chỉnh sửa thông tin sinh viên</h3>
        </div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="UpdatePanelPopupAddSinhVien_on">
            <ProgressTemplate>
                <span style="position: fixed; z-index: 9999; top: 48%; left: 48%;">
                    <img src="<%=ResolveUrl("~/") %>Resources/img/waiting.gif" alt="Vui l?ng ??i..."
                        height="80px" width="80px" /></span>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanelPopupAddSinhVien_on" runat="server" UpdateMode="Conditional"
            ChildrenAsTriggers="false">
            <ContentTemplate>
                <div class="panel-body">
                    <asp:Literal ID="LiteralSinhVienGuid" Visible="false" runat="server"></asp:Literal>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="">
                                Tên sinh viên
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="form-group w-full">
                                <asp:TextBox ID="TextBoxSinhVienName" runat="server" CssClass="w-full"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="">
                                Ngày sinh
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="form-group w-full">
                                <ajaxToolkit:CalendarExtender ID="calensff" runat="server" TargetControlID="TextBoxNgaySinh">
                                </ajaxToolkit:CalendarExtender>
                                <asp:TextBox ID="TextBoxNgaySinh" runat="server" CssClass="w-full"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="">
                                Địa chỉ
                            </div>
                        </div>
                        <div class="col-md-8 ">
                            <div class="form-group w-full">
                                <asp:TextBox ID="TextBoxDiaChi" runat="server" CssClass="w-full" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="">
                                Điện thoại
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="form-group w-full">
                                <asp:TextBox ID="TextBoxDienThoai" runat="server" CssClass="w-full"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="">
                                Trường đã đào tạo
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="form-group w-full">
                                <asp:TextBox ID="TextBoxTruongDaDaoTao" runat="server" CssClass="w-full"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="">
                                Ngành đã đào tạo
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="form-group w-full">
                                <asp:TextBox ID="TextBoxNganhDaDaoTao" runat="server" CssClass="w-full"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="">
                                Hình thức đã đào tạo
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="form-group w-full">
                                <asp:TextBox ID="TextBoxHinhThucDaDaoTao" runat="server" CssClass="w-full"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="">
                                Trình độ đã đào tạo
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="form-group w-full">
                                <asp:TextBox ID="TextBoxTrinhDoDaDaoTao" runat="server" CssClass="w-full"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-footer">
                    <div class="text-center">
                        <asp:LinkButton ID="ButtonSave" runat="server" OnClientClick="return validation_luuthongtincapnhatsinhvienmiengiammonhoc()" ToolTip="Lưu" CssClass="btn btn-add btn-sm"><i class="glyphicon glyphicon-floppy-saved"></i>&nbsp;Lưu trữ</asp:LinkButton>&nbsp;
                        <asp:LinkButton ID="ButtonReset" runat="server" ToolTip="Reset" CssClass="btn btn-reset btn-sm"><i class="glyphicon glyphicon-repeat"></i>&nbsp;Nhập lại</asp:LinkButton>
                        <asp:LinkButton ID="ButtonExit" runat="server" ToolTip="Hủy" CssClass="btn btn-link btn-cancel btn-sm">&nbsp;Hủy thao tác</asp:LinkButton>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ButtonSave" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="ButtonExit" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="ButtonReset" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>

<script language="Javascript">
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
    function parseDate(input) {
        var parts = input.split('/');
        return new Date(parts[2], parts[1] - 1, parts[0]);
    }

    function isNumber(n) {
        return !isNaN(parseFloat(n)) && isFinite(n);
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

    function validation_luuthongtincapnhatsinhvienmiengiammonhoc() {
        if (!String.prototype.trim) {
            String.prototype.trim = function () {
                return this.replace(/^\s+|\s+$/g, '');
            };
        }

        var TextBoxNgaySinh = document.getElementById('<%= TextBoxNgaySinh.ClientID %>');
        var TextBoxSinhVienName = document.getElementById('<%= TextBoxSinhVienName.ClientID %>');


        var meseges = "";
        var dateRegex = /^\d{1,2}\/\d{1,2}\/\d{4}$/;
        var fag = true;


//        if (!isDate(TextBoxNgaySinh.value) && TextBoxNgaySinh.value.trim().length != 0) {

//            meseges += 'Ngày sinh không đúng định dạng !\n';
//            TextBoxNgaySinh.style.background = "#FF0";
//            fag = false;
//        }
        if (TextBoxSinhVienName.value.trim().length == 0) {

            meseges += 'Tên sinh viên không được bỏ trống !\n';
            TextBoxSinhVienName.style.background = "#FF0";
            fag = false;
        }
        if (meseges != "")
            alert(meseges);
        return fag;
    }


</script>
