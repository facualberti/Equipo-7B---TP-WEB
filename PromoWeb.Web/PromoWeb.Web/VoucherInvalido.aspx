<%@ Page Title="Código inválido" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="VoucherInvalido.aspx.cs"
    Inherits="PromoWeb.Web.VoucherInvalido" %>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
  <h2>El código no es válido o ya fue utilizado</h2>
  <p>Verificá el voucher e intentá nuevamente.</p>
  <a class="btn btn-secondary" href="Default.aspx">Volver al inicio</a>
</asp:Content>
