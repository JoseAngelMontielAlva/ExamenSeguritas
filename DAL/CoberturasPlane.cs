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
    
    public partial class CoberturasPlane
    {
        public int IdCoberturasPlanes { get; set; }
        public Nullable<int> IdCobertura { get; set; }
        public Nullable<int> IdPlanes { get; set; }
    
        public virtual Cobertura Cobertura { get; set; }
        public virtual Plane Plane { get; set; }
    }
}