<%@ Page Title="Registro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="PromoWeb.Web.Registro" %>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
  <h2>Ingresá tus datos</h2>

  <div class="row" style="max-width:900px">
    <div class="col-md-12">
      <div class="mb-3">
        <label>DNI</label>
        <asp:TextBox ID="txtDni" runat="server" CssClass="form-control" MaxLength="20" AutoPostBack="true" OnTextChanged="txtDni_TextChanged" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDni" ErrorMessage="El DNI es obligatorio" CssClass="text-danger" />
      </div>

      <div class="row">
        <div class="col-md-6 mb-3">
          <label>Nombre</label>
          <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
          <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre" ErrorMessage="Nombre requerido" CssClass="text-danger" />
        </div>
        <div class="col-md-6 mb-3">
          <label>Apellido</label>
          <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
          <asp:RequiredFieldValidator runat="server" ControlToValidate="txtApellido" ErrorMessage="Apellido requerido" CssClass="text-danger" />
        </div>
      </div>

      <div class="row">
        <div class="col-md-6 mb-3">
          <label>Email</label>
          <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
          <asp:RegularExpressionValidator runat="server" ControlToValidate="txtEmail"
              ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" ErrorMessage="Email inválido" CssClass="text-danger" />
        </div>
        <div class="col-md-6 mb-3">
          <label>Dirección</label>
          <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" />
          <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDireccion" ErrorMessage="Dirección requerida" CssClass="text-danger" />
        </div>
      </div>

      <div class="row">
        <div class="col-md-6 mb-3">
          <label>Ciudad</label>
          <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control" />
          <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCiudad" ErrorMessage="Ciudad requerida" CssClass="text-danger" />
        </div>
        <div class="col-md-3 mb-3">
          <label>CP</label>
          <asp:TextBox ID="txtCP" runat="server" CssClass="form-control" MaxLength="10" />
          <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCP" ErrorMessage="CP requerido" CssClass="text-danger" />
        </div>
      </div>

      <asp:CheckBox ID="chkTyC" runat="server" Text="Acepto los términos y condiciones" />
      <asp:CustomValidator ID="valTyC" runat="server" ErrorMessage="Debes aceptar TyC"
          ClientValidationFunction="function(s,e){ e.IsValid = document.getElementById('<%= chkTyC.ClientID %>').checked; }"
          CssClass="text-danger" />

      <div class="mt-3">
        <asp:Button ID="btnParticipar" runat="server" Text="Participar!" CssClass="btn btn-primary" OnClick="btnParticipar_Click" />
        <asp:Label ID="lblMsg" runat="server" CssClass="text-danger ms-3" Visible="false" />
      </div>
    </div>
  </div>
</asp:Content>
