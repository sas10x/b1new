using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Employees;
using System.Collections.Generic;
using Domain;
using MediatR;
using System;

namespace Api.Controllers
{
    public class EmployeesController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<Question>>> List()
        {
            return await Mediator.Send(new List.Query());
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<Unit>> Create (Create.Command command)
        {
            return await Mediator.Send(command);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<int>> Details(int id)
        {
            return await Mediator.Send(new SignIn.Query{IdNumber = id});
        }
        [AllowAnonymous]
        [HttpPost("answer")]
        public async Task<ActionResult<Unit>> Daily (Daily.Command command)
        {
            return await Mediator.Send(command);
        }
        [AllowAnonymous]
      
        [HttpGet("answers/{petsa}")]
        public async Task<ActionResult<List<AnswerDto>>> Report(string petsa)
        {
            return await Mediator.Send(new Report.Query{Petsa = petsa});
        }
        //  [HttpGet("answer/petsa")]
        // public async Task<ActionResult<List<Answer>>> List(string to, 
        //     string from)
        // {
        //     return await Mediator.Send(new ReportPetsa.Query(to, 
        //         from));
        // }
    }
}