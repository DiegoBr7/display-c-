using Fiap.Api.Alunos.Data.Contexts;
using Fiap.Api.Alunos.Data.Repository.Interfaces;
using Fiap.Api.Alunos.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Alunos.Data.Repository
{
    public class CondicaoClimaticaRepository : ICondicaoClimaticaRepository
    {
        private readonly DatabaseContext _context;

        public CondicaoClimaticaRepository(DatabaseContext context)
        {
            _context = context;
        }

        //public IEnumerable<CondicaoClimaticaModel> GetAll() => _context.CondicoesClimaticas.Include(c => c.Representante).ToList();
        public IEnumerable<CondicaoClimaticaModel> GetAll() => _context.CondicoesClimaticas.ToList();

        //public IEnumerable<CondicaoClimaticaModel> GetAll(int page, int size)
        //{
        //    return _context.CondicoesClimaticas.Include(c => c.Representante)
        //                    .Skip( (page - 1) * page  )
        //                    .Take( size )
        //                    .AsNoTracking()
        //                    .ToList();  
        //}
        public IEnumerable<CondicaoClimaticaModel> GetAll(int page, int size)
        {
            return _context.CondicoesClimaticas
                            .Skip((page - 1) * page)
                            .Take(size)
                            .AsNoTracking()
                            .ToList();
        }

        //public IEnumerable<CondicaoClimaticaModel> GetAllReference(long lastReference, int size)
        //{
        //    var condicoesClimaticas = _context.CondicoesClimaticas.Include(_ => _.Representante)
        //                        .Where(c => c.CondicaoClimaticaId > lastReference)
        //                        .OrderBy( c => c.CondicaoClimaticaId) 
        //                        .Take(size)
        //                        .AsNoTracking()
        //                        .ToList();

        //    return condicoesClimaticas;
        //}
        public IEnumerable<CondicaoClimaticaModel> GetAllReference(long lastReference, int size)
        {
            var condicoesClimaticas = _context.CondicoesClimaticas
                                .Where(c => c.CondicaoClimaticaId > lastReference)
                                .OrderBy(c => c.CondicaoClimaticaId)
                                .Take(size)
                                .AsNoTracking()
                                .ToList();

            return condicoesClimaticas;
        }

        public CondicaoClimaticaModel GetById(long id)
        {
            var condicoesClimaticas = _context.CondicoesClimaticas.Find(id);
            if (condicoesClimaticas == null)
                throw new KeyNotFoundException($"CondicaoClimatica com ID {id} não encontrado.");
            return condicoesClimaticas;
        }

        public void Add(CondicaoClimaticaModel condicoesClimaticas)
        {
            _context.CondicoesClimaticas.Add(condicoesClimaticas);
            _context.SaveChanges();
        }

        public void Update(CondicaoClimaticaModel condicoesClimaticas)
        {
            _context.Update(condicoesClimaticas);
            _context.SaveChanges();
        }

        public void Delete(CondicaoClimaticaModel condicoesClimaticas)
        {
            _context.CondicoesClimaticas.Remove(condicoesClimaticas);
            _context.SaveChanges();
        }

    }
}