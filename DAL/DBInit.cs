using ITPE3200_1_20H_nor_way.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITPE3200_1_20H_nor_way.DAL
{
    public class DBInit
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<Nor_Way_Context>();

                // må slette og opprette databasen hver gang når den skalinitieres (seed`es)
                context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();
                context.Database.EnsureCreatedAsync();

                var station1 = new Station { StationID = 001, StationName = "Oslo" };
                var station2 = new Station { StationID = 002, StationName = "Stavanger" };

               
                context.Stations.Add(station1);
                context.Stations.Add(station2);

                context.SaveChanges();
            }
        }
    }
}