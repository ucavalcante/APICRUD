using System;
using System.Collections.Generic;
using System.Linq;
using back.Models;

namespace back.Data
{
    public class SeguroManager: IDataRepository<Seguro>
    {
        private readonly SeguroDbContext _dbContext;
        public SeguroManager(SeguroDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Seguro seguro)
        {
            if (seguro.Nome == null)
                throw new ArgumentNullException("Nome", "Necessario que o Nome do seguro seja informado");

            seguro.DtContratacao = DateTime.Now;
            seguro.VigenciaLimite = DateTime.Now.AddMonths(12);

            _dbContext.Add(seguro);
            _dbContext.SaveChanges();
        }

        public Seguro Read(int Id)
        {
            var retorno = _dbContext.Seguros
                            .Where(i => i.Id == Id)
                            .FirstOrDefault();

            if (retorno == null)
                throw new KeyNotFoundException($"O objeto de id:{Id}, não foi encontrado na coleção");

            return retorno;
        }

        public void Update(int Id, Seguro seguro)
        {
            var retorno = _dbContext.Seguros
                            .Where(i => i.Id == Id)
                            .FirstOrDefault();

            if (retorno == null)
                throw new KeyNotFoundException($"O objeto de id:{Id}, não foi encontrado na coleção");

            retorno.Nome = seguro.Nome;
            retorno.Abrangencia = seguro.Abrangencia;
            retorno.DtContratacao = seguro.DtContratacao;
            retorno.VigenciaLimite = seguro.VigenciaLimite;

            _dbContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            var retorno = _dbContext.Seguros
                            .Where(i => i.Id == Id)
                            .FirstOrDefault();

            if (retorno == null)
                throw new KeyNotFoundException($"O objeto de id:{Id}, não foi encontrado na coleção");

            _dbContext.Seguros.Remove(retorno);
            _dbContext.SaveChanges();
        }
        public List<Seguro> GetList()
        {
            return _dbContext.Seguros.ToList();
        }
    }
}