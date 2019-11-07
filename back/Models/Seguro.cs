using System;
using System.Collections.Generic;
using System.Linq;
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
            using (var db = new SeguroDbContext())
            {
                db.Add(seguro);
                db.SaveChanges();
            }
        }

        public static Seguro Read(int Id)
        {
            using (var db = new SeguroDbContext())
            {
                var retorno = db.Seguros
                                .Where(i => i.Id == Id)
                                .FirstOrDefault();

                return retorno;
            }
        }

        public static void Update(int Id, Seguro seguro)
        {
            using (var db = new SeguroDbContext())
            {
                var retorno = db.Seguros
                                .Where(i => i.Id == Id)
                                .FirstOrDefault();

                if (retorno != null)
                {
                    retorno.Nome = seguro.Nome;
                    retorno.Abrangencia = seguro.Abrangencia;
                    retorno.DtContratacao = seguro.DtContratacao;
                    retorno.VigenciaLimite = seguro.VigenciaLimite;

                    db.SaveChanges();
                }
            }
        }

        public static void Delete(int Id)
        {
            using (var db = new SeguroDbContext())
            {
                var retorno = db.Seguros
                                .Where(i => i.Id == Id)
                                .FirstOrDefault();
                if (retorno != null)
                {
                    db.Seguros.Remove(retorno);
                    db.SaveChanges();
                }

            }
        }
        public static List<Seguro> GetList()
        {
            using (var db = new SeguroDbContext())
            {
                return db.Seguros.ToList();
            }
        }
    }

    public enum AbrangenciaEnum
    {
        Nacional,
        Internacional,
        Estadual
    }
    public class SeguroDbContext : DbContext
    {
        public DbSet<Seguro> Seguros { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
                    => options.UseSqlServer("Server=localhost;Database=teste;User Id=SA;Password=Teste@123");
    }
}