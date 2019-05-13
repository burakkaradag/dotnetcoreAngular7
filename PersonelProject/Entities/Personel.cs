using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelProject.Entities
{
    [Table("Personel")]
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }
        public string PersonelAd { get; set; }
        public string PersonelSoyad { get; set; }
        public string PersonelResim { get; set; }
        public int SehirId { get; set; }

        [ForeignKey("SehirId")]
        public virtual Sehir Sehir { get; set; }
        public virtual ICollection<PerGaleri> PerGaleri { get; set; }

    }
    [Table("Sehir")]
    public class Sehir
    {
        [Key]
        public int SehirId { get; set; }
        public string SehirAd { get; set; }
        public string SehirResim { get; set; }

        public virtual ICollection<Personel> Personel { get; set; }
        public virtual ICollection<SehGaleri> SehGaleri { get; set; }
    }
    [Table("PerGaleri")]
    public class PerGaleri
    {
        [Key]
        public int Id { get; set; }
        public string Resim { get; set; }
        public int PersonelId { get; set; }

        [ForeignKey("PersonelId")]
        public virtual Personel Personel { get; set; }

    }
    [Table("SehGaleri")]
    public class SehGaleri
    {
        [Key]
        public int Id { get; set; }
        public string SehirAd { get; set; }
        public int SehirId { get; set; }

        [ForeignKey("SehirId")]
        public virtual Sehir Sehir { get; set; }

    }
}
