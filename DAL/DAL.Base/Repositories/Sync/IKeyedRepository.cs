namespace DAL.Base.Repositories
{
    public interface IKeyedRepository<TEntity, TKey>
        where TEntity : class, IEntity
        where TKey : struct
    {
        TEntity GetById(TKey id);
        bool Delete(TKey id);
    }
}
