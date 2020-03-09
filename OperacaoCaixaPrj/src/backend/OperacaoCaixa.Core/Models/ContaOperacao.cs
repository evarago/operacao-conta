using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OperacaoCaixa.Core.Models
{
    public class ContaOperacao : Common
    {
        [Key]
        public string Id { get; set; }
        public string IdCliente { get; set; }
        public string IdConta { get; set; }
        public string TipoOperacao { get; set; }
        public double Valor { get; set; }
        public DateTime DataOperacao { get; set; }
        [ForeignKey("IdCliente")]
        public virtual Pessoa Cliente { get; set; }
        [ForeignKey("IdConta")]
        public virtual ContaCliente Conta { get; set; }

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