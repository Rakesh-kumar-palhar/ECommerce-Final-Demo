using ECommerce_Final_Demo.Model;
using ECommerce_Final_Demo.Model.DTO;
using Microsoft.AspNetCore.Authorization;
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

        //private StoreDto MapToDto(Store store)
        //{
        //    return new StoreDto
        //    {
        //        Id = store.Id,
        //        Name = store.Name,
        //        Country = (CountryDto)store.Country,
        //        State = (StateDto)store.State,
        //        City = (CityDto)store.City,
        //        Image = store.Image

        //    };
        //}

        /* private Store MapToModel(StoreDto storeDto)
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
         }*/


        //if you wants to see the list of the store
        [HttpGet("allstores")]
        //[Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> GetStores()
        {
            var stores = await _context.Stores.ToListAsync();

            var storeDtos = StoreDto.Mapping(stores);
            return Ok(storeDtos);
        }
        //if you wants to add the store
        [HttpPost("addstore")]
        //[Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> AddStore([FromBody] StoreDto storeDto)
        {
            if (storeDto == null)
            {
                return BadRequest("Store data is required.");
            }
            var store = StoreDto.Mapping(storeDto);
            storeDto.Id = Guid.NewGuid();
            _context.Stores.Add(StoreDto.Mapping(storeDto));
            await _context.SaveChangesAsync();

            return Ok("Store created successful");
        }
        //if you wants to see the store by id

        [HttpGet("storedetails{storeId:guid}")]
        //[Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> GetStoreById(Guid storeId)
        {
            var store = await _context.Stores.FindAsync(storeId);
            if (store == null)
            {
                return NotFound("Store not found.");
            }

            var storeDto = StoreDto.Mapping(store);
            return Ok(storeDto);
        }

        //if you wants to update the store
        [HttpPut("updatestore{storeId:guid}")]
        //[Authorize(Roles = "SuperAdmin,StoreAdmin")]
        public async Task<IActionResult> UpdateStore(Guid storeId, [FromBody] StoreDto storeDto)
        {
            var existingStore = await _context.Stores.FindAsync(storeId);

            if (existingStore == null)
            {
                return NotFound(new { Message = "Store not found." });
            }
            existingStore.Name = storeDto.Name;
            existingStore.Country = (Country)storeDto.Country;
            existingStore.State = (State)storeDto.State;
            existingStore.City = (City)storeDto.City;
            existingStore.Image = storeDto.Image;

            _context.Stores.Update(existingStore);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Store updated successfully." });
        }

        //if you wants to delete the store
        [HttpDelete("{storeId:guid}")]
        //[Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> DeleteStore(Guid storeId)
        {
            var store = await _context.Stores.FindAsync(storeId);

            if (store == null)
            {
                return NotFound(new { Message = "Store not found." });
            }

            _context.Stores.Remove(store);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Store deleted successfully." });
        }

    }
}
