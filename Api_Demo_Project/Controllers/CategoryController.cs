﻿using Api_Demo_Project.DAL.Context;
using Api_Demo_Project.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Api_Demo_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        Context context=new Context();
        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = context.Categories.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            object value = context.Categories.Add(category);
            return Ok(category);
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var values = context.Categories.Find(id);
            context.Categories.Remove(values);
            context.SaveChanges();
            if (values != null)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var values = context.Categories.Find(id);
            if (values == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(values);
            }
        }
        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            var values = context.Categories.Find(category.CategoryID);
            values.CategoryName = category.CategoryName;
            values.CategoryDescription = category.CategoryDescription;
            values.CategoryStatus = category.CategoryStatus;
            context.SaveChanges();
            return Ok();
        }
    }
}
