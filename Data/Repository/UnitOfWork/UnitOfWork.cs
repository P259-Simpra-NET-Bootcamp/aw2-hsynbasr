using Data.Entity;
using Data.Repository.GenericRepository;


namespace Data.Repository.UnitOfWork
{
    public class UnitOfWork : AppDbContext
    {
        public IGenericRepository<Staff> StaffRepository { get; private set; }
        private readonly Context.AppDbContext dbContext;
        public UnitOfWork(Context.AppDbContext dbContext)
        {
            this.dbContext = dbContext;

            StaffRepository = new GenericRepository<Staff>(dbContext);
        }

        public void Complete()
        {
           dbContext.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
