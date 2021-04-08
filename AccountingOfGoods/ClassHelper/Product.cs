using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingOfGoods.EF
{
    public partial class Product
    {
        public string GetId { get => $"Артикул: {ID}"; }
        public string GetName { get => $"{NameProduct}"; }
        public string GetUnit { get => $"Единица измерения: {Unit.NameUnit}"; }
        public string GetStockAndStorage 
        {
            get
            {
                if (InStock == null || Storage.NumberStorage == null)
                {
                    return $"Остаток на складе: 0     № секции хранения: -";
                }
                else
                {
                    return $"Остаток на складе: {InStock}     № секции хранения: {Storage.NumberStorage}";
                }                
            }
           
        }
        public string GetCategory { get => $"Категория товара: {CategoryProduct.NameCategory}"; } 

    }
}
