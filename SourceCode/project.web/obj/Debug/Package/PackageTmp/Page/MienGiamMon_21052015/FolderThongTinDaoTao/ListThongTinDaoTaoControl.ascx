<%--   
Author:					Nguyen Thanh Dai
Created:				2015-6-8
Last Modified:			2015-6-8
--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListThongTinDaoTaoControl.ascx.cs"
    Inherits="project.web.ListThongTinDaoTaoControl" %>
<div id="ts-popup-viewchuongtrinhdaotao" class="bigbox-950">
    <div class="panel panel-default panel-popup">
        <div class="panel-heading">
            <h3 class="panel-title">
                Chương trình đào tạo</h3>
        </div>
        <div class="panel-body">
            <asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="UpdatePanelShowThongTinDaoTao_on">
                <ProgressTemplate>
                    <span style="position: fixed; z-index: 9999; top: 48%; left: 48%;">
                        <img src="<%=ResolveUrl("~/") %>Resources/img/waiting.gif" alt="Vui lòng đợi..."
                            height="80px" width="80px" /></span>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanelShowThongTinDaoTao_on" runat="server" UpdateMode="Conditional"
                ChildrenAsTriggers="false">
                <ContentTemplate>
                    <asp:Literal ID="LiteralCTDTGuid" Visible="false" runat="server"></asp:Literal>
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="ibox float-e-margins">
                                <div class="">
                                    <div class="table-responsive table-mienmon">
                                        <table class="table table-striped table-bordered table-chuongtrinhdaotao">
                                            <thead class="thead-center">
                                                <tr>
                                                    <th rowspan="2">
                                                        STT
                                                    </th>
                                                    <th rowspan="2">
                                                        Mã HP
                                                    </th>
                                                    <th rowspan="2">
                                                        Tên học phần
                                                    </th>
                                                    <th colspan="6">
                                                        Số tín chỉ
                                                    </th>
                                                    <th rowspan="2">
                                                        Mã học phần trước
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <th colspan="2">
                                                        Tổng
                                                    </th>
                                                    <th class="w-50">
                                                        LT
                                                    </th>
                                                    <th class="w-50">
                                                        TH/TT
                                                    </th>
                                                    <th class="w-50">
                                                        ĐA
                                                    </th>
                                                    <th class="w-50">
                                                        ĐATN
                                                    </th>
                                                </tr>
                                            </thead>
                                            <asp:Repeater ID="RepeaterThongTinDaoTao" runat="server">
                                                <ItemTemplate>
                                                    <%# BuilTR(Container.ItemIndex + 1 ,
                                                        Eval("ThongTinDaoTaoGuidGuid"),
                                                        Eval("MonHocID"), 
                                                        Eval("MoTa"),
                                                        Eval("SoTinChiBatBuoc"),
                                                        Eval("Level"),
                                                        Eval("SoTCDoAn"),
                                                        Eval("SoTCDoAnTN"),
                                                        Eval("SoTCLyThuyet"),
                                                        Eval("SoTCThucHanh"),
                                                        Eval("SoTinChi"),
                                                        Eval("MaHocPhanTruoc"))%>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ButtonExit" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <div class="panel-footer">
            <div class="text-right poupclosefix">
                <asp:LinkButton ID="ButtonExit" runat="server" ToolTip="Hủy" CssClass="btn btn-link btn-cancel btn-sm">&nbsp;Hủy thao tác</asp:LinkButton>
            </div>
        </div>
    </div>
    
</div>
