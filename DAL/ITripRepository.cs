using ITPE3200_1_20H_nor_way.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITPE3200_1_20H_nor_way.DAL
{
    public interface ITripRepository
    {
        Task<List<TripVM>> getAll();
        Task<bool> settInn(TripVM innTrip);
        Task<TripVM> getAtrip(int id);
        Task<bool> slettTrip(int slettId);
        Task<bool> update(TripVM innTrip);
    }
}