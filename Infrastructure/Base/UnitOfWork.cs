using Domain.Contract;
using Domain.Repositories;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDbContext _dbContext;

        public UnitOfWork(IDbContext context)
        {
            _dbContext = context;
        }

        #region Repositories

        private IEmployeeRepository _employeeRepository;
        public IEmployeeRepository EmployeeRepository => _employeeRepository ??= new EmployeeRepository(_dbContext);
        #endregion

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing || _dbContext == null) return;
            ((DbContext) _dbContext).Dispose();
            _dbContext = null;
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
    }
}