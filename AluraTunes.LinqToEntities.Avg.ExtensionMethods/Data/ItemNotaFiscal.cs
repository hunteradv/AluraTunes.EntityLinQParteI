//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AluraTunes.LinqToEntities.Avg.ExtensionMethods.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ItemNotaFiscal
    {
        public int ItemNotaFiscalId { get; set; }
        public int NotaFiscalId { get; set; }
        public int FaixaId { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
    
        public virtual Faixa Faixa { get; set; }
        public virtual NotaFiscal NotaFiscal { get; set; }
    }
}
