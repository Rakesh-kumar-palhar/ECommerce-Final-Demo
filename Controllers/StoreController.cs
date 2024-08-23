using ECommerce_Final_Demo.Model;
using ECommerce_Final_Demo.Model.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_Final_Demo.Controllers
{
    [Route("api/stores/")]
    [ApiController]
    //[Authorize(Roles = "SuperAdmin,StoreAdmin")]
    public class StoreController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StoreController(ApplicationDbContext context)
        {
            _context = context;
        }

        private StoreDto MapToDto(Store store)
        {
            return new StoreDto
            {
                Id = store.Id,
                Name = store.Name,
                Country = (CountryDto)store.Country,
                State = (StateDto)store.State,
                City = (CityDto)store.City,
                Image = store.Image
                
            };
        }

        private Store MapToModel(StoreDto storeDto)
        {
            return new Store
            {
                Id = storeDto.Id,
                Name = storeDto.Name,
                Country = (Country)storeDto.Country,
                State = (State)storeDto.State,
                City = (City)storeDto.City,
                Image = storeDto.Image
                
            };
        }


        //if you wants to see the list of the store
        [HttpGet("allstores")]
        [Authorize(Roles = "SuperAdmin")] 
        public async Task<IActionResult> GetStores()
        {
            var stores = await _context.Stores.ToListAsync();
            var storeDtos = stores.Select(store => MapToDto(store)).ToList();
            return Ok(storeDtos);
        }
        //if you wants to add tre store
        [HttpPost("addstore")]
        [Authorize(Roles = "SuperAdmin")] 
        public async Task<IActionResult> AddStore([FromBody] StoreDto storeDto)
        {
            if (storeDto == null)
            {
                return BadRequest("Store data is required.");
            }
            var store = MapToModel(storeDto);
            store.Id = Guid.NewGuid();
            _context.Stores.Add(store);
            await _context.SaveChangesAsync();

            return Ok("Store created successful");
        }
        //if you wants to see the store by id
        [HttpGet("{storeId:guid}")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> GetStoreById(Guid storeId)
        {
            var store = await _context.Stores.FindAsync(storeId);
            if (store == null)
            {
                return NotFound("Store not found.");
            }

            var storeDto = MapToDto(store);
            return Ok(storeDto);
        }

    }
}
