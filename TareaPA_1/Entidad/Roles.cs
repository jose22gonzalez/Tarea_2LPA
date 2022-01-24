using System.Windows.Input;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace TareaPA_1
{
    public class Roles
    {
       [Key] public string? RolId { get; set; }

        public string? Descripcion { get; set; }

        public string? Fecha { get; set; }
        public Roles(string? rolId,string? descripcion, string? fecha)
        {
            this.RolId = rolId;
            this.Descripcion = descripcion;
            this.Fecha = fecha;
        }

      

       
    }
}
