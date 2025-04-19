using Fiap.Api.Alunos.Data.Contexts;
using Fiap.Api.Alunos.Data.Repository.Interfaces;
using Fiap.Api.Alunos.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Alunos.Data.Repository
{
    public class RotaRepository : IRotaRepository
    {
        private readonly DatabaseContext _context;

        public RotaRepository(DatabaseContext context)
        {
            _context = context;
        }

        //public IEnumerable<RotaModel> GetAll() => _context.Rotas.Include(c => c.Representante).ToList();
        public IEnumerable<RotaModel> GetAll() => _context.Rotas.ToList();

        //public IEnumerable<RotaModel> GetAll(int page, int size)
        //{
        //    return _context.Rotas.Include(c => c.Representante)
        //                    .Skip( (page - 1) * page  )
        //                    .Take( size )
        //                    .AsNoTracking()
        //                    .ToList();  
        //}
        public IEnumerable<RotaModel> GetAll(int page, int size)
        {
            return _context.Rotas
                            .Skip((page - 1) * page)
                            .Take(size)
                            .AsNoTracking()
                            .ToList();
        }

        //public IEnumerable<RotaModel> GetAllReference(long lastReference, int size)
        //{
        //    var rotas = _context.Rotas.Include(_ => _.Representante)
        //                        .Where(c => c.RotaId > lastReference)
        //                        .OrderBy( c => c.RotaId) 
        //                        .Take(size)
        //                        .AsNoTracking()
        //                        .ToList();

        //    return rotas;
        //}
        public IEnumerable<RotaModel> GetAllReference(long lastReference, int size)
        {
            var rotas = _context.Rotas
                                .Where(c => c.RotaId > lastReference)
                                .OrderBy(c => c.RotaId)
                                .Take(size)
                                .AsNoTracking()
                                .ToList();

            return rotas;
        }

        public RotaModel GetById(long id)
        {
            var rota = _context.Rotas.Find(id);
            if (rota == null)
                throw new KeyNotFoundException($"Rota com ID {id} não encontrado.");
            return rota;
        }

        public void Add(RotaModel rota)
        {
            _context.Rotas.Add(rota);
            _context.SaveChanges();
        }

        public void Update(RotaModel rota)
        {
            _context.Update(rota);
            _context.SaveChanges();
        }

        public void Delete(RotaModel rota)
        {
            _context.Rotas.Remove(rota);
            _context.SaveChanges();
        }

        public int Count()
        {
            return _context.Rotas.Count();
        }
    }
}
