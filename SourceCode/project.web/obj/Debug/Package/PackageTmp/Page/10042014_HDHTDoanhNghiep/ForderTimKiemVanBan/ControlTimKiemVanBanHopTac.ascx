<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlTimKiemVanBanHopTac.ascx.cs"
    Inherits="project.web.Page._10042014_HDHTDoanhNghiep.ForderTimKiemVanBan.ControlTimKiemVanBanHopTac" %>
<div class="ibox float-e-margins">
    <div class="ibox-content">
        <asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="UpdatePanelTimKiem">
            <ProgressTemplate>
                <span style="position: fixed; z-index: 9999; top: 1%; left: 48%; background-color: White;">
                    <div class="div-img-center">
                        <img src="<%=ResolveUrl("~/") %>Resources/img/waiting.gif" alt="Vui lòng đợi..."
                            class="img-responsive" />
                    </div>
                </span>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanelTimKiem" runat="server" UpdateMode="Conditional"
            ChildrenAsTriggers="false">
            <ContentTemplate>
                <h2>
                    <asp:Literal ID="LiteralSoLuong" runat="server"></asp:Literal>
                    <asp:Literal ID="LiteralTuKhoa" runat="server" Text="Tìm kiếm văn bản quá trình hợp tác"></asp:Literal>
                </h2>
                <small>
                    <asp:Literal ID="LiteralThoiGianTimKiem" runat="server"></asp:Literal></small>
                <div class="search-form">
                    <%--<form action="index.html" method="get">--%>
                    <div class="input-group">
                        <input type="text" placeholder="Tìm theo tiêu đề văn bản hoặc nội dung trích dẫn (có hoặc không dấu)"
                            name="search" class="form-control input-lg" runat="server" id="texboxKeySearch" />
                        <div class="input-group-btn">
                            <button class="btn btn-lg btn-primary" type="submit" runat="server" id="buttonTimKiem">
                                Tìm kiếm
                            </button>
                        </div>
                    </div>
                    <%--</form>--%>
                </div>
                <div class="hr-line-dashed">
                </div>
                <asp:Repeater ID="repeaterResult" runat="server">
                    <ItemTemplate>
                        <div class="search-result">
                            <a runat="server" id="a_FileName" target="_blank" class="search-link">
                                <h3>
                                    <asp:Label ID="lblTieuDeVanBan" runat="server"></asp:Label></h3>
                                <asp:Literal ID="LiteralFileName" runat="server"></asp:Literal></a>
                            <p>
                                <i><asp:Label ID="lblNoiDungTrichDan" runat="server"></asp:Label></i></p>
                            <p>
                                <asp:Literal ID="LiteralThoiGian" runat="server"></asp:Literal>
                            </p>
                            <p>
                                <asp:Literal ID="LiteralContent" runat="server"></asp:Literal>
                            </p>
                        </div>
                        <div class="hr-line-dashed">
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="buttonTimKiem" EventName="ServerClick" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
