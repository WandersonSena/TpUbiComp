using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TpUbiComp.Models
{
    public class ApplicationLocale
    {
        [Key]
        public int Id { get; set; }
        public Application Application { get; set; }
        public Locale Locale { get; set; }
        public string Url { get; set; }
    }
}
