using System.Linq.Expressions;


namespace Neoris.User.DBModel.Interface
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);

        Task Add(IEnumerable<T> entities);

        void Delete(T entity);

        void Delete(IEnumerable<T> entities);

        IQueryable<T> GetAll();

        IQueryable<T> GetByFilter(Expression<Func<T, bool>> filter);

        Task<T> GetById(int id);

        void Update(T entity);

        bool Update(T editedEntity, T originalEntty);

        Task SaveChanges();

    }
}
