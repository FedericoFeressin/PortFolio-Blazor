(() => {
  const storageKey = "portfolio.theme";
  const root = document.documentElement;

  function getPreferred() {
    const saved = localStorage.getItem(storageKey);
    if (saved === "dark" || saved === "light") return saved;
    return window.matchMedia?.("(prefers-color-scheme: dark)").matches
      ? "dark"
      : "light";
  }

  function apply(theme) {
    root.setAttribute("data-theme", theme);
    root.style.colorScheme = theme;
  }

  function isDark() {
    return (root.getAttribute("data-theme") || getPreferred()) === "dark";
  }

  function toggle() {
    const next = isDark() ? "light" : "dark";
    localStorage.setItem(storageKey, next);
    apply(next);
    return next;
  }

  apply(getPreferred());

  window.portfolioTheme = { toggle, apply, isDark };
})();
