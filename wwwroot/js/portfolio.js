// Módulo ES6 - importado dinámicamente via IJSRuntime (Clase 13)

export function copiarAlPortapapeles(texto) {
    return navigator.clipboard.writeText(texto);
}

export function scrollToTop() {
    window.scrollTo({ top: 0, behavior: 'smooth' });
}

export function enfocarElemento(elementId) {
    const el = document.getElementById(elementId);
    el?.focus();
}

export function guardarEnLocalStorage(clave, valor) {
    localStorage.setItem(clave, valor);
}

export function recuperarDeLocalStorage(clave) {
    return localStorage.getItem(clave);
}

export function obtenerResolucionPantalla() {
    return { ancho: window.screen.width, alto: window.screen.height };
}
