//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Heroes5_ArmyCalc
{
    using System;
    using System.Collections.Generic;
    
    public partial class Units
    {
        public int ID { get; set; }
        public string NameBase { get; set; }
        public string NameLeft { get; set; }
        public string NameRight { get; set; }
        public string Faction { get; set; }
        public Nullable<int> Tier { get; set; }
        public string Description { get; set; }
        public string ImageBase { get; set; }
        public string ImageLeft { get; set; }
        public string ImageRight { get; set; }
        public int GoldCostBase { get; set; }
        public Nullable<int> GoldCostUpg { get; set; }
        public Nullable<int> PopulationBase { get; set; }
    }
}
