//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cobertura
    {
        public Cobertura()
        {
            this.CoberturasPlanes = new HashSet<CoberturasPlane>();
            this.PlanesCoberturas = new HashSet<PlanesCobertura>();
        }
    
        public int IdCobertura { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime FechaModificacion { get; set; }
    
        public virtual ICollection<CoberturasPlane> CoberturasPlanes { get; set; }
        public virtual ICollection<PlanesCobertura> PlanesCoberturas { get; set; }
    }
}
