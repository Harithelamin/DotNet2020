using ITPE3200_1_20H_nor_way.Models;
using System.Collections.Generic;

namespace ITPE3200_1_20H_nor_way.DAL
{
    public interface IStationRepository
    {
        IList<Station> GetAllStations();
        IList<Station> GetAllStationById(int stationId);
    }
}