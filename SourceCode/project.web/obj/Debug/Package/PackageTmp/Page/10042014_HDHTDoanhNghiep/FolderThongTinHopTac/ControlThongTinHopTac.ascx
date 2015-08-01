<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlThongTinHopTac.ascx.cs"
    Inherits="project.web.Page.FolderThongTinHopTac.ControlThongTinHopTac" %>
<div class="panel blank-panel">
    <div class="panel-heading">
        <div class="panel-options">
            <ul class="nav nav-tabs">
                <li class="active"><a href="#tab-1" data-toggle="tab" onclick="HBOnClick($('#tab-1'),'00000000-0000-0000-0000-000000000000')">
                    Quá trình hợp tác</a></li>
                <li class=""><a href="#tab-2" data-toggle="tab" onclick="HBOnClick($('#tab-2'),'26adf09d-adf6-4882-86c7-b9bc41b19374')">
                    Học bổng</a></li>
                <li class=""><a href="#tab-3" data-toggle="tab" onclick="HBOnClick($('#tab-3'),'7aaf1c69-8a5a-4fef-843f-81c0030b8e7f')">
                    Tài trợ</a></li>
                <li class=""><a href="#tab-4" data-toggle="tab" onclick="HBOnClick($('#tab-4'),'cbfca483-5e44-4a6e-916b-16a45a5c63bf')">
                    Thực tập</a></li>
                <li class=""><a href="#tab-5" data-toggle="tab" onclick="HBOnClick($('#tab-5'),'cf1cda6d-273c-4d9a-b944-7c110b5982d2')">
                    Tuyển dụng</a></li>
            </ul>
        </div>
    </div>
    <div class="ibox-content">
        <div class="tab-content">
            <div class="tab-pane active" id="tab-1">
            </div>
            <div class="tab-pane" id="tab-2">
            </div>
            <div class="tab-pane" id="tab-3">
            </div>
            <div class="tab-pane" id="tab-4">
            </div>
            <div class="tab-pane" id="tab-5">
            </div>
        </div>
    </div>
</div>
<script src="<%=ResolveUrl("~/") %>Resources/js/jquery-2.1.1.js" type="text/javascript"></script>
<script>
    $(document).ready(function () {
        var loai = '00000000-0000-0000-0000-000000000000';
        var divID = $("#tab-1");
        LoadHoatDongDN(loai, divID);
    });

    function getURLFun() {
        var host = '<%=ResolveUrl("~/") %>';
        return host;
    }

    function getCurrentUser() {
        var host = "<%=MyMessageFromCodeBehind %>";
        return host;
    }

</script>
<script src="JSThongTinHopTacHTML.js" type="text/javascript"></script>
