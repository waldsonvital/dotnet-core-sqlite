using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;

namespace superprojeto.Models{
    public class Produto{
        [KeyAttribute]
        public int id { get; set; }
        [RequiredAttribute]
        public string nome { get; set; }
        [DataTypeAttribute(DataType.Currency)]
        public double valor { get; set; }
    }
}