﻿using BLL.DTOModels;
using BLL.ServiceInterfaces;
using BLL_EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BazyDanych.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsControllerEF : ControllerBase
    {

        [HttpGet]
        public List<ProductResponseDTO> getProducts()
        {
            return service.getProducts();
        }

        [HttpPost]
        public void addProduct([FromQuery] string name, [FromQuery] double price, [FromQuery] int groupId)
        {
            service.addProduct(name, price, groupId);
        }




    }
}
