using System;

namespace back.Models
{
    public class Seguro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime VigenciaLimite { get; set; }
        public DateTime DtContratacao { get; set; }
        public AbrangenciaEnum Abrangencia { get; set; }
    }

    public enum AbrangenciaEnum
    {
        Nacional,
        Internacional,
        Estadual
    }
}