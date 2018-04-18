using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHandTradePlatfrom.Models
{
    public class School
    {
        [Key]
        [Required]
        public string name { get; set; }
        public ICollection<Account> accounts { get; set; }
    }
}
