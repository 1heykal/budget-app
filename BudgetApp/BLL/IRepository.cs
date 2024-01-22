namespace BudgetApp.BLL
{
    public interface IRepository<T, T1>
    {
        void Create(T entity);
        T GetById(T1 id);
        IEnumerable<T> GetAll();
        void Update(T entity);
        void Delete(T1 id);
    }
}
