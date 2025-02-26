using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI2_P2_Evaluation.Domain.Entities
{
    public class Password
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string EncryptedValue { get; set; } = string.Empty; // Chiffré en AES ou RSA

        public ICollection<ApplicationPassword> ApplicationPasswords { get; set; } = new List<ApplicationPassword>();

    }
}
