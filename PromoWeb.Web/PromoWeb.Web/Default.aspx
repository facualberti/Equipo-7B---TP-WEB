<%@ Page Title="Promo Ganá - Paso 1" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PromoWeb.Web._Default" %>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
  <style>
    .voucher-wrapper{max-width:520px;margin:40px auto}
  </style>

  <script type="text/javascript">
      function validarVoucher() {
          var v = document.getElementById("<%= txtVoucher.ClientID %>").value;
          if (!v || v.trim() === "") { alert("Ingresá el código de tu voucher."); return false; }
          return true;
      }
  </script>

  <div class="voucher-wrapper">
    <h2>Promo Ganá!</h2>
    <p>Ingresá el código de tu voucher:</p>

    <asp:TextBox ID="txtVoucher" runat="server" CssClass="form-control" MaxLength="50" />
    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtVoucher"
        ErrorMessage="El código es obligatorio." CssClass="text-danger" Display="Dynamic" />
    <br />
    <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente"
        CssClass="btn btn-primary"
        OnClientClick="return validarVoucher()"
        OnClick="btnSiguiente_Click" />
    <br />
    <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false" />
  </div>
</asp:Content>
