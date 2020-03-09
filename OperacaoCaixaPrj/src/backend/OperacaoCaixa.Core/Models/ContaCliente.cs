using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OperacaoCaixa.Core.Models
{
    public class ContaCliente : Common
    {
        [Key]
        public string Id { get; set; }
        public Int64 NumeroConta { get; set; }
        public string IdCliente { get; set; }
        public string CodigoAgencia { get; set; }
        public string TipoConta { get; set; }

        [ForeignKey("IdCliente")]
        public virtual Pessoa Cliente { get; set; }

        /// <summary>
        /// Cria um novo ID para o objeto.
        /// </summary>
        /// <returns></returns>
        public static string GetNewId()
        {
            return Guid.NewGuid().ToString().Replace("-", "").ToLower(); ;
        }
    }
}