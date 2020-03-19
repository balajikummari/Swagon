namespace Swagon.DataBase.UnitOfWork
{
    /*
    public interface IUnitOfWork<R> : IDisposable where R : IRepository<T> where T : IEntity
    {
        List<IRepository<R>> repositories;
       int Complete();
    }

    public class UnitOfWork : IUnitOfWork
    {
        public readonly IContext _context;

        protected Te GetObject<Te>()
        {
            Te obj = default(Te);
            obj = Activator.CreateInstance<Te>();
            return obj;
        }


        public UnitOfWork(T context)
        {
            _context = context;

        }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }*/
}
