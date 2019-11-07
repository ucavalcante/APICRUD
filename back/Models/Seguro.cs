using System;
using System.Collections.Generic;
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

        public static void Create(Seguro seguro)
        {
            throw new NotImplementedException();
        }

        public static Seguro Read(int Id)
        {
            throw new NotImplementedException();
        }

        public static void Update(int Id, Seguro seguro)
        {
            throw new NotImplementedException();
        }

        public static void Delete(int Id)
        {
            throw new NotImplementedException();
        }
        public static List<Seguro> GetList()
        {
            throw new NotImplementedException();
        }
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