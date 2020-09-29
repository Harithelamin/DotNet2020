using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITPE3200_1_20H_nor_way.DAL;
using ITPE3200_1_20H_nor_way.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITPE3200_1_20H_nor_way.Controllers
{
    public class StationController : Controller
    {
        private readonly IStationRepository _db;

        public StationController(IStationRepository db)
        {
            _db = db;
        }
        public IList<Station> getStation()
        {
            return _db.GetAllStations();
        }
        public static List<SelectListItem> PartsActive()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "Oslo", Value = "Y" });
            list.Add(new SelectListItem { Text = "Sta", Value = "A" });
            list.Add(new SelectListItem { Text = "Berf", Value = "N" });
            return list;
        }
    }
}
