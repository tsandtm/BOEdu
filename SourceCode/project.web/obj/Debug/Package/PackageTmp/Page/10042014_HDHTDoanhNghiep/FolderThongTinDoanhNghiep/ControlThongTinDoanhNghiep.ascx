<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlThongTinDoanhNghiep.ascx.cs"
    Inherits="project.web.Page._10042014_HDHTDoanhNghiep.FolderThongTinDoanhNghiep.ControlThongTinDoanhNghiep" %>
<div class="ibox-content float-e-margins">
    <div class="ibox-title">
        <h5>
            Thông tin doanh nghiệp</h5>
        <div class="ibox-tools">
            <a href="#" title="Tác vụ" data-toggle="dropdown" class="dropdown-toggle" aria-expanded="true"><i
                class="fa fa-wrench"></i></a>
            <ul class="dropdown-menu dropdown-user">
                <li><a onclick="OnclickTab('HB')">Học bổng</a> </li>
                <li><a onclick="OnclickTab('HT')">Tài trợ</a> </li>
                <li><a onclick="OnclickTab('TT')">Thực tập</a> </li>
                <li><a onclick="OnclickTab('TD')">Tuyển dụng</a> </li>
            </ul>
        </div>
    </div>
    <%--logo doanh nghiệp--%>
    <div class="no-padding b-none border-left-right text-center div-logoCompany">
        <a onclick="OnclickTab('CB')">
            <img alt="Nhấn để vào thông tin chi tiết doanh nghiệp" class="img-responsive img-logoCompany"
                runat="server" id="imageLogo">
        </a>
    </div>
    <div class=" profile-content">
        <%--Thông tin doanh nghiệp--%>
        <h4>
            <strong>
                <asp:Label runat="server" ID="lblCongTyName"></asp:Label></strong></h4>
        <p>
            <i class="fa fa-map-marker"></i>&nbsp&nbsp <a id="maptagA" runat="server" target="_blank">
            </a>
        </p>
        <p>
            <i class="fa fa-envelope"></i>&nbsp
            <asp:Label runat="server" ID="lblEmail"></asp:Label></p>
        <p>
            <i class="fa fa-phone"></i>&nbsp&nbsp
            <asp:Label runat="server" ID="lblPhone"></asp:Label></p>
        <p>
            <i class="fa fa-twitch"></i>&nbsp&nbsp <a id="webtagA" runat="server" target="_blank">
            </a>
        </p>
        <br />
        <%--Thông tin doanh nghiệp--%>
        <div class="panel-group">
            <!--id="accordion"-->
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h5 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Giới thiệu chung</a>
                    </h5>
                </div>
                <div id="collapseOne" class="panel-collapse collapse">
                    <div class="panel-body">
                        <asp:Label runat="server" ID="lblGioiThieuChung"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">Lĩnh vực kinh
                            doanh</a>
                    </h4>
                </div>
                <div id="collapseTwo" class="panel-collapse collapse">
                    <div class="panel-body">
                        <asp:Label runat="server" ID="lblLinhVucKinhDoanh"></asp:Label>
                        <br />
                        <strong>Loại hình: </strong>
                        <asp:Label runat="server" ID="lblLoaiHinhCongTy"></asp:Label>
                        <br />
                        <strong>Quy mô:</strong>
                        <asp:Label runat="server" ID="lblQuyMo"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="panel panel-warning">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseThree">Thông tin liên
                            hệ</a>
                    </h4>
                </div>
                <div id="collapseThree" class="panel-collapse collapse in">
                    <div class="panel-body">
                        <asp:Literal runat="server" ID="lblThongTinLienLac"></asp:Literal>
                        <%--<a href="#" style="text-decoration: none; color: #676a6c;">
                                <div class="col-sm-4">
                                    <div class="text-center">
                                        <img class="img-circle m-t-xs img-responsive" src="../../../Data/ThongTinHopTac/HinhAnh/p8.jpg"
                                            alt="image">
                                        <div class="m-t-xs font-bold">
                                            HRM</div>
                                    </div>
                                </div>
                                <div class="col-sm-8">
                                    <h3>
                                        <strong>Ms Ngân</strong>
                                    </h3>
                                    <p>
                                        <i class="fa fa-envelope"></i>ngan@namdtr.com
                                    </p>
                                    <address>
                                        <strong>Tòa nhà Centec.</strong>
                                        <br>
                                        72-74 Nguyễn Thị Minh Khai, Phường 6, quận 3.
                                        <br>
                                        <i class="fa fa-phone"></i>: &nbsp 093xxxxxx.
                                    </address>
                                </div>
                                <div class="clearfix">
                                </div>
                            </a>--%>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <%--Hình ảnh hoạt động--%>
        <asp:Repeater ID="rptHinhAnh" runat="server">
            <ItemTemplate>
                <a class="fancybox" rel="fancybox-thumb" runat="server" id="a_fancybox">
                    <img alt="image" runat="server" id="image_hoatDong">
                </a>
            </ItemTemplate>
        </asp:Repeater>
        <br />
        <br />
    </div>
</div>
<script src="<%=ResolveUrl("~/") %>Resources/js/jquery-2.1.1.js" type="text/javascript"></script>
<script type="text/javascript">
    function getURLFun() {
        var host = '<%=ResolveUrl("~/") %>';
        return host;
    }
    function reloadWithQueryStringVars(queryStringVars) {
        url = getURLFun() + "Page/10042014_HDHTDoanhNghiep/FolderPageThongTinDoanhNghiep/PageThongTinChiTietDoanhNghiep.aspx",
        currentUrl = location.search ? url.replace(location.search, "") : url,
        newQueryVars = {},
        newUrl = currentUrl + "?";

        if (queryStringVars) {
            for (var queryStringVar in queryStringVars) {
                newQueryVars[queryStringVar] = queryStringVars[queryStringVar];
            }
        }
        if (newQueryVars) {
            for (var newQueryVar in newQueryVars) {
                newUrl += newQueryVar + "=" + newQueryVars[newQueryVar] + "&";
            }
            newUrl = newUrl.substring(0, newUrl.length - 1);
            //window.open(newUrl, '_blank');
            window.location.href = newUrl;
        } else {
            //window.open(location.href, '_blank');
            window.location.href = location.href;
        }
    }

    function OnclickTab(tabindex) {

        var guidDoanhNghiep = GetParameterValues("index");
        reloadWithQueryStringVars({ "peihgnhnaoddiug": guidDoanhNghiep, "TabIndex": tabindex });
    }

</script>
