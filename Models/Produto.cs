using System.ComponentModel.DataAnnotations;

namespace superprojeto.Models{
    public class Produto{
        [KeyAttribute]
        public int id { get; set; }
        [RequiredAttribute]
        [StringLengthAttribute(50,ErrorMessage="maximo 50")]
        public string nome { get; set; }
        [DataTypeAttribute(DataType.Currency)]
        public double valor { get; set; }
    }
}