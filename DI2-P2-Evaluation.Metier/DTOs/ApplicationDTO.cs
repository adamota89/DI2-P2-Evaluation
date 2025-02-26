using DI2_P2_Evaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI2_P2_Evaluation.Metier.DTOs
{
    public class ApplicationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ApplicationType Type { get; set; }
    }

}
