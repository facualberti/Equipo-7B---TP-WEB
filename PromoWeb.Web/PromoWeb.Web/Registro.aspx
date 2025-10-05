<%@ Page Title="Registro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="PromoWeb.Web.Registro" %>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .form-check input[type=checkbox]{ margin-right:.5rem }
        .field{ margin-bottom:1rem }
        .help{ margin-top:.25rem }
        label.form-label{ font-weight:600; margin-bottom:.35rem }
        .is-invalid{ border-color:#dc3545; } 
    </style>

    <h2 class="mb-3">Ingresá tus datos</h2>

    <div class="row" style="max-width:900px">
        <div class="col-12" id="regWrap">

            
            <asp:ValidationSummary runat="server"
                CssClass="alert alert-danger"
                EnableClientScript="true"
                HeaderText="Revisá estos campos:"
                ValidationGroup="reg" />

            <asp:UpdatePanel ID="upRegistro" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                <ContentTemplate>

                    
                    <div class="field">
                        <label class="form-label" for="<%= txtDni.ClientID %>">DNI (solo números, 6–8 dígitos)</label>
                        <asp:TextBox ID="txtDni" runat="server"
                            CssClass="form-control reg-input"
                            MaxLength="8"
                            AutoPostBack="false"              
                            OnTextChanged="txtDni_TextChanged"
                            AutoCompleteType="Disabled"
                            autocomplete="off"
                            placeholder="00000000" />
                        <asp:RequiredFieldValidator runat="server"
                            ControlToValidate="txtDni"
                            ErrorMessage="El DNI es obligatorio."
                            CssClass="valmsg text-danger"
                            Display="Dynamic"
                            ValidationGroup="reg" />
                        <asp:RegularExpressionValidator runat="server"
                            ControlToValidate="txtDni"
                            ValidationExpression="^\d{6,8}$"
                            ErrorMessage="DNI inválido: solo números (6 a 8 dígitos)."
                            CssClass="valmsg text-danger"
                            Display="Dynamic"
                            ValidationGroup="reg" />
                        <div class="help form-text">Usá tu número real para validar el voucher.</div>
                    </div>

                    <div class="row">
                        
                        <div class="col-md-6">
                            <div class="field">
                                <label class="form-label" for="<%= txtNombre.ClientID %>">Nombre</label>
                                <asp:TextBox ID="txtNombre" runat="server"
                                    CssClass="form-control reg-input"
                                    AutoCompleteType="FirstName"
                                    autocomplete="given-name"
                                    placeholder="Juan" />
                                <asp:RequiredFieldValidator runat="server"
                                    ControlToValidate="txtNombre"
                                    ErrorMessage="Nombre requerido."
                                    CssClass="valmsg text-danger"
                                    Display="Dynamic"
                                    ValidationGroup="reg" />
                                <asp:RegularExpressionValidator runat="server"
                                    ControlToValidate="txtNombre"
                                    ValidationExpression="^[A-Za-zÁÉÍÓÚÜÑáéíóúüñ' -]{2,40}$"
                                    ErrorMessage="Nombre inválido (solo letras/espacios, mínimo 2)."
                                    CssClass="valmsg text-danger"
                                    Display="Dynamic"
                                    ValidationGroup="reg" />
                                <div class="help form-text">Solo letras (se permiten acentos), mínimo 2 caracteres.</div>
                            </div>
                        </div>

                       
                        <div class="col-md-6">
                            <div class="field">
                                <label class="form-label" for="<%= txtApellido.ClientID %>">Apellido</label>
                                <asp:TextBox ID="txtApellido" runat="server"
                                    CssClass="form-control reg-input"
                                    AutoCompleteType="LastName"
                                    autocomplete="family-name"
                                    placeholder="Pérez" />
                                <asp:RequiredFieldValidator runat="server"
                                    ControlToValidate="txtApellido"
                                    ErrorMessage="Apellido requerido."
                                    CssClass="valmsg text-danger"
                                    Display="Dynamic"
                                    ValidationGroup="reg" />
                                <asp:RegularExpressionValidator runat="server"
                                    ControlToValidate="txtApellido"
                                    ValidationExpression="^[A-Za-zÁÉÍÓÚÜÑáéíóúüñ' -]{2,40}$"
                                    ErrorMessage="Apellido inválido (solo letras/espacios, mínimo 2)."
                                    CssClass="valmsg text-danger"
                                    Display="Dynamic"
                                    ValidationGroup="reg" />
                                <div class="help form-text">Solo letras (se permiten acentos), mínimo 2 caracteres.</div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        
                        <div class="col-md-6">
                            <div class="field">
                                <label class="form-label" for="<%= txtEmail.ClientID %>">Email</label>
                                <asp:TextBox ID="txtEmail" runat="server"
                                    CssClass="form-control reg-input"
                                    TextMode="Email"
                                    AutoCompleteType="Email"
                                    autocomplete="email"
                                    placeholder="nombre@dominio.com" />
                                <asp:RequiredFieldValidator runat="server"
                                    ControlToValidate="txtEmail"
                                    ErrorMessage="Email requerido."
                                    CssClass="valmsg text-danger"
                                    Display="Dynamic"
                                    ValidationGroup="reg" />
                                <asp:RegularExpressionValidator runat="server"
                                    ControlToValidate="txtEmail"
                                    ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
                                    ErrorMessage="Email inválido."
                                    CssClass="valmsg text-danger"
                                    Display="Dynamic"
                                    ValidationGroup="reg" />
                                <div class="help form-text">Revisá que esté bien escrito (vamos a contactarte acá).</div>
                            </div>
                        </div>

                        
                        <div class="col-md-6">
                            <div class="field">
                                <label class="form-label" for="<%= txtDireccion.ClientID %>">Dirección</label>
                                <asp:TextBox ID="txtDireccion" runat="server"
                                    CssClass="form-control reg-input"
                                    AutoCompleteType="HomeStreetAddress"
                                    autocomplete="street-address"
                                    placeholder="Calle y número" />
                                <asp:RequiredFieldValidator runat="server"
                                    ControlToValidate="txtDireccion"
                                    ErrorMessage="Dirección requerida."
                                    CssClass="valmsg text-danger"
                                    Display="Dynamic"
                                    ValidationGroup="reg" />
                                <asp:RegularExpressionValidator runat="server"
                                    ControlToValidate="txtDireccion"
                                    ValidationExpression="^[A-Za-zÁÉÍÓÚÜÑáéíóúüñ0-9#.\- ]{5,80}$"
                                    ErrorMessage="Dirección inválida (mínimo 5, admite letras, números, # . -)."
                                    CssClass="valmsg text-danger"
                                    Display="Dynamic"
                                    ValidationGroup="reg" />
                                <div class="help form-text">Ej.: “Av. Siempre Viva 742”.</div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        
                        <div class="col-md-6">
                            <div class="field">
                                <label class="form-label" for="<%= txtCiudad.ClientID %>">Ciudad</label>
                                <asp:TextBox ID="txtCiudad" runat="server"
                                    CssClass="form-control reg-input"
                                    AutoCompleteType="HomeCity"
                                    autocomplete="address-level2"
                                    placeholder="Ciudad" />
                                <asp:RequiredFieldValidator runat="server"
                                    ControlToValidate="txtCiudad"
                                    ErrorMessage="Ciudad requerida."
                                    CssClass="valmsg text-danger"
                                    Display="Dynamic"
                                    ValidationGroup="reg" />
                                <asp:RegularExpressionValidator runat="server"
                                    ControlToValidate="txtCiudad"
                                    ValidationExpression="^[A-Za-zÁÉÍÓÚÜÑáéíóúüñ' -]{2,60}$"
                                    ErrorMessage="Ciudad inválida (solo letras/espacios, mínimo 2)."
                                    CssClass="valmsg text-danger"
                                    Display="Dynamic"
                                    ValidationGroup="reg" />
                                <div class="help form-text">Ej.: “Buenos Aires”.</div>
                            </div>
                        </div>

                       
                        <div class="col-md-3">
                            <div class="field">
                                <label class="form-label" for="<%= txtCP.ClientID %>">CP</label>
                                <asp:TextBox ID="txtCP" runat="server"
                                    CssClass="form-control reg-input"
                                    MaxLength="10"
                                    AutoCompleteType="HomeZipCode"
                                    autocomplete="postal-code"
                                    placeholder="Código Postal" />
                                <asp:RequiredFieldValidator runat="server"
                                    ControlToValidate="txtCP"
                                    ErrorMessage="CP requerido."
                                    CssClass="valmsg text-danger"
                                    Display="Dynamic"
                                    ValidationGroup="reg" />
                                <asp:RegularExpressionValidator runat="server"
                                    ControlToValidate="txtCP"
                                    ValidationExpression="^\d{4,10}$"
                                    ErrorMessage="CP inválido: solo números (4 a 10 dígitos)."
                                    CssClass="valmsg text-danger"
                                    Display="Dynamic"
                                    ValidationGroup="reg" />
                                <div class="help form-text">Solo números, entre 4 y 10 dígitos.</div>
                            </div>
                        </div>
                    </div>

                  
                    <div class="form-check mt-2">
                        <asp:CheckBox ID="chkTyC" runat="server" CssClass="reg-input" />
                        <label class="form-check-label" for="<%= chkTyC.ClientID %>">
                            Acepto los términos y condiciones
                        </label>
                    </div>

                    <asp:CustomValidator
                        ID="valTyC"
                        runat="server"
                        ClientValidationFunction="validateTyC"
                        OnServerValidate="valTyC_ServerValidate"
                        ErrorMessage="Debés aceptar los términos y condiciones."
                        CssClass="valmsg text-danger mt-1"
                        Display="Dynamic"
                        ValidationGroup="reg" />

                    <asp:Label ID="lblMsg" runat="server" CssClass="text-danger d-block mt-2" Visible="false" />

                </ContentTemplate>
                <Triggers>
                   
                    <asp:AsyncPostBackTrigger ControlID="txtDni" EventName="TextChanged" />
                    
                    <asp:PostBackTrigger ControlID="btnParticipar" />
                </Triggers>
            </asp:UpdatePanel>

            
            <script type="text/javascript">
            (function () {
              function wireDni() {
                var dni = document.getElementById('<%= txtDni.ClientID %>');
                if (!dni) return;

               
                dni._wired && dni._wired();
                var lastPosted = null, t = null;

                dni.setAttribute('inputmode', 'numeric');
                dni.setAttribute('pattern', '\\d{6,8}');

                function normalize() {
                  var cleaned = (dni.value || '').replace(/\D+/g, '').slice(0, 8);
                  if (cleaned !== dni.value) dni.value = cleaned;
                }

                function triggerLookup() {
                  clearTimeout(t);
                  t = setTimeout(function () {
                    lastPosted = dni.value;
                    __doPostBack('<%= txtDni.UniqueID %>', '');
                  }, 200);
                }

                dni.addEventListener('input', onInput);
                dni.addEventListener('blur', onBlur);
                dni.addEventListener('paste', onPaste);

                
                dni._wired = function() {
                  dni.removeEventListener('input', onInput);
                  dni.removeEventListener('blur', onBlur);
                  dni.removeEventListener('paste', onPaste);
                };

                function onInput() {
                  normalize();
                  var val = dni.value;
                  
                  if (val.length === 8 && /^\d{8}$/.test(val)) {
                    if (val !== lastPosted) triggerLookup();
                  } else {
                    clearTimeout(t);
                  }
                }

                function onBlur() {
                  normalize();
                  var val = dni.value;
                  
                  if (/^\d{6,8}$/.test(val) && val !== lastPosted) {
                    triggerLookup();
                  }
                  if (val.length === 0) lastPosted = null;
                }

                function onPaste(e) {
                  var txt = (e.clipboardData || window.clipboardData).getData('text');
                  if (!/^\d{1,8}$/.test(txt)) e.preventDefault();
                }
              }

              
              if (window.Sys && Sys.WebForms && Sys.WebForms.PageRequestManager) {
                var prm = Sys.WebForms.PageRequestManager.getInstance();
                var restoreFocus = false, caret = 0;
                prm.add_beginRequest(function() {
                  var dni = document.getElementById('<%= txtDni.ClientID %>');
                  if (dni && document.activeElement === dni) {
                    restoreFocus = true;
                    try { caret = dni.selectionStart || dni.value.length; } catch(e) { caret = dni.value.length; }
                  } else {
                    restoreFocus = false;
                  }
                });
                prm.add_endRequest(function() {
                  wireDni(); 
                  if (restoreFocus) {
                    var dni = document.getElementById('<%= txtDni.ClientID %>');
                    if (dni) {
                      dni.focus();
                      try { dni.setSelectionRange(caret, caret); } catch(e){}
                    }
                  }
                });
                
                Sys.Application.add_load(wireDni);
              } else {
                document.addEventListener('DOMContentLoaded', wireDni);
              }

             
              window.validateTyC = function (sender, args) {
                args.IsValid = document.getElementById('<%= chkTyC.ClientID %>').checked;
                    };
                })();
            </script>

            <div class="mt-3">
                <asp:Button ID="btnParticipar" runat="server"
                    Text="Participar!"
                    CssClass="btn btn-primary"
                    OnClick="btnParticipar_Click"
                    ValidationGroup="reg" />
            </div>

        </div>
    </div>
</asp:Content>
