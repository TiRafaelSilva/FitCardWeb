using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitcard.Web.Models
{
    public class Estabelecimento
    {
        [Key]
        public int EST_ID { get; set; }

        [Required(ErrorMessage = "Estabelecimento é obrigatorio.")]
        public string EST_NOME { get; set; }
        [Required(ErrorMessage = "CNPJ é obrigatorio.")]
        public int EST_CNPJ { get; set; }

        public string EST_NOME_FANTASIA { get; set; }

        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string EST_EMAIL { get; set; }

        public int? EST_TELEFONE { get; set; }
        public int CAT_ID { get; set; }
        public byte EST_STATUS { get; set; }

        public virtual Categoria Categoria { get; set; }

        public bool validaTipo(Estabelecimento est)
        {
            bool valid = true;

            if(est.Categoria.CAT_NOME == "Supermercado" && !est.EST_TELEFONE.HasValue)
            {
                valid = false;
            }

            return valid;
        }
    }
}