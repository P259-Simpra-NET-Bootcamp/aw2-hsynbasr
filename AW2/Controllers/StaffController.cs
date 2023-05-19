using Data.Entity;
using Data.Repository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace AW2.Controllers
{
    [Route("AW2/v1/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly AppDbContext unitOfWork;
        public StaffController(AppDbContext unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public List<Staff> GetAll()
        {
            var list = unitOfWork.StaffRepository.GetAll();
            return list;
        }
        [HttpGet("Query/City")]
        public List<Staff> GetCity([FromQuery] string city)
        {
            return unitOfWork.StaffRepository.GetCity(i => i.City == city);
        }

        [HttpGet("{id}")]
        public Staff GetById(int id)
        {
            var row = unitOfWork.StaffRepository.GetById(id);
            return row;
        }

        [HttpPost]
        public void Post([FromBody] Staff staff)
        {
            unitOfWork.StaffRepository.Insert(staff);
            unitOfWork.Complete();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Staff staff)
        {
            unitOfWork.StaffRepository.Update(staff);
            unitOfWork.Complete();
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            unitOfWork.StaffRepository.DeleteById(id);
            unitOfWork.Complete();
        }
    }
}
