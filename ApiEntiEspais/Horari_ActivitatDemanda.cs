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
    
    public partial class Horari_ActivitatDemanda
    {
        public int id { get; set; }
        public System.TimeSpan horari_inici { get; set; }
        public System.TimeSpan horari_final { get; set; }
        public int id_activitatDemanda { get; set; }
        public int id_dia { get; set; }
    
        public virtual ActivitatsDemanades ActivitatsDemanades { get; set; }
        public virtual Dia Dia { get; set; }
    }
}
