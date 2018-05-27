namespace TicketPrice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TicTable")]
    public partial class TicTable
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Startstation { get; set; }

        [Required]
        [StringLength(50)]
        public string Endstation { get; set; }

        public int Price { get; set; }
    }
}
