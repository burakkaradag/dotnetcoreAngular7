using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelProject.DTOS
{
    public class PersonelDTO
    {
        public int personelId { get; set; }
        public string personelAd { get; set; }
        public string personelSoyad { get; set; }
        public string resimYol { get; set; }
        public string sehirAd { get; set; }
        public int sehirId { get; set; }
        
    }
}
