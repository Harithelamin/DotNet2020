﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITPE3200_1_20H_nor_way.DAL;
using ITPE3200_1_20H_nor_way.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITPE3200_1_20H_nor_way.Controllers
{
    [Route("[controller]/[action]")]
    public class TripController : Controller
    {
        private readonly ITripRepository _db;

        public TripController(ITripRepository db)
        {
            _db = db;
        }
        public async Task<bool> Save(TripVM tripVM)
        {
            return await _db.settInn(tripVM);            
        }
        public async Task<List<TripVM>> GetAll()
        {
            return await _db.getAll();
        }
        public async Task<bool> RemoveBiId(int id)
        {
            return await _db.slettTrip(id);
        }
        private IEnumerable<string> GetAllxx()
        {
            return new List<string>
            {
                "ACT",
                "New South Wales",
                "Northern Territories",
                "Queensland",
                "South Australia",
                "Victoria",
                "Western Australia",
            };
        }
    }
}
