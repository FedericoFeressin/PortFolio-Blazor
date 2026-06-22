# Portfolio — Federico Feressin

Sitio web de portfolio personal desarrollado con **ASP.NET Blazor Server**. Presenta perfil profesional, proyectos, experiencia laboral y un formulario de contacto, con contenido editable mediante archivos JSON sin recompilar la aplicación.

---

## Tabla de contenidos

- [Descripción general](#descripción-general)
- [Características](#características)
- [Tecnologías utilizadas](#tecnologías-utilizadas)
- [Estructura del proyecto](#estructura-del-proyecto)
- [Requisitos previos](#requisitos-previos)
- [Instalación y ejecución](#instalación-y-ejecución)
- [Páginas y rutas](#páginas-y-rutas)
- [Personalización del contenido](#personalización-del-contenido)
- [Formulario de contacto](#formulario-de-contacto)
- [Arquitectura](#arquitectura)
- [Estilos y tema visual](#estilos-y-tema-visual)
- [Despliegue](#despliegue)

---

## Descripción general

Este proyecto es un portfolio web moderno y responsive orientado a mostrar el perfil de un desarrollador full stack. La aplicación utiliza **Blazor Server** con modo interactivo (`InteractiveServer`) en componentes que requieren interactividad del usuario (navegación móvil, formulario de contacto).

El contenido principal — datos personales, habilidades, experiencia y proyectos — se carga desde archivos JSON ubicados en `wwwroot/data/`, lo que permite actualizar el sitio editando esos archivos directamente.

---

## Características

- **Página de inicio** con hero, avatar, resumen y puntos destacados del perfil.
- **Sobre mí** con biografía extendida, barras de habilidades por categoría y línea de tiempo de experiencia.
- **Proyectos** en grilla responsive con tarjetas que incluyen imagen, tecnologías, enlace a demo y repositorio.
- **Contacto** con formulario validado y enlaces a redes sociales.
- **Navegación responsive** con menú hamburguesa en dispositivos móviles.
- **Tema claro/oscuro** gestionado con JavaScript y `localStorage` (soporte preparado en `TopNav.razor`).
- **Estados de carga** con skeletons en la grilla de proyectos.
- **Página 404** personalizada para rutas inexistentes.
- **Mensajes de contacto** persistidos localmente en formato JSONL.

---

## Tecnologías utilizadas

| Área | Tecnología |
|------|------------|
| Framework | ASP.NET Core / Blazor Server (.NET 10) |
| Lenguaje | C# |
| UI | Razor Components |
| Estilos | CSS personalizado + Tailwind CSS v4 |
| Tipografía | [Plus Jakarta Sans](https://fonts.google.com/specimen/Plus+Jakarta+Sans) (Google Fonts) |
| Iconos | [Bootstrap Icons](https://icons.getbootstrap.com/) |
| Base CSS | Bootstrap 5 |
| Datos | JSON estático en `wwwroot/data/` |
| Interactividad cliente | JavaScript (`theme.js`) + Blazor interactivo |

---

## Estructura del proyecto

```
PortFolio-Blazor/
├── Components/
│   ├── App.razor                 # Documento HTML raíz
│   ├── Routes.razor              # Enrutamiento de la aplicación
│   ├── _Imports.razor            # Directivas using globales
│   ├── Layout/
│   │   ├── MainLayout.razor      # Layout principal (nav + contenido + footer)
│   │   ├── NavMenu.razor         # Menú lateral (plantilla base)
│   │   └── ReconnectModal.razor  # Modal de reconexión Blazor
│   ├── Pages/
│   │   ├── Inicio.razor          # Ruta: /
│   │   ├── SobreMi.razor         # Ruta: /sobre-mi
│   │   ├── Proyectos.razor       # Ruta: /proyectos
│   │   ├── Contacto.razor        # Ruta: /contacto
│   │   ├── NotFound.razor        # Ruta: /not-found (404)
│   │   └── Error.razor           # Ruta: /Error
│   └── Portfolio/
│       ├── TopNav.razor          # Barra de navegación superior
│       ├── SiteFooter.razor        # Pie de página
│       ├── PageBanner.razor      # Banner de título en subpáginas
│       ├── ProjectsGrid.razor      # Grilla de proyectos
│       ├── ProjectCard.razor     # Tarjeta individual de proyecto
│       ├── ContactSection.razor  # Sección de contacto completa
│       ├── ContactForm.razor     # Formulario de contacto
│       └── SocialLinks.razor     # Enlaces a redes sociales
├── Models/
│   ├── SiteProfile.cs            # Modelo del perfil del sitio
│   ├── Project.cs                # Modelo de proyecto
│   └── ContactFormModel.cs       # Modelo del formulario de contacto
├── Services/
│   ├── ProfileService.cs         # Lectura de profile.json
│   ├── ProjectsService.cs        # Lectura de projects.json
│   └── ContactService.cs         # Guardado de mensajes de contacto
├── wwwroot/
│   ├── data/
│   │   ├── profile.json          # Datos del perfil personal
│   │   └── projects.json         # Listado de proyectos
│   ├── Fotos/                    # Imágenes del portfolio
│   ├── app.css                   # Estilos principales del sitio
│   ├── theme.js                  # Lógica de tema claro/oscuro
│   └── lib/bootstrap/            # Bootstrap (dist)
├── App_Data/                     # Mensajes de contacto (generado en runtime)
├── Program.cs                    # Configuración y arranque de la app
├── PortFolio-Blazor.csproj       # Archivo de proyecto .NET
├── appsettings.json              # Configuración de la aplicación
└── Properties/
    └── launchSettings.json       # Perfiles de ejecución (HTTP/HTTPS)
```

---

## Requisitos previos

- [.NET 10 SDK](https://dotnet.microsoft.com/download) o superior
- Navegador web moderno (Chrome, Firefox, Edge, Safari)
- *(Opcional)* [Node.js](https://nodejs.org/) si se desea modificar o compilar estilos con Tailwind

---

## Instalación y ejecución

### 1. Clonar o descargar el repositorio

```bash
git clone <url-del-repositorio>
cd PortFolio-Blazor
```

### 2. Restaurar dependencias y compilar

```bash
dotnet restore
dotnet build
```

### 3. Ejecutar en modo desarrollo

**Solo HTTP** (recomendado en desarrollo):

```bash
dotnet run --launch-profile http
```

La aplicación estará disponible en: **http://localhost:5243**

**Con HTTPS**:

```bash
dotnet run --launch-profile https
```

URLs: **https://localhost:7090** y **http://localhost:5243**

> En desarrollo, la redirección HTTPS está deshabilitada en `Program.cs` para evitar errores cuando se usa únicamente el perfil HTTP.

---

## Páginas y rutas

| Ruta | Componente | Descripción |
|------|------------|-------------|
| `/` | `Inicio.razor` | Página principal con presentación, avatar y resumen |
| `/sobre-mi` | `SobreMi.razor` | Biografía, habilidades técnicas y experiencia laboral |
| `/proyectos` | `Proyectos.razor` | Galería de proyectos con enlaces a demo y repositorio |
| `/contacto` | `Contacto.razor` | Formulario de contacto y redes sociales |
| `/not-found` | `NotFound.razor` | Página de error 404 |

---

## Personalización del contenido

### Perfil personal — `wwwroot/data/profile.json`

Contiene toda la información del desarrollador:

```json
{
  "name": "Tu Nombre",
  "role": "Full Stack Developer",
  "tagline": "Tu frase destacada",
  "shortBio": "Biografía corta para la home",
  "longBio": "Biografía extendida para Sobre mí",
  "location": "Remoto / Argentina",
  "availability": "Disponible para proyectos",
  "email": "tu@email.com",
  "avatarUrl": "/Fotos/tu-foto.png",
  "social": {
    "linkedIn": "https://linkedin.com/in/tu-perfil",
    "gitHub": "https://github.com/tu-usuario",
    "twitter": null,
    "portfolio": null
  },
  "highlights": ["Punto 1", "Punto 2"],
  "skillGroups": [
    {
      "category": "Backend",
      "level": 88,
      "label": "Avanzado",
      "items": ["C#", "ASP.NET Core"]
    }
  ],
  "experience": [
    {
      "period": "2024 — Presente",
      "title": "Desarrollador Full Stack",
      "company": "Empresa",
      "description": "Descripción del rol"
    }
  ]
}
```

| Campo | Descripción |
|-------|-------------|
| `level` | Porcentaje (0–100) para la barra de progreso de habilidades |
| `avatarUrl` | Ruta relativa a `wwwroot/`; si está vacío, se muestran las iniciales |
| `highlights` | Tarjetas de resumen en la página de inicio |

### Proyectos — `wwwroot/data/projects.json`

Array de proyectos. Cada elemento requiere `id`, `title`, `description` y `repoUrl`:

```json
[
  {
    "id": "mi-proyecto",
    "title": "Nombre del proyecto",
    "description": "Descripción breve del proyecto",
    "liveUrl": "https://demo-del-proyecto.com",
    "repoUrl": "https://github.com/usuario/repo",
    "badge": "Destacado",
    "imageUrl": "/Fotos/proyecto.png",
    "technologies": ["Blazor", "C#", "SQL Server"],
    "accentA": "#6366f1",
    "accentB": "#ec4899"
  }
]
```

| Campo | Descripción |
|-------|-------------|
| `liveUrl` | Enlace a la demo en vivo (opcional) |
| `imageUrl` | Imagen de la miniatura; si no hay, se usa un gradiente con `accentA` y `accentB` |
| `badge` | Etiqueta opcional (ej.: "Destacado", "UI/UX") |

### Imágenes

Colocar las imágenes en `wwwroot/Fotos/` y referenciarlas con rutas como `/Fotos/nombre.png`.

---

## Formulario de contacto

El formulario en `/contacto` utiliza **validación por Data Annotations** (`ContactFormModel`) y el componente `EditForm` de Blazor.

Al enviarse correctamente, el mensaje se guarda en:

```
App_Data/contact-messages.jsonl
```

Cada línea es un objeto JSON con:

```json
{
  "createdAtUtc": "2026-06-22T12:00:00+00:00",
  "name": "Nombre del visitante",
  "email": "email@ejemplo.com",
  "message": "Contenido del mensaje",
  "userAgent": ""
}
```

> **Nota:** Los mensajes se almacenan en el servidor local. Para producción, conviene integrar un servicio de email (SendGrid, SMTP, etc.) o una base de datos.

---

## Arquitectura

### Flujo de datos

```
wwwroot/data/*.json
        │
        ▼
  ProfileService / ProjectsService  ──►  Componentes Razor  ──►  UI
        │
        ▼
   Modelos C# (SiteProfile, Project)

ContactForm  ──►  ContactService  ──►  App_Data/contact-messages.jsonl
```

### Servicios registrados (`Program.cs`)

| Servicio | Lifetime | Función |
|----------|----------|---------|
| `ProfileService` | Scoped | Lee y cachea `profile.json` |
| `ProjectsService` | Scoped | Lee y cachea `projects.json` |
| `ContactService` | Singleton | Persiste mensajes de contacto |

### Modo de renderizado

- La mayoría de las páginas usan renderizado estático del servidor.
- `TopNav`, `ContactSection` y `ContactForm` usan `@rendermode InteractiveServer` para interactividad en tiempo real vía SignalR.

---

## Estilos y tema visual

Los estilos principales están en `wwwroot/app.css`:

- **Design tokens** con variables CSS (`--bg`, `--primary`, `--radius`, etc.).
- **Tema oscuro** por defecto; **tema claro** activado con `html[data-theme="light"]`.
- Componentes reutilizables: `.card`, `.btn`, `.chip`, `.pill`, `.grid`, animaciones `.reveal`.
- Tailwind CSS importado con `@import "tailwindcss"`.

### Cambio de tema

`wwwroot/theme.js` expone la API global `portfolioTheme`:

```javascript
portfolioTheme.toggle();   // Alterna entre claro y oscuro
portfolioTheme.isDark();   // Devuelve true si el tema actual es oscuro
portfolioTheme.apply("dark"); // Aplica un tema específico
```

La preferencia se guarda en `localStorage` bajo la clave `portfolio.theme`.

---

## Despliegue

### Publicar la aplicación

```bash
dotnet publish -c Release -o ./publish
```

### Consideraciones para producción

1. Configurar `ASPNETCORE_ENVIRONMENT=Production`.
2. Habilitar HTTPS (`UseHttpsRedirection` ya está condicionado en `Program.cs`).
3. Asegurar permisos de escritura en `App_Data/` si se usa el formulario de contacto.
4. Servir la carpeta `publish/` con IIS, Azure App Service, Docker u otro host compatible con ASP.NET Core.

### Variables de entorno

| Variable | Valor típico |
|----------|--------------|
| `ASPNETCORE_ENVIRONMENT` | `Development` / `Production` |
| `ASPNETCORE_URLS` | `http://0.0.0.0:5243` (opcional) |

---

## Autor

**Federico Feressin** — Full Stack Developer

- GitHub: [FedericoFeressin](https://github.com/FedericoFeressin)
- LinkedIn: [federico-feressin](https://www.linkedin.com/in/federico-feressin-45704331b/)
- Email: fedeferessin2001@gmail.com

---

## Licencia

Proyecto personal. Consultar con el autor antes de reutilizar el contenido o el diseño con fines comerciales.
