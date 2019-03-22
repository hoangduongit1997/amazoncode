using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.DAL;
using Amazon.EntityFramework;
using Amazon.DTO;
using AutoMapper;

namespace Amazon.BUS
{
    public class CustomerBUS
    {
        CustomerDAL dal;
        public CustomerBUS()
        {
            Dal = new CustomerDAL();
        }

        public CustomerDAL Dal { get => dal; set => dal = value; }
        public int Login(string username, string password)
        {
            return Dal.Login(username, password);
        }

        public int insert(CustomerDTO cus)
        {
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<CustomerDTO, Customer>();

            });
            IMapper iMapper = config.CreateMapper();
            var cusModel = iMapper.Map<CustomerDTO, Customer>(cus);
            return Dal.insert(cusModel);
        }
        public bool checkEmail(string email)
        {
            return Dal.checkEmail(email);
        }
        public string IdRandom()
        {
            Random r = new Random();
            int id = r.Next(100, 999);
            return DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + id.ToString();
        }

        public bool Update(Customer cus)
        {
            return Dal.Update(cus);
        }

        public bool Delete(string id)
        {
            return Dal.Delete(id);
        }

        public Customer ViewDetail(string id)
        {
            return Dal.ViewDetail(id);
        }

        public IEnumerable<Customer> ListAll(int page, int pageSize)
        {
            return Dal.ListAllPaging(page, pageSize);
        }
        public Customer Find(string id)
        {
            return Dal.Find(id);
        }
    }
}