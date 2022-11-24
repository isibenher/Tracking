using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Model;

namespace API.Data
{
    public class APIContext : DbContext
    {
        public APIContext (DbContextOptions<APIContext> options)
            : base(options)
        {
        }

        public DbSet<API.Model.AdsContact> AdsContact { get; set; } = default!;

        public DbSet<API.Model.Catalog> Catalog { get; set; }

        public DbSet<API.Model.DeliveryAcceptanceNote> DeliveryAcceptanceNote { get; set; }

        public DbSet<API.Model.DeliveryAcceptandeNoteLine> DeliveryAcceptandeNoteLine { get; set; }

        public DbSet<API.Model.KPIType> KPIType { get; set; }

        public DbSet<API.Model.Order> Order { get; set; }

        public DbSet<API.Model.OrderWU_KPI> OrderWU_KPI { get; set; }

        public DbSet<API.Model.OrderWUDistribution> OrderWUDistribution { get; set; }

        public DbSet<API.Model.OrderWUForecast> OrderWUForecast { get; set; }

        public DbSet<API.Model.Project> Project { get; set; }

        public DbSet<API.Model.ProjectSubcontrator> ProjectSubcontrator { get; set; }

        public DbSet<API.Model.Siglum> Siglum { get; set; }
    }
}
