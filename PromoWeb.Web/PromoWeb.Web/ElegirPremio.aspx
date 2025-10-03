<%@ Page Title="Elegí tu premio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ElegirPremio.aspx.cs" Inherits="PromoWeb.Web.ElegirPremio" %>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
  <style>
    .cards { display:flex; flex-wrap:wrap; gap:24px; }
    .card  { width:300px; border:1px solid #ddd; border-radius:8px; overflow:hidden; box-shadow:0 1px 3px rgba(0,0,0,.08); }
    .card img { width:100%; height:200px; object-fit:cover; background:#f7f7f7; }
    .card .body { padding:12px 16px; }
    .muted { color:#666; font-size:.9rem; }
  </style>

  <h2>Elegí tu premio</h2>
  <asp:Label ID="lblMsg" runat="server" CssClass="text-danger" Visible="false" />

  <asp:Repeater ID="repPremios" runat="server" OnItemCommand="repPremios_ItemCommand">
    <HeaderTemplate>
      <div class="cards">
    </HeaderTemplate>

    <ItemTemplate>
      <div class="card">
        <img src='<%# string.IsNullOrEmpty(Eval("ImagenUrl") as string) ? ResolveUrl("~/Content/placeholder.png") : Eval("ImagenUrl") %>' alt="Premio" />
        <div class="body">
          <h4><%# Eval("Nombre") %></h4>
          <p class="muted"><%# Eval("Descripcion") %></p>
          <asp:Button runat="server" CommandName="elegir" CommandArgument='<%# Eval("Id") %>' Text="Quiero este" CssClass="btn btn-primary" />
        </div>
      </div>
    </ItemTemplate>

    <FooterTemplate>
      </div>
    </FooterTemplate>
  </asp:Repeater>
</asp:Content>
