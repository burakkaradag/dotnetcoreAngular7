using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonelProject.DTOS;
using PersonelProject.Entities;
using static PersonelProject.Repository.Repository;

namespace PersonelProject.Controllers
{
    public class SehirController : Controller
    {
        RepSehir  _repsehir;
        IMapper _map;
        public SehirController(RepSehir repsehir, IMapper map)
        {
            _repsehir = repsehir;
            _map = map;
        }
        public JsonResult Liste()
        {
            ICollection<SehirDTO> slist = _repsehir.doldur();

            return Json(slist);
        }
        [HttpPost]
        public async Task< JsonResult> Guncel([FromBody]SehirDTO sh)
        {
            Sehir sehir = new Sehir();
            //sehir.SehirId = sh.sehirId;
            //sehir.SehirAd = sh.sehirAd;
            sehir = _map.Map(sh, sehir);
            _repsehir.Save(sehir);
            await _repsehir.Comit();

            return Json(sh);
        }
        [HttpDelete]
        public async Task<JsonResult> Sil(int id)
        {
            Sehir s = await _repsehir.Find(id);
            
            _repsehir.Delete(s);
           await _repsehir.Comit();

            return Json(s);
        }
        [HttpPost]
        public async Task<JsonResult> Ekle([FromBody]SehirDTO sh)
        {
            Sehir sehir = new Sehir();

            //sehir.SehirAd = sh.sehirAd;
            sehir = _map.Map(sh, sehir);
            sehir.SehirId = 0;

            _repsehir.Add(sehir);
            await _repsehir.Comit();

            return Json(sh);
        }
    }
}