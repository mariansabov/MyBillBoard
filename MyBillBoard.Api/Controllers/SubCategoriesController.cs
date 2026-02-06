using Microsoft.AspNetCore.Mvc;
using MyBillBoard.Application.Common.Interfaces;
using MyBillBoard.Application.Features.SubCategories.Dtos;
using MyBillBoard.Domain.Entities;

namespace MyBillBoard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubCategoriesController : ControllerBase
    {
        private readonly ISubCategoriesRepository _subCategoriesRepository;

        public SubCategoriesController(ISubCategoriesRepository subCategoriesRepository)
        {
            _subCategoriesRepository = subCategoriesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<SubCategoryDto>>> GetAll()
        {
            var subCategories = await _subCategoriesRepository.GetAllSubCategoriesAsync();
            return Ok(subCategories);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateSubCategoryRequest subCategory)
        {
            var subCategoryId = await _subCategoriesRepository.CreateSubCategoryAsync(subCategory);
            return Ok(subCategoryId);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Guid>> Update(Guid id, [FromBody] SubCategory subCategory)
        {
            var subCategoryId = await _subCategoriesRepository.UpdateSubCategoryAsync(id, subCategory.Title);
            return Ok(subCategoryId);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var subCategoryId = await _subCategoriesRepository.DeleteSubCategoryAsync(id);
            return Ok(subCategoryId);
        }
    }
}
