namespace Domain.Repositories;public interface IUserRepository<T>{    void Delete();    void Add(T newEntity);    T Read();}