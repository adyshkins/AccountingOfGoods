//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccountingOfGoods.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class TypeChange
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypeChange()
        {
            this.ChangeQuantityProduct = new HashSet<ChangeQuantityProduct>();
        }
    
        public int ID { get; set; }
        public string NameTypeChange { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChangeQuantityProduct> ChangeQuantityProduct { get; set; }
    }
}
