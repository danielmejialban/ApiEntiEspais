//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiEntiEspais
{
    using System;
    using System.Collections.Generic;
    
    public partial class Telefon
    {
        public int id { get; set; }
        public string rao { get; set; }
        public string numero { get; set; }
        public int id_entitat { get; set; }
    
        public virtual Entitat Entitat { get; set; }
    }
}