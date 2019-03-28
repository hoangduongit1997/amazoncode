using Amazon.BUS;
using Amazon.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmazonWebAPI.Services
{
    public class FooterRepository
    {
        FooterBUS bus = new FooterBUS();
        //danh sách footer
        public List<FooterDTO> GetAll()
        {
            return bus.GetAll();
        }
        //lấy footer
        public FooterDTO Detail(int id)
        {
            return bus.ViewDetail(id);
        }
        //thêm footer
        public bool Insert(FooterDTO item)
        {
            return bus.Insert(item);
        }
        //sửa footer
        public bool Update(FooterDTO footer)
        {
            return bus.Update(footer);
        }
        //xóa footer
        public bool Delete(FooterDTO footer)
        {
            return bus.Delete(footer);
        }
        //mã tự động
        public int autoKey()
        {
            return bus.autoKey();
        }
    }
}