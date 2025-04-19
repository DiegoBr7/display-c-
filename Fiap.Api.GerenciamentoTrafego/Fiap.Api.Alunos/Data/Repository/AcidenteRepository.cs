using Fiap.Api.Alunos.Data.Contexts;
using Fiap.Api.Alunos.Data.Repository.Interfaces;
using Fiap.Api.Alunos.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Alunos.Data.Repository
{
    public class AcidenteRepository : IAcidenteRepository
    {
        private readonly DatabaseContext _context;

        public AcidenteRepository(DatabaseContext context)
        {
            _context = context;
        }

    //public IEnumerable<AcidenteModel> GetAll() => _context.Acidentes.Include(c => c.Representante).ToList();
    public IEnumerable<AcidenteModel> GetAll() => _context.Acidentes.ToList();

    //public IEnumerable<AcidenteModel> GetAll(int page, int size)
    //{
    //    return _context.Acidentes.Include(c => c.Representante)
    //                    .Skip( (page - 1) * page  )
    //                    .Take( size )
    //                    .AsNoTracking()
    //                    .ToList();  
    //}
    public IEnumerable<AcidenteModel> GetAll(int page, int size)
        {
        return _context.Acidentes
                        .Skip((page - 1) * page)
                        .Take(size)
                        .AsNoTracking()
                        .ToList();
        }

    //public IEnumerable<AcidenteModel> GetAllReference(long lastReference, int size)
    //{
    //    var acidentes = _context.Acidentes.Include(_ => _.Representante)
    //                        .Where(c => c.AcidenteId > lastReference)
    //                        .OrderBy( c => c.AcidenteId) 
    //                        .Take(size)
    //                        .AsNoTracking()
    //                        .ToList();

    //    return acidentes;
    //}
    public IEnumerable<AcidenteModel> GetAllReference(long lastReference, int size)
        {
        var acidentes = _context.Acidentes
                            .Where(c => c.AcidenteId > lastReference)
                            .OrderBy(c => c.AcidenteId)
                            .Take(size)
                            .AsNoTracking()
                            .ToList();

        return acidentes;
        }

    public AcidenteModel GetById(long id)
    {
        var acidente = _context.Acidentes.Find(id);
        if (acidente == null)
            throw new KeyNotFoundException($"Acidente com ID {id} não encontrado.");
        return acidente;
    }

        public void Add(AcidenteModel acidente)
        {
            _context.Acidentes.Add(acidente);
            _context.SaveChanges();
        }

    public void Update(AcidenteModel acidente)
    {
        _context.Update(acidente);
        _context.SaveChanges();
    }

        public void Delete(AcidenteModel acidente)
        {
            _context.Acidentes.Remove(acidente);
            _context.SaveChanges();
        }
    }
}
