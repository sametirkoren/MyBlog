using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Interfaces;
using MyBlog.Dto.DTOs.CategoryDtos;
using MyBlog.Entities.Concrete;
using MyBlog.WebApi.CustomFilters;

namespace MyBlog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        public CategoriesController(IMapper mapper , ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<CategoryListDto>>(await _categoryService.GetAllSortedByIdAsync()));
        }

        [HttpGet("{id}")]
        [ValidModel]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<CategoryListDto>(await _categoryService.FindByIdAsync(id)));
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CategoryAddDto categoryAddDto)
        {
            await _categoryService.AddAsync(_mapper.Map<Category>(categoryAddDto));
            return Created("", categoryAddDto);
        }

        [HttpPut("{id}")]
        [Authorize]
        [ValidModel]
        [ServiceFilter(typeof(ValidId<Category>))]

        public async Task<IActionResult> Update(int id , CategoryUpdateDto categoryUpdateDto)
        {
            if (id != categoryUpdateDto.Id)
                return BadRequest("geçersiz id");
            var updatedCategory = await _categoryService.FindByIdAsync(id);
            updatedCategory.Id = categoryUpdateDto.Id;
            updatedCategory.Name = categoryUpdateDto.Name;

            await _categoryService.UpdateAsync(updatedCategory);
            return NoContent();
        } 

        [HttpDelete("{id}")]
        [Authorize]
        [ValidModel]
        [ServiceFilter(typeof(ValidId<Category>))]

        public async Task<IActionResult> Delete (int id)
        {
            await _categoryService.RemoveAsync(new Category { Id = id });
            return NoContent();
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetWithBlogsCount()
        {
            var categories = await _categoryService.GetAllWithCategoryBlogsAsyns();
            List<CategoryWithBlogsCountDto> listCategory = new List<CategoryWithBlogsCountDto>();

            foreach (var category in categories)
            {
                CategoryWithBlogsCountDto dto = new CategoryWithBlogsCountDto();
                dto.Category = category;
                dto.BlogsCount = category.CategoryBlogs.Count;

                listCategory.Add(dto);
            }

            return Ok(listCategory);
        }
    }
}