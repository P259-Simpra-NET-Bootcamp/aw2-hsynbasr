using Data.Entity;
using Data.Repository.GenericRepository;


namespace Data.Repository.UnitOfWork
{
    public interface AppDbContext : IDisposable
    {
        IGenericRepository<Staff> StaffRepository { get; }
       

        void Complete();
    }
}
