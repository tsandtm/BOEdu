<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsNotificationControl.ascx.cs"
    Inherits="project.web.Controls.FolderThongBao.NewsNotificationControl" %>
<ul class="dropdown-menu dropdown-messages">
    <li>
        <div class="dropdown-messages-box">
            <a href="#" class="pull-left">
                <img alt="image" class="img-circle" src="<%=ResolveUrl("~/") %>Resources/img/no-avatar.png">
            </a>
            <div class="media-body">
                <small class="pull-right">1h ago</small> <strong>Anh Tuấn</strong> liên hệ với công
                ty <strong>Apple Corp</strong>.
                <br />
                <small class="text-muted">1 tiếng trước vào lúc 7:58 pm - 10.06.2014</small>
            </div>
        </div>
    </li>
    <li class="divider"></li>
    <li>
        <div class="dropdown-messages-box">
            <a href="#" class="pull-left">
                <img alt="image" class="img-circle" src="<%=ResolveUrl("~/") %>Resources/img/no-avatar.png">
            </a>
            <div class="media-body ">
                <small class="pull-right text-navy">1h ago</small> <strong>Cô Trang</strong> gặp
                gỡ doanh nghiệp <strong>Ngân Hàng ANZ</strong>.
                <br>
                <small class="text-muted">1 tiếng trước vào lúc 7:58 pm - 10.06.2014></small>
            </div>
        </div>
    </li>
    <li class="divider"></li>
    <li>
        <div class="text-center link-block">
            <a href="#"><i class="fa fa-envelope"></i><strong>Xem tất cả công việc</strong>
            </a>
        </div>
    </li>
</ul>
