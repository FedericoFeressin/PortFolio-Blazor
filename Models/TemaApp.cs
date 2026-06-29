namespace PortFolio_Blazor.Models;

public sealed class TemaApp
{
    public bool EsModoOscuro { get; set; } = true;

    public string NombreTema => EsModoOscuro ? "oscuro" : "claro";
}
