using System;
using Domain.Repositories;

namespace Domain.Contract
{
    public interface IUnitOfWork : IDisposable
    {
        #region [Repositories]
        public IEmployeeRepository EmployeeRepository { get;}
        #endregion

        int Commit();
    }
}