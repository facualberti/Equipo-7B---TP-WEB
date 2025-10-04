<%@ Page Title="Acerca de" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="PromoWeb.Web.About" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
  <div class="container py-4 about">
    <h2 class="mb-2">
      <span class="badge rounded-3" style="background:#eef4ff;color:#315bef;padding:.38rem .7rem;font-size:1.92rem;font-weight:600;">
        ¿Qué es Promo Ganá?
      </span>
    </h2>
    <p class="lead text-muted mb-4">
      Es una promoción simple: ingresás el código de tu voucher, completás tus datos,
      elegís un premio y listo. El sistema registra tu participación y te envía un email de confirmación.
    </p>

    
    <div class="row g-3">
      <div class="col-12 col-md-4">
        <div class="accordion" id="accComo">
          <div class="accordion-item">
            <h2 class="accordion-header" id="hComo">
              <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse"
                      data-bs-target="#cComo" aria-expanded="false" aria-controls="cComo">
                Cómo participar
              </button>
            </h2>
            <div id="cComo" class="accordion-collapse collapse" aria-labelledby="hComo" data-bs-parent="#accComo">
              <div class="accordion-body">
                <ul class="list-unstyled m-0">
                  <li class="d-flex gap-2 mb-2">
                    <span class="text-success fw-bold">✓</span>
                    <span>En la página de inicio, ingresá el <b>código</b> de tu voucher.</span>
                  </li>
                  <li class="d-flex gap-2 mb-2">
                    <span class="text-success fw-bold">✓</span>
                    <span>Completá tus <b>datos</b> y aceptá los <b>términos y condiciones</b>.</span>
                  </li>
                  <li class="d-flex gap-2">
                    <span class="text-success fw-bold">✓</span>
                    <span>Elegí el <b>premio</b> y confirmá. Te llega un <b>email</b>.</span>
                  </li>
                </ul>
                <p class="text-muted mt-3 mb-0">
                  ¿Problemas con el código? Revisá mayúsculas/minúsculas y que no tenga espacios.
                </p>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div class="col-12 col-md-4">
        <div class="accordion" id="accPremios">
          <div class="accordion-item">
            <h2 class="accordion-header" id="hPremios">
              <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse"
                      data-bs-target="#cPremios" aria-expanded="false" aria-controls="cPremios">
                Premios
              </button>
            </h2>
            <div id="cPremios" class="accordion-collapse collapse" aria-labelledby="hPremios" data-bs-parent="#accPremios">
              <div class="accordion-body">
                <p class="mb-2">Vas a ver todos los artículos disponibles con varias imágenes.
                   Podés ampliarlas y revisar la descripción antes de confirmar.</p>
                <p class="text-muted mb-0">La disponibilidad puede variar; si un premio se agota, no aparecerá en el listado.</p>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div class="col-12 col-md-4">
        <div class="accordion" id="accTyC">
          <div class="accordion-item">
            <h2 class="accordion-header" id="hTyC">
              <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse"
                      data-bs-target="#cTyC" aria-expanded="false" aria-controls="cTyC">
                Términos y condiciones
              </button>
            </h2>
            <div id="cTyC" class="accordion-collapse collapse" aria-labelledby="hTyC" data-bs-parent="#accTyC">
              <div class="accordion-body">
                <p class="mb-2">Leé las bases completas antes de participar.</p>
                <p class="mb-0">
                  <a href="<%: ResolveUrl("~/Bases.aspx") %>" class="link-primary">Descargar bases (PDF)</a>
                </p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

    <!-- Contacto como 4° acordeón -->
    <div class="accordion mt-3" id="accContacto">
      <div class="accordion-item">
        <h2 class="accordion-header" id="hContacto">
          <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse"
                  data-bs-target="#cContacto" aria-expanded="false" aria-controls="cContacto">
            Contacto
          </button>
        </h2>
        <div id="cContacto" class="accordion-collapse collapse" aria-labelledby="hContacto" data-bs-parent="#accContacto">
          <div class="accordion-body">
            <p class="text-muted mb-0">
              ¿Dudas o consultas? Escribinos a
              <a href="mailto:promotpweb@gmail.com">promotpweb@gmail.com</a>.
            </p>
          </div>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
