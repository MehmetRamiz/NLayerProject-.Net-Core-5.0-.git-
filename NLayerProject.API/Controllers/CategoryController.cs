﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.API.Dto;
using NLayerProject.Core.Models;
using NLayerProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;


        public CategoryController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));
                
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            return Ok(_mapper.Map<CategoryDto>(category));

        }


        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            var newCategory = await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));

            return Created(string.Empty, _mapper.Map<CategoryDto>(newCategory));
        } 

        [HttpPut]
        public IActionResult Update(CategoryDto categoryDto)
        {
            var category = _categoryService.Update(_mapper.Map <Category>(categoryDto));

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetByIdAsync(id).Result;

            _categoryService.Remove(category);

            return NoContent();
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetWithProductById(int id)
        {
            var category = await _categoryService.GetWithProdcutsByIdAsync(id);

            return Ok(_mapper.Map<CategoryWithProductDto>(category));
        }

    }
}
