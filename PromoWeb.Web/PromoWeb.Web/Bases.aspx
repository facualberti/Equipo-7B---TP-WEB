<%@ Page Title="Bases" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bases.aspx.cs" Inherits="PromoWeb.Web.Bases" %>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
  <style>
    .bases-wrap{min-height:55vh;display:flex;align-items:center;justify-content:center}
    .bases-card{border:1px solid #e7e7e7;border-radius:12px;padding:28px 32px;max-width:680px;text-align:center;box-shadow:0 1px 3px rgba(0,0,0,.06)}
    .bases-card h2{font-size:2rem;margin:0 0 .5rem}
    .bases-card p{color:#666;margin:.25rem 0 1rem}
  </style>

  <div class="bases-wrap">
    <div class="bases-card">
      <h2>😅 No llegué a tanto</h2>
      <p>Las bases todavía no están disponibles. Gracias por la paciencia.</p>
      <a class="btn btn-primary" href="<%: ResolveUrl("~/About.aspx") %>">Volver</a>
    </div>
  </div>
</asp:Content>
