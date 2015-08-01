<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlXetMienTruHocPhan.ascx.cs"
    Inherits="project.web.Page.MienGiamMon_21052015.FolderXetMienGiamHocPhan.ControlXetMienTruHocPhan" %>
<style>
    .isunsuccess {
        display: none;
    }

    .issuccess {
        display: block;
        float: left;
        font-size: 20px;
        padding-left: 4px;
        padding-top: 4px;
        width: 32px;
    }
</style>
<asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="UpdatePanelMienGiamHocPhan_on">
    <ProgressTemplate>
        <span style="position: fixed; z-index: 9999; top: 48%; left: 48%;">
            <img src="<%=ResolveUrl("~/") %>Resources/img/waiting.gif" alt="Vui lòng đợi..."
                height="80px" width="80px" /></span>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdateProgress ID="UpdateProgress2" runat="Server" AssociatedUpdatePanelID="UpdatePanelThongTinSinhVien">
    <ProgressTemplate>
        <span style="position: fixed; z-index: 9999; top: 48%; left: 48%;">
            <img src="<%=ResolveUrl("~/") %>Resources/img/waiting.gif" alt="Vui lòng đợi..."
                height="80px" width="80px" /></span>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanelThongTinSinhVien" runat="server" UpdateMode="Conditional"
    ChildrenAsTriggers="false">
    <ContentTemplate>
        <div class="search-form">
            <div class="input-group">
                <input type="text" placeholder="Tìm theo số báo danh (chính xác)" name="search" class="form-control input-lg"
                    runat="server" id="texboxKeySearch" />
                <div class="input-group-btn">
                    <button class="btn btn-lg btn-primary" type="submit" runat="server" id="buttonTimKiem">
                        Tìm kiếm
                    </button>
                </div>
            </div>
        </div>
        <asp:Panel runat="server" ID="panelInfo" Visible="false">
            <div class="info-member" align="center">
                <div class="center effect panel panel-primary">
                    <asp:HiddenField ID="hiddenFieldSinhVienGuidNam" runat="server" />
                    <%--<asp:HiddenField ID="hiddenFieldChuyenNganhGuid" runat="server" />--%>
                    <%-- <asp:HiddenField ID="hiddenFieldNienKhoaGuid" runat="server" />
                    <asp:HiddenField ID="hiddenFieldTrinhDoTaoGuid" runat="server" />
                    <asp:HiddenField ID="hiddenFieldHinhThucDaoTao" runat="server" />--%>
                    <div class="row">
                        <div class="col-sm-5">
                            <div class="">
                                Số báo danh
                            </div>
                        </div>
                        <div class="col-sm-7">
                            <div class="text-bold">
                                <asp:Literal ID="LiteralSBD" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-5">
                            <div class="">
                                Họ và tên
                            </div>
                        </div>
                        <div class="col-sm-7">
                            <div class="text-bold">
                                <asp:Literal ID="LiteralHoTen" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-5">
                            <div class="">
                                Ngày sinh
                            </div>
                        </div>
                        <div class="col-sm-7">
                            <div class="">
                                <asp:Literal ID="LiteralNgaySinh" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="display: none;">
                        <div class="col-sm-5">
                            <div class="">
                                Chuyên ngành
                            </div>
                        </div>
                        <div class="col-sm-7">
                            <div class="">
                                <asp:Literal ID="LiteralChuyenNganh" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-5">
                            <div class="">
                                Hình thức đào tạo
                            </div>
                        </div>
                        <div class="col-sm-7">
                            <div class="">
                                <asp:Literal ID="LiteralHinhThuc" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-5">
                            <div class="">
                                Trình độ đào tạo
                            </div>
                        </div>
                        <div class="col-sm-7">
                            <div class="">
                                <asp:Literal ID="LiteralTrinhDo" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-5">
                            <div class="">
                                Niên khóa
                            </div>
                        </div>
                        <div class="col-sm-7">
                            <div class="text-bold">
                                <asp:Literal ID="LiteralNienKhoa" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-sm-5">
                            <div class="">
                                Trường đã đào tạo
                            </div>
                        </div>
                        <div class="col-sm-7 form-group">
                            <div class="text-bold col-sm-10">
                                <asp:TextBox ID="txtTruongDaDaoTao" taget="txtTruongDaDaoTao1" runat="server" TabIndex="307" onchange="autosavethongtintruongnganhcu(this)" onkeydown="if (event.keyCode == 13){var tabindex = $(this).attr('tabindex');tabindex++;$('[tabindex=' + tabindex + ']').focus(); return false;}"></asp:TextBox>
                            </div>
                            <span id="txtTruongDaDaoTao1" class="isunsuccess col-sm-2"><i class="fa fa-check-circle text-navy"></i></span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-5">
                            <div class="">
                                Ngành đã tốt nghiệp
                            </div>
                        </div>
                        <div class="col-sm-7 form-group">
                            <div class="text-bold col-sm-10">
                                <asp:TextBox ID="txtNganhDaTotNghiep" taget="txtNganhDaTotNghiep1" runat="server" TabIndex="308" onchange="autosavethongtintruongnganhcu(this)" onkeydown="if (event.keyCode == 13){var tabindex = $(this).attr('tabindex');tabindex++;$('[tabindex=' + tabindex + ']').focus(); return false;}"></asp:TextBox>
                            </div>
                            <span id="txtNganhDaTotNghiep1" class="isunsuccess col-sm-2"><i class="fa fa-check-circle text-navy"></i></span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-5">
                            <div class="">
                                Trình độ đã đào tạo
                            </div>
                        </div>
                        <div class="col-sm-7 form-group">
                            <div class="text-bold col-sm-10">
                                <asp:TextBox ID="txtTrinhDoDaDaoTao" taget="txtTrinhDoDaDaoTao1" runat="server" TabIndex="309" onchange="autosavethongtintruongnganhcu(this)" onkeydown="if (event.keyCode == 13){var tabindex = $(this).attr('tabindex');tabindex++;$('[tabindex=' + tabindex + ']').focus(); return false;}"></asp:TextBox>
                            </div>
                            <span id="txtTrinhDoDaDaoTao1" class="isunsuccess col-sm-2"><i class="fa fa-check-circle text-navy"></i></span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-5">
                            <div class="">
                                Hình thức đã đào tạo
                            </div>
                        </div>
                        <div class="col-sm-7 form-group">
                            <div class="text-bold col-sm-10">
                                <asp:TextBox ID="txtHinhThucDaDaoTao" taget="txtHinhThucDaDaoTao1" runat="server" TabIndex="310" onchange="autosavethongtintruongnganhcu(this)" onkeydown="if (event.keyCode == 13){var tabindex = $(this).attr('tabindex');tabindex++;$('[tabindex=' + tabindex + ']').focus(); return false;}"></asp:TextBox>
                            </div>
                            <span id="txtHinhThucDaDaoTao1" class="isunsuccess col-sm-2"><i class="fa fa-check-circle text-navy"></i></span>
                        </div>
                    </div>
                </div>
            </div>
            <hr class="m-h-5" />
            <div id="RepeaterTable">
                <%--<p>Chuyên ngành</p>--%>
                <p>
                    <asp:Repeater ID="RepeaterDanhSachChuyenNganh" runat="server">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="HLinkChuyenNganh" Text='<%#Eval("ChuyenNganhName") %>'
                                CommandName="CHOISE" CommandArgument='<%#Eval("ChuyenNganhGuidDS") %>' CssClass="btn button-chuyenganh"
                                OnClientClick="chonChuyenNganhClient(this)">
                            </asp:LinkButton>
                            <%--OnClientClick="return chonChuyenNganhClient();"--%>
                        </ItemTemplate>
                    </asp:Repeater>
                </p>
                <div class="hr-line-dashed m-h-5">
                </div>
            </div>
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="buttonTimKiem" EventName="ServerClick" />
    </Triggers>
</asp:UpdatePanel>
<asp:UpdatePanel ID="UpdatePanelDanhSachChuyenSau" runat="server" UpdateMode="Conditional"
    ChildrenAsTriggers="false">
    <ContentTemplate>
        <div id="RepeaterTable1">
            <%--<asp:HiddenField ID="hiddenFieldChuyenSauGuid" runat="server" />--%>
            <asp:Panel ID="PanelListChuyenSau" runat="server" Visible="false">
                <%--<p>Hướng chuyên sâu</p>--%>
                <p>
                    <asp:Repeater ID="RepeaterDanhSachChuyenSau" runat="server">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="HLinkChuyenSau" Text='<%#Eval("ChuyenSauName") %>'
                                CommandName="CHOISE" CommandArgument='<%#Eval("ChuyenSauGuid") %>' CssClass="btn button-chuyensau"
                                OnClientClick="chonChuyenSauClient(this)"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:Repeater>
                </p>
                <hr class="m-h-5" />
            </asp:Panel>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="UpdatePanelMienGiamHocPhan_on" runat="server" UpdateMode="Conditional"
    ChildrenAsTriggers="false">
    <ContentTemplate>
        <asp:Panel ID="pnlChuongTrinhDaoTao" runat="server" TabIndex="311" Visible="false">
            <div id="RepeaterTableChuongTrinhDaoTao">
                <%--du lieu chuong trinh dao tao--%>
                <div class="ibox-content">
                    <div class="box-action">
                        <div class="pull-right">
                            <asp:LinkButton ID="LinkButtonShowMienGiam" runat="server" ToolTip="Show môn miễn giảm"
                                CssClass="btn btn-cancel"><i class="fa fa-eye"></i>&nbsp;Xem nhanh môn miễn giảm</asp:LinkButton>
                            <asp:LinkButton ID="btnSave" runat="server" ToolTip="Lưu làm mẫu" OnClientClick="return confirm('Bạn có chắc chắn muốn lưu trữ để làm mẫu?');"
                                CssClass="btn btn-add"><i class="fa fa-floppy-o"></i>&nbsp;Lưu trữ mẫu</asp:LinkButton>
                                <asp:LinkButton ID="btnLoadMau" runat="server" ToolTip="Load mẫu" OnClientClick="return confirm('Bạn có chắc chắn muốn load mẫu lên! mẫu sẽ thay thế hoàn toàn dữ liệu?');"
                                CssClass="btn btn-add"><i class="fa  fa-download"></i>&nbsp;Load mẫu</asp:LinkButton>
                            <asp:LinkButton ID="btnReset" runat="server" ToolTip="Nhập lại" OnClientClick="return confirm('Bạn có chắc chắn muốn nhập lại tất cả?');"
                                CssClass="btn btn-reset btn-sm"><i class="fa fa-rotate-left"></i>&nbsp;Nhập lại</asp:LinkButton>
                        </div>
                    </div>
                    <asp:HiddenField ID="HiddenFieldChuongTrinhDaoTaoGuid" runat="server" />
                    <div class="table-responsive  table-mienmon">
                        <table class="table table-hover no-margins">
                            <thead>
                                <tr class="table-header">
                                    <td class="text-center w-50">STT
                                    </td>
                                    <td>Mã HP
                                    </td>
                                    <td>Tên học phần
                                    </td>
                                    <td class="text-center">Số tín chỉ
                                    </td>
                                    <td class="text-center" style="width: 330px;">Học phần đã học
                                    </td>
                                    <%-- <td class="text-center w-100">
                                        Điểm
                                    </td>--%>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="RepeaterXetMienGiam" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <asp:Literal ID="LieteralNoiDungCT" runat="server"></asp:Literal>
                                            <asp:HiddenField ID="hiddenFieldSinhVienGuid" runat="server" Value='<%#Eval("SinhVienGuid") %>' />
                                            <asp:HiddenField ID="hiddenFieldMonHocGuid" runat="server" Value='<%#Eval("MonHocGuid") %>' />
                                            <asp:HiddenField ID="hiddenFieldLoaiMonHocGuid" runat="server" Value='<%#Eval("LoaiMonHoc") %>' />
                                            <td id="tdtextbox" runat="server">
                                                <div class="input-group w-full">
                                                    <asp:TextBox runat="server" ID="txtMonDaHoc" CssClass="form-control input-sm" placeholder="Môn 1-điểm; Môn 2-điểm..."
                                                        onkeydown="if (event.keyCode == 13){var tabindex = $(this).attr('tabindex');tabindex++;$('[tabindex=' + tabindex + ']').focus(); return false;}"></asp:TextBox>
                                                    <div class="input-group-btn">
                                                        <span id="txtMonDaHoc1" class="isunsuccess" runat="server"><i id="iconchecktt" class="fa fa-check-circle text-navy"></i></span>
                                                    </div>
                                                </div>
                                            </td>
                                            <%--<td>
                                                <asp:TextBox runat="server" ID="txtDiem" CssClass="form-control input-sm w-full"
                                                    onkeydown="if (event.keyCode == 13){var tabindex = $(this).attr('tabindex');tabindex++;$('[tabindex=' + tabindex + ']').focus(); return false;}"></asp:TextBox>
                                            </td>--%>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="buttonTimKiem" EventName="ServerClick" />
        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnReset" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="LinkButtonShowMienGiam" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>
<script type="text/javascript">
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
</script>
<script type="text/javascript" language="javascript">

    function OnTextChangeEvent(sinhvienguid, monhocguid, loaiMonHoc, nhomMonHoc, element) {
        var txtbox = document.getElementById(element);

        var valueS = txtbox.value;
        var urlsv = "SerChuongTrinhDaoTao.asmx/SaveMienGiamHocPhan";
        var payload = '{ "monhocGuid":"' + monhocguid + '","sinhVienGuid":"' + sinhvienguid + '","loaiMonHocGuid":"' + loaiMonHoc + '","nhomMonHocGuid":"' + nhomMonHoc + '","Values":"' + valueS + '"}';
        $.ajax({
            type: "POST",
            url: urlsv,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: payload,
            success: function (data) {
                if (data.d == 0) {
                    $("#" + element + "1").removeClass('isunsuccess');
                    $("#" + element + "1").addClass('issuccess');

                    $("#" + element + "1" + " i[id*='iconchecktt']").removeClass('fa-times-circle text-danger');
                    $("#" + element + "1" + " i[id*='iconchecktt']").removeClass('text-navy fa-check-circle');
                    $("#" + element + "1" + " i[id*='iconchecktt']").addClass('fa-times-circle text-danger');
                    // alert("Lỗi! chuyển đổi dữ liệu lỗi hoặc không có kết nối internet. Vui lòng liên hệ quản trị để xử lý xự cố");
                } else {

                    if (data.d == 2) {
                        $("#" + element + "1").removeClass('issuccess');
                        $("#" + element + "1").addClass('isunsuccess');
                        return;
                    }
                    if (data.d != 4) {
                        $("#" + element + "1").removeClass('isunsuccess');
                        $("#" + element + "1").addClass('issuccess');

                        $("#" + element + "1" + " i[id*='iconchecktt']").removeClass('text-navy fa-check-circle');
                        $("#" + element + "1" + " i[id*='iconchecktt']").removeClass('fa-times-circle text-danger');
                        $("#" + element + "1" + " i[id*='iconchecktt']").addClass('text-navy fa-check-circle');
                    }
                }
            },
            error: function (xmlHttpRequest, textStatus, errorThrown) {
                alert("Lỗi! chuyển đổi dữ liệu lỗi hoặc không có kết nối internet. Vui lòng liên hệ quản trị để xử lý xự cố");
                console.log(xmlHttpRequest.responseText);
                console.log(textStatus);
                console.log(errorThrown);
            }
        });
    }
    function chonChuyenNganhClient(element) {

        $("#RepeaterTable a[id*='HLinkChuyenNganh']").each(function (index) {
            $(this).removeClass('button-chuyenganh-active');
            $(this).addClass('button-chuyenganh');
        });

        $(element).removeClass('button-chuyenganh');
        $(element).addClass('button-chuyenganh-active');
    }

    function chonChuyenSauClient(element) {
        $("#RepeaterTable1 a[id*='HLinkChuyenSau']").each(function (index) {
            $(this).removeClass('button-chuyensau-active');
            $(this).addClass('button-chuyensau');
        });

        $(element).removeClass('button-chuyensau');
        $(element).addClass('button-chuyensau-active');
    }

    function setAll() {
        $("#RepeaterTableChuongTrinhDaoTao input[id*='txtMonDaHoc']").each(function (index) {
            if (this.value != "") {
                $("#" + this.id + "1").removeClass('isunsuccess');
                $("#" + this.id + "1").addClass('issuccess');
            }
        });
    }

    function autosavethongtintruongnganhcu(element) {

        var _sinhvienguid = $("#<%= hiddenFieldSinhVienGuidNam.ClientID %>").val();
        var _truongdadaotao = $("#<%= txtTruongDaDaoTao.ClientID %>").val();
        var _nganhdahoc = $("#<%= txtNganhDaTotNghiep.ClientID %>").val();
        var _trinhdodaotao = $("#<%= txtTrinhDoDaDaoTao.ClientID %>").val();
        var _hinhthucdaotao = $("#<%= txtHinhThucDaDaoTao.ClientID %>").val();

        var urlsv = "SerChuongTrinhDaoTao.asmx/autosavethongtintruongnganhcu";
        var payload = '{ "sinhvienguid":"' + _sinhvienguid + '","truongdadaotao":"' + _truongdadaotao + '","nganhdahoc":"' + _nganhdahoc + '","trinhdodaotao":"' + _trinhdodaotao + '","hinhthucdaotao":"' + _hinhthucdaotao + '"}';
        $.ajax({
            type: "POST",
            url: urlsv,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: payload,
            success: function (data) {
                if (data.d == "False") {
                    alert("Lỗi! không thực hiện lưu trữ được. Vui lòng liên hệ quản trị để xử lý xự cố");
                } else {
                    $("#" + $(element).attr("taget")).removeClass('isunsuccess');
                    $("#" + $(element).attr("taget")).addClass('issuccess');
                }
            },
            error: function (xmlHttpRequest, textStatus, errorThrown) {
                alert("Lỗi! chuyển đổi dữ liệu lỗi hoặc không có kết nối internet. Vui lòng liên hệ quản trị để xử lý xự cố");
                console.log(xmlHttpRequest.responseText);
                console.log(textStatus);
                console.log(errorThrown);
            }
        });
    }

</script>
