using System.ComponentModel.DataAnnotations;

namespace superprojeto.Models{
    public class Produto{
        [KeyAttribute]
        public int id { get; set; }
        public string nome { get; set; }
        public double valor { get; set; }
    }
}