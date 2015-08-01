<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadFileAttachDropxoneControl.ascx.cs"
    Inherits="project.web.Page.UploadFileAttachDropxoneControl" %>

<asp:Panel runat="server" ID="PanelDropZone" CssClass="dropzone">

</asp:Panel>
<asp:HiddenField ID="HiddenFieldLoaiHinhAnh" runat="server" />
<!--Tạo -->
<br />
<asp:Panel id="PanelLoadGallery" runat="server" >

</asp:Panel>

<%--<script type="text/javascript">
//function GetParameterValues(param) {
//    var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
//    for (var i = 0; i < url.length; i++) {
//        var urlparam = url[i].split('=');
//        if (urlparam[0] == param) {
//            return urlparam[1];
//        }
//    }
//}


//function OnDeleteData(param1)
//{
//    $.ajax({
//            url: "Secret.asmx/DeleteFile",
//            data: JSON.stringify({ 'Keysearch1': param1 }),
//            dataType: "json",
//            type: "POST",
//            contentType: "application/json",
//            success: function (data) {
//                var jsonData = data.d;
//                var toancuc = JSON.parse(jsonData);
//                var result;
//                if (!data || data.length === 0) {
//                    result = [{
//                        label: 'không có gì'
//                    }];
//                } else {
//                    result = toancuc;
//                }
//               DoGallery(loaihinhanh,GetParameterValues('diugmeti'),panelgalerry);
//            },
//            error: function (XMLHttpRequest, textStatus, errorThrown) {
//                alert('loi');
//            }
//        });
//}

//function DoGallery(param1, param2, param3)
//{
//    $(param3).html('');
//    $.ajax({
//            url: "Secret.asmx/GetPlayers2",
//            data: JSON.stringify({ 'Keysearch1': param1 , 'KeySearch2' : param2 }),
//            dataType: "json",
//            type: "POST",
//            contentType: "application/json",
//            success: function (data) {
//                var jsonData = data.d;
//                var toancuc = JSON.parse(jsonData);
//                var result;
//                if (!data || data.length === 0) {
//                    result = [{
//                        label: 'không có gì'
//                    }];
//                } else {
//                    result = toancuc;
//                }
//                var start = 0;
//                var contentString = "<div class='ibox-content'>";
//                var count = Object.keys(result).length; 
//                contentString+="";
//                 while (count > start) {
//                 contentString+="<a class='fancybox' href="+result[start]["ServerFileName"]+" title="+result[start]["ClientFileName"]+">"
//                            +"<img alt="+result[start]["ClientFileName"]+"  src="+result[start]["ServerFileName"]+" /></a>";
//                contentString+="<a onclick='OnDeleteData(\""+result[start]["FileSystemGuid"]+"\")'>X</a>"
//                 start = start + 1;
//                 }       
//                  contentString+="</div>";
//                 $(param3).append(contentString);
//            },
//            error: function (XMLHttpRequest, textStatus, errorThrown) {
//                alert('loi');
//            }
//        });
//}


//document.addEventListener("DOMContentLoaded", function () {
//        DoGallery(loaihinhanh,GetParameterValues('diugmeti'),panelgalerry);
//        var myDropzoneTheFirst = new Dropzone(
//            tendropzone, 
//            {
//                paramName: "file", 
//                maxFilesize: 20, 
//                autoProcessQueue: false,
//                uploadMultiple: true,
//                parallelUploads: 1,
//                addRemoveLinks:true,
//                maxFiles: 100,
//                url: "photoupload.aspx?tid=<%=Request.QueryString["tid"]%>&htaPelif=" + loaihinhanh + "&diugmeti=" + GetParameterValues('diugmeti'),
//                init: function() {
//                    var myDropzone = this;
//                    this.element.querySelector("button[type=submit]").addEventListener("click", function(e) {
//                        e.preventDefault();
//                        e.stopPropagation();
//                        myDropzone.processQueue();
//                    });
//                    this.on("sendingmultiple", function() {
//                    });
//                    this.on("successmultiple", function(files, response) {
//                    });
//                    this.on("completemultiple", function(files, response) {
//                        if (this.getUploadingFiles().length === 0 && this.getQueuedFiles().length === 0) {
//                            this.options.autoProcessQueue = false;
//                            this.removeAllFiles();
//                            DoGallery(loaihinhanh,GetParameterValues('diugmeti'),panelgalerry);
//                         }
//                    });
//                    this.on("errormultiple", function(files, response) {
//                    });
//                    this.on("processing", function() {
//                        this.options.autoProcessQueue = true;
//                    });
//                }
//             });
//        });

</script>--%>
