using System.ComponentModel.DataAnnotations;
using static SRMS_APIs.Models.Biit_Administration;

namespace SRMS_APIs.Models
{
    public class FinanceCommittee
    {
        [Key]
        public int Finance_Committee_Id { get; set; }

        [Required]
        public int Administration_Id { get; set; }

        public BiitAdministration? BiitAdministration { get; set; }
    }
}
