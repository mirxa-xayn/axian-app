using Axian.Core.Uow;
using Axian.Models.DatabaseModels.Main;
using Axian.Models.Employee;
using Axian.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Axian.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IConfiguration _config;

        public EmployeeService(IUnitOfWork unitOfWork, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _config = config;
        }

        public bool AddNewEmployee(EmployeeModel model)
        {
            try
            {
                AxianEmployee emp = new AxianEmployee()
                {
                    Name = model.Name,
                    Age = model.Age,
                    Address = model.Address,
                    DOB = model.DOB
                };
                return _unitOfWork.AddNewEmployee(emp);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool DeleteEmployee(EmployeeModel model)
        {
            try
            {
                AxianEmployee emp = new AxianEmployee()
                {
                    EmpId =model.EmpId
                };
                return _unitOfWork.DeleteEmployee(emp);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<AxianEmployee> GetAllEmployees()
        {
            try
            {
                return _unitOfWork.GetAllEmployees();
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
                return _unitOfWork.GetTotalEmployees();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool UpdateEmployee(EmployeeModel model)
        {
            AxianEmployee emp = new AxianEmployee()
            {
                EmpId = model.EmpId,
                Name = model.Name,
                Age = model.Age,
                Address = model.Address,
                DOB = model.DOB
            };
            return _unitOfWork.UpdateEmployee(emp);
        }
    }
}
