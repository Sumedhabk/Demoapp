using Demoapp.DatabaseContext;
using Demoapp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demoapp.Controllers
{

    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly MyDatabaseContext _dbContext;

        public BuildingController(MyDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetBuildingList")]

        public async Task<IActionResult> GetBuildingList()
        {
            return Ok(_dbContext.Buildings.ToList());
        }

        [HttpPost]
        [Route("AddBuilding")]
        public async Task<IActionResult> AddBuilding(BuildingModel obj)
        {
            Building building = new Building();
            building.Id = Guid.NewGuid();
            building.BuildingCode = obj.BuildingCode;
            building.Description = obj.Description;
            building.CurrentStatus = obj.CurrentStatus;
            building.CreatedBy = obj.CreatedBy;
            building.CreatedDate = DateTime.Now;
            building.LastModifiedBy = obj.LastModifiedBy;
            building.LastModifiedDate = DateTime.Now;

            _dbContext.Buildings.Add(building);
            _dbContext.SaveChanges();
            return Ok(building);
        }
        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetEmployee(Guid id)
        {
            var building = await _dbContext.Buildings.FirstOrDefaultAsync(x => x.Id == id);
            if (building == null)
            {
                return NotFound();
            }
            return Ok(building);
        }

        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult> UpdateEmployee(Guid id, BuildingModel obj)
        {
            Building building = new Building();
            var buildingid = await _dbContext.Buildings.FindAsync(id);
            if (buildingid == null)
            {
                return NotFound();
            }
            building.Id= id;
            building.BuildingCode = obj.BuildingCode;
            building.Description = obj.Description;
            building.CurrentStatus = obj.CurrentStatus;
            building.CreatedBy = obj.CreatedBy;
            building.CreatedDate = DateTime.Now;
            building.LastModifiedBy = obj.LastModifiedBy;
            building.LastModifiedDate = DateTime.Now;
            await _dbContext.SaveChangesAsync();
            return Ok(building);
        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var buildingid = await _dbContext.Buildings.FindAsync(id);
            if (buildingid == null)
            {
                return NotFound();
            }
            _dbContext.Buildings.Remove(buildingid);
            await _dbContext.SaveChangesAsync();
            return Ok(_dbContext);

        }
    }
}
