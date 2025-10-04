<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Contact.aspx.cs"
    Inherits="PromoWeb.Web.Contact" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
  <h2>Contacto</h2>
  <p class="text-muted">Dejanos tu consulta y te respondemos por email.</p>

  <div class="row" style="max-width:720px">
    <div class="col-md-12">
      <div class="mb-3">
        <label>Nombre</label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="80" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre"
            ErrorMessage="El nombre es obligatorio" CssClass="text-danger" />
      </div>

      <div class="mb-3">
        <label>Email</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail"
            ErrorMessage="El email es obligatorio" CssClass="text-danger" />
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtEmail"
            ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" ErrorMessage="Email inválido"
            CssClass="text-danger" />
      </div>

      <div class="mb-3">
        <label>Mensaje</label>
        <asp:TextBox ID="txtMensaje" runat="server" CssClass="form-control" TextMode="MultiLine"
            Rows="5" MaxLength="2000" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtMensaje"
            ErrorMessage="Escribí tu mensaje" CssClass="text-danger" />
      </div>

      <div class="d-grid d-sm-block">
        <asp:Button ID="btnEnviar" runat="server" Text="Enviar"
            CssClass="btn btn-primary" OnClick="btnEnviar_Click" />
      </div>

      <asp:Label ID="lblOk" runat="server" Visible="false"
          CssClass="d-block alert alert-success mt-3" />
      <asp:Label ID="lblError" runat="server" Visible="false"
          CssClass="d-block alert alert-danger mt-3" />
    </div>
  </div>
</asp:Content>
