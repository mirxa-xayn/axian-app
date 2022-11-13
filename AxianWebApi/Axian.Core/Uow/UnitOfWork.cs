using Axian.Core.Context;
using Axian.Models.DatabaseModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Axian.Core.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AxianDatabaseContext _dbContext;

        public UnitOfWork(AxianDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddNewEmployee(AxianEmployee model)
        {
            try
            {
                _dbContext.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public AxianUser AddNewUser(AxianUser model)
        {
            try
            {
                _dbContext.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                _dbContext.SaveChanges();

                return model;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public bool DeleteEmployee(AxianEmployee model)
        {
            try
            {
                _dbContext.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public  List<AxianEmployee> GetAllEmployees()
        {
            try
            {
                return  _dbContext.AxianEmployees.ToList() ;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<AxianUser> GetAllUsers()
        {
            try
            {
                return _dbContext.AxianUsers.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetTotalEmployees()
        {
            try
            {
                return _dbContext.AxianEmployees.ToList().Count;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int GetTotalUsers()
        {
            try
            {
                return _dbContext.AxianUsers.ToList().Count;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool UpdateEmployee(AxianEmployee model)
        {
            try
            {
                _dbContext.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public AxianUser VerifyUser(string email, string password)
        {
            try
            {
                return _dbContext.AxianUsers.Where(u=> u.Email == email  && u.Password == password).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
