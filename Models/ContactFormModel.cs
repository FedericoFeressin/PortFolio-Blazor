using System.ComponentModel.DataAnnotations;

namespace PortFolio_Blazor.Models;

public sealed class ContactFormModel
{
    [Required(ErrorMessage = "Ingresá tu nombre.")]
    [StringLength(80, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 80 caracteres.")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Ingresá un nombre válido.")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "Ingresá tu email.")]
    [EmailAddress(ErrorMessage = "Ingresá un email válido.")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Ingresá un email válido.")]
    [StringLength(120, ErrorMessage = "El email es demasiado largo.")]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "Escribí un mensaje.")]
    [StringLength(1200, MinimumLength = 10, ErrorMessage = "El mensaje debe tener al menos 10 caracteres.")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Ingresá un mensaje válido.")]
    public string Message { get; set; } = "";

    public void Reset()
    {
        Name = "";
        Email = "";
        Message = "";
    }
}
