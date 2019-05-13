using PersonelProject.Data;
using PersonelProject.DTOS;
using PersonelProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelProject.Repository
{
    public class Repository
    {
        public class RepPersonel : BaseRepository<Personel>
        {
            public RepPersonel(PersonelContext db) : base(db)
            {
            }

            public ICollection<PersonelDTO> doldur()
            {
                return Set().Select(x => new PersonelDTO
                {
                    personelId = x.PersonelId,
                    personelAd = x.PersonelAd,
                    personelSoyad=x.PersonelSoyad,
                    resimYol = x.PersonelResim,
                    sehirAd =x.Sehir.SehirAd,
                     sehirId=x.SehirId
                    
                }).ToList();
            }

        }

        public class RepSehir : BaseRepository<Sehir>
        {
            public RepSehir(PersonelContext db) : base(db)
            {
            }

            public ICollection<SehirDTO> doldur()
            {
               return Set().Select(x => new SehirDTO
                {
                     sehirId=x.SehirId,
                     sehirAd=x.SehirAd,
                     resimYol=x.SehirResim
                }).ToList();
            }
        }

        public class RepPerGaleri : BaseRepository<PerGaleri>
        {
            public RepPerGaleri(PersonelContext db) : base(db)
            {
            }
        }

        public class RepSehGaleri : BaseRepository<SehGaleri>
        {
            public RepSehGaleri(PersonelContext db) : base(db)
            {
            }
        }
    }
}
