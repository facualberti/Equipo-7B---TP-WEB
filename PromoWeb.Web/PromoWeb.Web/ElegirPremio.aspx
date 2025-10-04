<%@ Page Title="Elegí tu premio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ElegirPremio.aspx.cs" Inherits="PromoWeb.Web.ElegirPremio" %>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
  <style>
    .cards{display:grid;grid-template-columns:repeat(auto-fit,minmax(300px,1fr));gap:18px}
    .card{border:1px solid #e6e6e6;border-radius:10px;box-shadow:0 1px 3px rgba(0,0,0,.06);overflow:hidden;display:flex;flex-direction:column;height:100%;background:#fff}
    .main-frame{height:200px;background:#f7f7f7;display:flex;align-items:center;justify-content:center}
    .main-frame img{max-width:100%;max-height:100%;object-fit:contain;display:block;cursor:pointer}
    .body{display:grid;grid-template-rows:auto auto 1fr auto;row-gap:10px;padding:12px;height:100%}
    .title{font-size:1.1rem;line-height:1.25;margin:0}
    .muted{color:#666;font-size:.9rem;line-height:1.35;margin:0}
    .thumbs{display:flex;gap:8px;align-items:center}
    .thumbs img{width:52px;height:52px;object-fit:cover;border-radius:8px;border:1px solid #e5e5e5;background:#fafafa;cursor:pointer}
    .actions{margin-top:10px}
    .btn-slim{padding:.45rem .9rem;font-size:.9rem}

    .viewer{position:fixed;inset:0;background:rgba(0,0,0,.8);display:none;align-items:center;justify-content:center;z-index:1055}
    .viewer.open{display:flex}
    .viewer-box{position:relative;display:flex;align-items:center;justify-content:center;max-width:90vw;max-height:85vh}
    .viewer-box img{max-width:90vw;max-height:85vh;border-radius:12px;box-shadow:0 10px 30px rgba(0,0,0,.5);display:block}

    .ctrl{position:absolute;display:flex;align-items:center;justify-content:center;width:48px;height:48px;border-radius:999px;border:0;background:#fff;box-shadow:0 4px 14px rgba(0,0,0,.28);cursor:pointer;user-select:none}
    .ctrl svg{width:20px;height:20px;display:block}

    .ctrl.close{top:-22px;right:-22px}
    .ctrl.left{left:-88px;top:50%;transform:translateY(-50%)}
    .ctrl.right{right:-88px;top:50%;transform:translateY(-50%)}

    .ctrl:active{transform:translateY(-50%) scale(.97)}
    .ctrl.close:active{transform:scale(.97)}

    @media (max-width:992px){
      .ctrl.left{left:-64px}
      .ctrl.right{right:-64px}
      .ctrl.close{top:-16px;right:-16px}
    }
    @media (max-width:640px){
      .ctrl{width:44px;height:44px}
      .ctrl svg{width:18px;height:18px}
      .ctrl.left{left:8px}
      .ctrl.right{right:8px}
      .ctrl.close{top:8px;right:8px}
    }
  </style>

  <script type="text/javascript">
      var GALLERY = { list: [], index: 0 };
      function swapImg(mainId, url) { var el = document.getElementById(mainId); if (el) el.src = url; }
      function buildGalleryFrom(el) {
          var card = el.closest(".card");
          var imgs = [];
          var main = card.querySelector(".main-frame img");
          if (main && main.src) imgs.push(main.src);
          card.querySelectorAll(".thumbs img").forEach(function (t) { if (t.src) imgs.push(t.src); });
          GALLERY.list = Array.from(new Set(imgs));
          GALLERY.index = 0;
      }
      function showModalAt(i) {
          if (!GALLERY.list.length) return;
          if (i < 0) i = GALLERY.list.length - 1;
          if (i >= GALLERY.list.length) i = 0;
          GALLERY.index = i;
          var pic = document.getElementById("imgModalPic");
          pic.src = GALLERY.list[GALLERY.index];
          document.getElementById("imgModal").classList.add("open");
      }
      function openViewerFrom(el, src) {
          buildGalleryFrom(el);
          var i = GALLERY.list.indexOf(src);
          showModalAt(i >= 0 ? i : 0);
      }
      function closeViewer() {
          document.getElementById("imgModal").classList.remove("open");
          document.getElementById("imgModalPic").src = "";
          GALLERY.list = []; GALLERY.index = 0;
      }
      function prevImg(e) { if (e) e.stopPropagation(); showModalAt(GALLERY.index - 1); }
      function nextImg(e) { if (e) e.stopPropagation(); showModalAt(GALLERY.index + 1); }
      document.addEventListener("keydown", function (e) {
          var open = document.getElementById("imgModal").classList.contains("open");
          if (!open) return;
          if (e.key === "Escape") closeViewer();
          if (e.key === "ArrowLeft") prevImg(e);
          if (e.key === "ArrowRight") nextImg(e);
      });
  </script>

  <h2 class="mb-3">Elegí tu premio</h2>
  <asp:Label ID="lblMsg" runat="server" CssClass="text-danger d-block mb-2" Visible="false" />

  <asp:Repeater ID="repPremios" runat="server" OnItemCommand="repPremios_ItemCommand" OnItemDataBound="repPremios_ItemDataBound">
    <HeaderTemplate><div class="cards"></HeaderTemplate>

    <ItemTemplate>
      <div class="card">
        <div class="main-frame">
          <img id='<%# "imgMain_" + Eval("Id") %>'
               src='<%# ResolveUrl(Eval("ImagenPrincipal") as string) %>'
               alt="Premio" onclick="openViewerFrom(this,this.src)" />
        </div>

        <asp:HiddenField ID="hidMainId" runat="server" Value='<%# "imgMain_" + Eval("Id") %>' />

        <div class="body">
          <h4 class="title"><%# Eval("Nombre") %></h4>
          <p class="muted"><%# Eval("Descripcion") %></p>

          <div class="thumbs">
            <asp:Repeater ID="repThumbs" runat="server" OnItemDataBound="repThumbs_ItemDataBound">
              <ItemTemplate>
                <asp:HiddenField ID="hidThumbUrl" runat="server" Value='<%# Container.DataItem as string %>' />
                <img runat="server" id="imgThumb" alt="Miniatura" />
              </ItemTemplate>
            </asp:Repeater>
          </div>

          <div class="actions">
            <asp:Button runat="server"
                        CommandName="elegir"
                        CommandArgument='<%# Eval("Id") %>'
                        Text="Quiero este"
                        CssClass="btn btn-primary btn-slim" />
          </div>
        </div>
      </div>
    </ItemTemplate>

    <FooterTemplate></div></FooterTemplate>
  </asp:Repeater>

  <div id="imgModal" class="viewer" onclick="closeViewer()">
    <div class="viewer-box" onclick="event.stopPropagation();">
      <button type="button" class="ctrl close" aria-label="Cerrar" onclick="closeViewer()">
        <svg viewBox="0 0 24 24"><path d="M18.3 5.7a1 1 0 0 0-1.4-1.4L12 9.17 7.1 4.3A1 1 0 1 0 5.7 5.7l4.88 4.9-4.88 4.88a1 1 0 1 0 1.4 1.42L12 12.99l4.9 4.91a1 1 0 0 0 1.4-1.42l-4.88-4.88 4.88-4.9Z"/></svg>
      </button>
      <button type="button" class="ctrl left" onclick="prevImg(event)" aria-label="Anterior">
        <svg viewBox="0 0 24 24"><path d="M15.41 7.41 14 6l-6 6 6 6 1.41-1.41L10.83 12z"/></svg>
      </button>
      <img id="imgModalPic" alt="Vista ampliada" />
      <button type="button" class="ctrl right" onclick="nextImg(event)" aria-label="Siguiente">
        <svg viewBox="0 0 24 24"><path d="M8.59 16.59 10 18l6-6-6-6-1.41 1.41L13.17 12z"/></svg>
      </button>
    </div>
  </div>
</asp:Content>
