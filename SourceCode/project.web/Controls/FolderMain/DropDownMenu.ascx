﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DropDownMenu.ascx.cs"
    Inherits="project.web.Controls.FolderMain.DropDownMenu" %>
<div id="navbar" class="navbar navbar-inverse navbar-fixed-top">
    <div class="navbar-header">
        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
            <span class="sr-only">Toggle Navigation</span> <span class="icon-bar"></span><span
                class="icon-bar"></span><span class="icon-bar"></span>
        </button>
        <a href="navbar-brand" href="#" title="Home" rel="home">
            <h1 class="site-title">
                Sidebar Menu Demo</h1>
            <h2 class="site-description">
                A Vertical Menu Demo</h2>
        </a>
    </div>
    <<!-- Let's clear the float so the menu drops below the header -->
    <div class="clearfix">
    </div>
    <div class="collapse navbar-collapse">
        <ul class="nav nav-stacked" id="menu-bar">
            <!-- Notice the "nav-stacked" class we added here -->
            <li><a href="#">Home</a></li>
            <li><a href="#">Page 1</a></li>
            <li class="panel dropdown">
                <!-- We add the panel class to workaround collapsing menu items in Bootstrap -->
                <a data-toggle="collapse" data-parent="#menu-bar" href="#collapseOne">Collapsible Item
                    1 </a>
                <ul id="collapseOne" class="panel-collapse collapse">
                    <!-- Notice the ID of this element must match the href attribute in the <a> element above it. Also we have added the panel-collapse class -->
                    <li><a href="#">Item 1</a></li>
                    <li><a href="#">Item 2</a></li>
                </ul>
            </li>
            <li class="panel dropdown"><a data-toggle="collapse" data-parent="#menu-bar" href="#collapseTwo">
                Collapsible Item 2 </a>
                <ul id="collapseTwo" class="panel-collapse collapse">
                    <li><a href="#">Item 2-1</a></li>
                    <li><a href="#">Item 2-2</a></li>
                </ul>
            </li>
            <li><a href="#">Page 3</a></li>
            <li><a href="#">Page 4</a></li>
        </ul>
    </div>
    <!-- That's it for the menu bar -->
    <!-- The next section is would be your content section -->
    <!-- But first we must clear the float -->
    <div class="clearfix">
    </div>
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <h1>
                        Some Content Below</h1>
                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    (function ($) {
        var $window = $(window),
        $html = $('#menu-bar');

        $window.resize(function resize() {
            if ($window.width() < 768) {
                return $html.removeClass('nav-stacked');
            }
            $html.addClass('nav-stacked');
        }).trigger('resize');
    })(jQuery);
</script>
