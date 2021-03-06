//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace agendae.basea
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class persona: IValidatableObject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public persona()
        {
            this.correo = new HashSet<correo>();
        }
    
        public int id_persona { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public Nullable<int> numero1 { get; set; }
        public Nullable<int> numero2 { get; set; }
        public Nullable<bool> disponible { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<correo> correo { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errores = new List<ValidationResult>();
            if (numero1 == null && numero2 == null)
            {
                errores.Add(new ValidationResult("No puede dejar ambos numeros vacios"));
            }
            return errores;
        }
    }
}
