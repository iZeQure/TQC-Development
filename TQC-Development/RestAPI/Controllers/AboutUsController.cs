﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Data;
using RestAPI.Data.Interfaces;
using RestAPI.Data.Objects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AboutUsController : ControllerBase
    {
        public IRepository<AboutUs> Repository { get; } = new AboutUsRepository();

        // GET: api/<AboutUsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AboutUs>>> Get()
        {
            IEnumerable<AboutUs> abouts = await Repository.GetAll();

            if (abouts == null) return NotFound();

            return abouts.ToList();
        }

        // GET api/<AboutUsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AboutUs>> Get(int id)
        {
            if (id == 0) return NotFound();

            AboutUs data = await Repository.GetById(id);

            if (data == null) return NotFound();

            return data;
        }

        // POST api/<AboutUsController>
        [HttpPost]
        public void Post([FromBody] AboutUs data)
        {
            if (data == null) return;
            Repository.Insert(data);
        }

        // PUT api/<AboutUsController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] AboutUs data)
        {
            if (data == null || data.BaseId == 0) return;
            Repository.Update(data);
        }

        // DELETE api/<AboutUsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id == 0) return;

            Repository.Delete(id);
        }
    }
}
