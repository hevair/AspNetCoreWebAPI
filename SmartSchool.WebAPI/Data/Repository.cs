using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SmartShool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly SmartContext _context;
        public readonly IRepository _repo;

        public Repository(SmartContext context)
        {
            _context = context;

        }

        public void Add<T>(T TEntity)
        {
           _context.Add(TEntity);
        }

        public void Update<T>(int id, T TEntity)
        {
            _context.Update(TEntity);
        }

        public void Delete<T>(int id, T TEntity)
        {
            _context.Remove(TEntity);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;

        }
    }
}