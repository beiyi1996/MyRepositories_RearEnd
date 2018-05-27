namespace TicketPrice.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.IO;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());
        }

        public virtual DbSet<TicTable> TicTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
