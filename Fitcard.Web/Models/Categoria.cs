using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitcard.Web.Models
{
    public class Categoria
    {

        [Key]
        public int CAT_ID { get; set; }

        [MinLength(3)]
        public string CAT_NOME { get; set; }

    }
}