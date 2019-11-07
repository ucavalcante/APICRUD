using System;
using Microsoft.EntityFrameworkCore;

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
    public class SeguroContext : DbContext
    {
        public DbSet<Seguro> Seguros { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
                    => options.UseSqlServer("Server=localhost;Database=teste;User Id=SA;Password=Teste@123");
    }
}