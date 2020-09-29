using ITPE3200_1_20H_nor_way.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ITPE3200_1_20H_nor_way.DAL
{
    public class BestillingRepository : IBestillingRepository
    {
        private readonly Nor_Way_Context _db;

        public BestillingRepository(Nor_Way_Context db)
        {
            _db = db;
        }
        public async Task<List<BestillingVM>> getAll()
        {
            try
            {
                List<BestillingVM> Bestillings = await _db.Bestillings.Select(b => new BestillingVM
                {
                    id = b.ID,
                    Date = b.Date,
                    departure = b.Departure,
                    arrival = b.Arrival,
                    numberOfAdults = b.NumberOfAdults,
                    numberOfStudents = b.NumberOfStudents,
                    numberOfKids = b.NumberOfKids,
                    numberOfSeniors = b.NumberOfSeniors
                }).ToListAsync();
                return Bestillings;
            }
            catch
            {
                return null;
            }
        }

        public async Task<BestillingVM> getPrice(BestillingVM innBestilling)
        {
            BestillingVM bestillingVM = new BestillingVM();
            //local variables
            float adultsTotal = 0;
            float studentsTotal = 0;
            float kidsTotal = 0;
            float seniorTotal = 0;
            //float total = 0;
            //
            bestillingVM.departure = innBestilling.departure;
            bestillingVM.arrival = innBestilling.arrival;
            bestillingVM.tripId = innBestilling.tripId;
            bestillingVM.numberOfAdults = innBestilling.numberOfAdults;
            bestillingVM.numberOfStudents = innBestilling.numberOfStudents;
            bestillingVM.numberOfKids = innBestilling.numberOfKids;
            bestillingVM.numberOfSeniors = innBestilling.numberOfSeniors;

            try
            {

                var selectedTrip = await _db.Trips.FirstOrDefaultAsync(s => s.TripID == innBestilling.tripId);
                if (selectedTrip == null) { return bestillingVM; }
                else
                    adultsTotal = innBestilling.numberOfAdults * selectedTrip.AdultPrice;
                    studentsTotal = innBestilling.numberOfStudents * selectedTrip.StudentPrice;
                    kidsTotal = innBestilling.numberOfKids * selectedTrip.ChildPrice;
                    seniorTotal = innBestilling.numberOfSeniors * selectedTrip.SeniorPrice;

                    bestillingVM.totalPrice = adultsTotal + studentsTotal + kidsTotal + seniorTotal;
                    bestillingVM.tripId = selectedTrip.TripID;


                return bestillingVM; ;
            }
            catch (IOException e)
            {
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }
        }

        public async Task<bool> settInn(BestillingVM innBestilling)
        {
            var nyBestilling = new Bestilling()
            {
                Date = DateTime.Now,
                NumberOfAdults = innBestilling.numberOfAdults,
                NumberOfStudents = innBestilling.numberOfStudents,
                NumberOfKids = innBestilling.numberOfKids,
                NumberOfSeniors = innBestilling.numberOfSeniors,
                Departure = innBestilling.departure,
                Arrival = innBestilling.arrival,
                TotalPrice = innBestilling.totalPrice,
                KontoNo = innBestilling.kontoNo,
                PinKode = innBestilling.pinKode,
                MobilNo = innBestilling.mobilNo,
                TripID = innBestilling.tripId,
                HarBetalt = true
            };

            try
            {
                var selectedTrip = await _db.Trips.FirstOrDefaultAsync(s => s.TripID == innBestilling.tripId);
                if (selectedTrip == null) { return false; }
                else
                    nyBestilling.Trip = selectedTrip;
                //save a Trip
                _db.Bestillings.Add(nyBestilling);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (IOException e)
            {
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }
        }

        public async Task<List<TripVM>> SugestedTrips(BestillingVM bestillingVM)
        {
            var departureStation = await _db.Stations.FirstOrDefaultAsync(s => s.StationID == bestillingVM.departure);
            var arrivalStation = _db.Stations.FirstOrDefault(s => s.StationID == bestillingVM.arrival);
            {
                try
                {
                    var query = from t in _db.Trips
                                orderby t.TripDate
                                where
                                     t.Departure == departureStation.StationName
                                  && t.Arrival == arrivalStation.StationName
                                  && t.TripDate >= bestillingVM.selectedDate

                                select new TripVM()
                                {
                                    id = t.TripID,
                                    tripDate = t.TripDate,
                                    StringTripDate = t.TripDate.ToString(),
                                    tripTime = t.TripTime,
                                    StringTripTime = t.TripTime.ToString(),
                                    departure = t.Departure,
                                    arrival = t.Arrival,
                                    adultPrice = t.AdultPrice,
                                    studentPrice = t.StudentPrice,
                                    childPrice = t.ChildPrice,
                                    seniorPrice = t.SeniorPrice

                                };

                    return query.ToList();
                }
                catch (IOException e)
                {
                    if (e.Source != null)
                        Console.WriteLine("IOException source: {0}", e.Source);
                    throw;

                }
                finally
                {
                    _db.Dispose();
                }
                //return null;
            }
        }
    }
}
