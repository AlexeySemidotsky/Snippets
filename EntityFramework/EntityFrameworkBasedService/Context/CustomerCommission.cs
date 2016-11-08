using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkBasedService.Context
{
    [Table("Commissions", Schema = DbSchemas.Payments)]
    public class CustomerCommission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? PaymentServiceId { get; set; }
        public int? PointId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int Level { get; private set; }

        [Required]
        public int CurrencyId { get; set; }

        [Column(TypeName = "Money")]
        public decimal? MinCommission { get; set; }

        [StringLength(4096), Column(TypeName = "varchar")]
        public string Formula { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}