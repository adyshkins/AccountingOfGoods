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
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.ChangeQuantityProduct = new HashSet<ChangeQuantityProduct>();
        }
    
        public int ID { get; set; }
        public string NameProduct { get; set; }
        public int IDCategory { get; set; }
        public Nullable<double> InStock { get; set; }
        public int IDUnit { get; set; }
        public Nullable<int> IDStorage { get; set; }
    
        public virtual CategoryProduct CategoryProduct { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChangeQuantityProduct> ChangeQuantityProduct { get; set; }
        public virtual Storage Storage { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
