using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OperacaoCaixa.Core.Models
{
    public class ContaSaldo
    {
        [Key]
        public string IdConta { get; set; }
        public string IdCliente { get; set; }
        public double SaldoAtual { get; set; }
        public double SaldoAnterior { get; set; }
        public DateTime DataAtualizacao { get; set; }

        [ForeignKey("IdCliente")]
        public virtual Pessoa Cliente { get; set; }
        [ForeignKey("IdConta")]
        public virtual ContaCliente Conta { get; set; }
    }
}