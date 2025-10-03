<%@ Page Title="Registro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="PromoWeb.Web.Registro" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
  <h2>Ingresá tus datos</h2>
  <p>(placeholder) Luego pedimos DNI y precargamos si existe.</p>
  <p><strong>Voucher:</strong> <%= Session["CodigoVoucher"] ?? "(sin voucher)" %></p>
  <p><strong>Premio seleccionado:</strong> <%= Session["PremioId"] ?? "(sin seleccionar)" %></p>
</asp:Content>
