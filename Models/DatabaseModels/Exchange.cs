using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels
{
    public class Exchange
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Amount { get; set; }
        public string CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
