using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ysnSinavOtomasyon.Models;

namespace ysnSinavOtomasyon.Models
{
    public class derslikPlanClass
    {
        public List<Sinav> sinavlar { get; set; }
        public List<Derslik> derslikler { get; set; }

        public List<SinavListe> sinavOTurumPlani { get; set; }
    }
}