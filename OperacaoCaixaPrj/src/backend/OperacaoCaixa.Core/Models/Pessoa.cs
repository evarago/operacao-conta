using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OperacaoCaixa.Core.Models
{
    public class Pessoa
    {
        [Key]
        public string Id { get; set; }
        public string Identidade { get; set; }
        public string Nome { get; set; }

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