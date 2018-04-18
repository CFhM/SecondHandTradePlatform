using SecondHandTradePlatfrom.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHandTradePlatfrom.Models
{
    public enum Sex { Male, Female, Others };
    public class Account
    {
        [Key]
        [Required]
        public int userId { get; set; }
        [Required]
        [StringLength(20)]
        public string name { get;set; }
        [Required]
        [School]
        public School school { get; set; }
        public Sex sex { get; set; }
        [Required]
        [Phone]
        public string phoneNumber { get; set; }
        public string wechat { get; set; }
        [Required]
        [StringLength(maximumLength:32, MinimumLength = 32)]
        public string passwordMD5 { get; set; }
    }
}
