using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonelProject.Data;
using PersonelProject.DTOS;
using PersonelProject.Entities;

using static PersonelProject.Repository.Repository;

namespace PersonelProject.Controllers
{
    public class PersonelController : Controller
    {
        RepPersonel _reppersonel;
        PersonelContext _db;
        public PersonelController(RepPersonel reppersonel, PersonelContext db )
        {
            _reppersonel = reppersonel;
            _db = db;
           
        }
        public JsonResult Liste()
        {

            ICollection<PersonelDTO> plist = _reppersonel.doldur().ToList();
            //var plist = _db.Personel.ToList();

            return Json(plist);
        }
        [HttpPost]
        public async Task<JsonResult> Guncel([FromBody]PersonelDTO pr)
        {
            Personel personel = new Personel();
            personel.PersonelId = pr.personelId;
            personel.PersonelAd = pr.personelAd;
            personel.PersonelSoyad = pr.personelSoyad;
            personel.SehirId = pr.sehirId;
            
            _reppersonel.Save(personel);
            await _reppersonel.Comit();

            return Json(pr);
        }
        [HttpPost]
        public async Task<JsonResult> Ekle([FromBody]PersonelDTO pr)
        {
            Personel personel = new Personel();
      
            personel.PersonelAd = pr.personelAd;
            personel.PersonelSoyad = pr.personelSoyad;
            personel.SehirId = pr.sehirId;

            _reppersonel.Add(personel);
            await _reppersonel.Comit();

            return Json(pr);
        }
        [HttpDelete]
        public async Task<JsonResult> Sil(int id)
        {
            Personel p = await _reppersonel.Find(id);

            _reppersonel.Delete(p);
            await _reppersonel.Comit();

            return Json(p);
        }
    }
}