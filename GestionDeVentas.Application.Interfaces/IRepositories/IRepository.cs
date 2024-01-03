namespace GestionDeVentas.Application.Interfaces.IRepositories
{
    public interface IRepository<T> where T : class
    {
        public Task<List<T>> GetAll();
        public Task<T> GetById(int id);
        public Task<bool> Insert(T Entity);
        public Task<bool> Update(T Entity);
        public Task<bool> Delete(int id);
    }
}
