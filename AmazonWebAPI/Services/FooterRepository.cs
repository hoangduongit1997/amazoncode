using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Amazon.BUS;
using Amazon.DTO;
namespace AmazonWebAPI.Services
{
    public class FooterRepository
    {
        FooterBUS bus = null;

        public FooterBUS Bus { get => bus; set => bus = value; }
        public FooterRepository()
        {
            Bus = new FooterBUS();
        }
        public List<FooterDTO> ListFooter()
        {
            return Bus.ListFooter();
        }
    }
}