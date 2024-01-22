namespace BudgetApp.BLL
{
    public interface IRepository<T>
    {
        void Create(T entity);
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        void Update(T entity);
        void Delete(Guid id);
    }
}
