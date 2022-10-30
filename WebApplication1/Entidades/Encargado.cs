using System.ComponentModel.DataAnnotations;
using WebApiHuevos3.Validaciones;

namespace WebApiHuevos3.Entidades
{
    public class Encargado
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 10, ErrorMessage = "El campo {0} solo puede tener hasta 10 caracteres")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }
        public List<Huevo> huevos { get; set; }
    }
}
