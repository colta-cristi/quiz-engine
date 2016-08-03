﻿using Qubiz.QuizEngine.Database;
using Qubiz.QuizEngine.Database.Entities;
using Qubiz.QuizEngine.Services.AdminService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Qubiz.QuizEngine.Areas.M.Controllers.Api
{
    public class NewAdminController : ApiController
    {
        private readonly IAdminService adminService;

        public NewAdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        [HttpGet]
        [Route("M/api/admin/getAdmins")]
        public IHttpActionResult GetAdmins()
        {
            Admin[] admin = adminService.GetAllAdminsAsync().Result;
            return Ok(admin);
        }

        [HttpGet]
        public IHttpActionResult GetLoggedIn()
        {
            string Logged = HttpContext.Current.User.Identity.Name;
            return Ok(Logged);
        }

        [HttpPost]
        public void AddAdmin([FromBody]Admin admin)
        {
            adminService.AddAdminAsync(admin);
        }

        [HttpDelete]
        public IHttpActionResult DeleteAdmin(Guid id)
        {
            if (adminService.DeleteAdminAsync(id))
                return Ok();

            return NotFound();
        }

        [HttpPut]
        public void UpdateAdmin([FromBody]Admin admin)
        {
            adminService.UpdateAdminAsync(admin);
        }
    }
}