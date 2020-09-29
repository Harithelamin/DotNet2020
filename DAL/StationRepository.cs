using ITPE3200_1_20H_nor_way.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITPE3200_1_20H_nor_way.DAL
{
    public class StationRepository : IStationRepository
    {
        private readonly Nor_Way_Context _db;

        public StationRepository(Nor_Way_Context db)
        {
            _db = db;
        }
      
        public IList<Station> GetAllStations()
        {
            var query = from s in _db.Stations
                        select s;
            var content = query.ToList<Station>();
            return content;
        }
        public IList<Station> GetAllStationById(int stationId)
        {
            var query = from s in _db.Stations
                        where s.StationID == stationId
                        select s;
            var content = query.ToList<Station>();
            return content;
        }
    }
}