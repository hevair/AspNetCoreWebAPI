using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
        public void Add<T>(T TEntity);
        public void Update<T>(int id, T TEntity);
        public void Delete<T>(int id, T TEntity);
        public bool SaveChanges();
    }
}