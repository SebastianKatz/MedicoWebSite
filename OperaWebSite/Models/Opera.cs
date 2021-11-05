using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OperaWebSite.Validations;
using System.Linq;
using System.Web;

namespace OperaWebSite.Models
{
    [Table("Opera")]
    public class Opera
    {
        public int OperaId { get; set; }

        [Required(ErrorMessage = "Is required")]
        [StringLength(150)]
        public string Tittle { get; set; }

        [Required(ErrorMessage = "Is required")]
        public string Composer { get; set; }

        [CheckValidYear]
        public int Year { get; set; }
    }
}