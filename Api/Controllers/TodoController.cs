using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Commands;
using Domain.Entities;
using Domain.Handlers;
using Infra.Contexts;
using Infra.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    [Authorize]
    public class TodoController : ControllerBase
    {
        private readonly TodoRepository _repository;
        private readonly TodoHandler _handler;

        public TodoController(DataContext context, TodoHandler handler)
        {
            _handler = handler;
            _repository = new TodoRepository(context);
        }

        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<TodoItem>> GetAll()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var result = _repository.GetAll(user);

            return Ok(result);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public ActionResult<TodoItem> GetById(Guid id)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var result = _repository.GetById(id, user);

            return Ok(result);
        }
        
        [HttpGet]
        [Route("done")]
        public ActionResult<IEnumerable<TodoItem>> GetAllDone()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var result = _repository.GetAllDone(user);

            return Ok(result);
        }
        
        [HttpGet]
        [Route("undone")]
        public ActionResult<IEnumerable<TodoItem>> GetAllUndone()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var result = _repository.GetAllUndone(user);

            return Ok(result);
        }
        
        [HttpGet]
        [Route("done/today")]
        public ActionResult<IEnumerable<TodoItem>> GetDoneForToday()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var result = _repository.GetByPeriod(user, DateTime.Now.Date, true);

            return Ok(result);
        }
        
        [HttpGet]
        [Route("undone/today")]
        public ActionResult<IEnumerable<TodoItem>> GetUndoneForToday()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var result = _repository.GetByPeriod(user, DateTime.Now.Date, false);

            return Ok(result);
        }
        
        [HttpGet]
        [Route("done/tomorrow")]
        public ActionResult<IEnumerable<TodoItem>> GetDoneForTomorrow()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var result = _repository.GetByPeriod(user, DateTime.Now.Date.AddDays(1), true);

            return Ok(result);
        }
        
        [HttpGet]
        [Route("undone/tomorrow")]
        public ActionResult<IEnumerable<TodoItem>> GetUndoneForTomorrow()
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var result = _repository.GetByPeriod(user, DateTime.Now.Date.AddDays(1), false);

            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public ActionResult<GenericCommandResult> Create([FromBody] CreateTodoCommand command)
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var result = _handler.Handle(command);

            return Ok(result);
        }
        
        [HttpPut]
        [Route("")]
        public ActionResult<GenericCommandResult> Update([FromBody] UpdateTodoCommand command)
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var result = _handler.Handle(command);

            return Ok(result);
        }
        
        [HttpPut]
        [Route("mark-as-done")]
        public ActionResult<GenericCommandResult> MarkAsDone([FromBody] MarkTodoAsDoneCommand command)
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var result = _handler.Handle(command);

            return Ok(result);
        }
        
        [HttpPut]
        [Route("mark-as-undone")]
        public ActionResult<GenericCommandResult> MarkAUndone([FromBody] MarkTodoAsUndoneCommand command)
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var result = _handler.Handle(command);

            return Ok(result);
        }
    }
}