namespace ListProject.DAL.Interfaces
{ // Первый этап создание методов (по умолчанию)
    public interface IBaseRepository<T>
    {
        Task Create(T entity); // Принимает объект
        IQueryable<T> GetAll(); // Возвращает IQueryable<T> (работает на стороне сервера)
        Task Delete(T entity); // Принимает объект
        Task<T> Update(T entity); // Возвращает Task<T>
    }
}
