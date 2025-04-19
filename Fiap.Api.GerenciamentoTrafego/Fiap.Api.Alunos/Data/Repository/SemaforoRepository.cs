using Fiap.Api.Alunos.Data.Contexts;
using Fiap.Api.Alunos.Data.Repository.Interfaces;
using Fiap.Api.Alunos.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Alunos.Data.Repository
{
    public class SemaforoRepository : ISemaforoRepository
    {
        private readonly DatabaseContext _context;

        public SemaforoRepository(DatabaseContext context)
        {
            _context = context;
        }

        //public IEnumerable<SemaforoModel> GetAll() => _context.Semaforos.Include(c => c.Representante).ToList();
        public IEnumerable<SemaforoModel> GetAll() => _context.Semaforos.ToList();

        //public IEnumerable<SemaforoModel> GetAll(int page, int size)
        //{
        //    return _context.Semaforos.Include(c => c.Representante)
        //                    .Skip( (page - 1) * page  )
        //                    .Take( size )
        //                    .AsNoTracking()
        //                    .ToList();  
        //}
        public IEnumerable<SemaforoModel> GetAll(int page, int size)
        {
            return _context.Semaforos
                            .Skip((page - 1) * page)
                            .Take(size)
                            .AsNoTracking()
                            .ToList();
        }

        //public IEnumerable<SemaforoModel> GetAllReference(long lastReference, int size)
        //{
        //    var semaforos = _context.Semaforos.Include(_ => _.Representante)
        //                        .Where(c => c.SemaforoId > lastReference)
        //                        .OrderBy( c => c.SemaforoId) 
        //                        .Take(size)
        //                        .AsNoTracking()
        //                        .ToList();

        //    return semaforos;
        //}
        public IEnumerable<SemaforoModel> GetAllReference(long lastReference, int size)
        {
            var semaforos = _context.Semaforos
                                .Where(c => c.SemaforoId > lastReference)
                                .OrderBy(c => c.SemaforoId)
                                .Take(size)
                                .AsNoTracking()
                                .ToList();

            return semaforos;
        }

        public SemaforoModel GetById(long id)
        {
            var semaforo = _context.Semaforos.Find(id);
            if (semaforo == null)
                throw new KeyNotFoundException($"Semaforo com ID {id} não encontrado.");
            return semaforo;
        }

        public void Add(SemaforoModel semaforo)
        {
            _context.Semaforos.Add(semaforo);
            _context.SaveChanges();
        }

        public void Update(SemaforoModel semaforo)
        {
            _context.Update(semaforo);
            _context.SaveChanges();
        }

        public void Delete(SemaforoModel semaforo)
        {
            _context.Semaforos.Remove(semaforo);
            _context.SaveChanges();
        }

        public int Count()
        {
            return _context.Semaforos.Count();
        }
    }
}
