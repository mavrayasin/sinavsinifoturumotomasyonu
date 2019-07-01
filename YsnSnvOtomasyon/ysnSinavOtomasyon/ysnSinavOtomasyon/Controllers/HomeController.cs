using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ysnSinavOtomasyon.Models;

namespace ysnSinavOtomasyon.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            sinavdbEntities sinav_db = new sinavdbEntities();

            derslikPlanClass dpc = new derslikPlanClass();

            dpc.derslikler = sinav_db.Derslik.ToList();
            dpc.sinavlar = sinav_db.Sinav.ToList();

            return View(dpc);
        }

        public ActionResult Listeler()
        {
            sinavdbEntities sinav_db = new sinavdbEntities();

            derslikPlanClass dpc = new derslikPlanClass();

            dpc.derslikler = sinav_db.Derslik.ToList();
            dpc.sinavlar = sinav_db.Sinav.ToList();

            return View(dpc);
        }

        public ActionResult sinavListesiniGoster(int sinavSecilen, int derslikSecilen)
        {
            sinavdbEntities sinav_db = new sinavdbEntities();

            derslikPlanClass dpc = new derslikPlanClass();

            dpc.sinavOTurumPlani = sinav_db.SinavListe.Where(i => i.DerslikID == derslikSecilen && i.SinavID == sinavSecilen).ToList();

            return View(dpc);
        }


        [HttpPost]
        public ActionResult sinavListesiOlustur(int sinavSecilen, int derslikSecilen)
        {
            sinavdbEntities sinav_db = new sinavdbEntities();

            var sinav_Liste = sinav_db.SinavListe.Where(i => i.DerslikID == derslikSecilen && i.SinavID == sinavSecilen).ToList();

            if (sinav_Liste.Count == 0)
            {
                var ogrenciler = sinav_db.Ogrenci.OrderBy(a => Guid.NewGuid()).ToList();

                int sayac = 1;


                foreach (var item in ogrenciler)
                {
                    SinavListe sl = new SinavListe();
                    
                    sl.DerslikID = derslikSecilen;
                    sl.SinavID = sinavSecilen;
                    sl.OgrenciID = item.OgrenciId;
                    sl.SiraNo = sayac;

                    sinav_db.SinavListe.Add(sl);
                    sinav_db.SaveChanges();

                    sayac++;
                }
            }

            return RedirectToAction("sinavListesiniGoster", new { sinavSecilen = sinavSecilen, derslikSecilen = derslikSecilen });
        }
    }
}