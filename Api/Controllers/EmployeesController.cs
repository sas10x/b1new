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
    [Authorize]
    public class EmployeesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<Question>>> List()
        {
            return await Mediator.Send(new List.Query());
        }
       
        [HttpPost]
        public async Task<ActionResult<Unit>> Create (Create.Command command)
        {
            return await Mediator.Send(command);
        }
       
        [HttpGet("{id}")]
        public async Task<ActionResult<int>> Details(int id)
        {
            return await Mediator.Send(new SignIn.Query{IdNumber = id});
        }
     
        [HttpPost("answer")]
        public async Task<ActionResult<Unit>> Daily (Daily.Command command)
        {
            return await Mediator.Send(command);
        }
       
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