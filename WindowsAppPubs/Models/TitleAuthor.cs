namespace WindowsAppPubs.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TitleAuthor")]
    public partial class TitleAuthor
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(11)]
        public string AuId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        public string TitleId { get; set; }

        public byte? AuOrd { get; set; }

        public int? Royaltyper { get; set; }

        public virtual Author Author { get; set; }

        public virtual Title Title { get; set; }
    }
}
