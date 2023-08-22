using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeronaAkademi.Data.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Tipe gore ders,paket veya danışmalık idlerini verir
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// 1:Ders
        /// 2:Paket
        /// 3:Danışmalık
        /// </summary>
        public int Type { get; set; }
        public virtual ICollection<Basket> Basket { get; set; }
    }
}
