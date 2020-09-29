using ITPE3200_1_20H_nor_way.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITPE3200_1_20H_nor_way.DAL
{
    public interface IBestillingRepository
    {
        Task<List<BestillingVM>> getAll();
        Task<bool> settInn(BestillingVM innBestilling);
        Task<List<TripVM>> SugestedTrips(BestillingVM bestillingVM);
        Task<BestillingVM> getPrice(BestillingVM innBestilling);
    }
}