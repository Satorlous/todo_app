using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModels;
using LinqToDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task = DataModels.Task;

namespace TodoApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        [HttpGet("tasks")]
        public IEnumerable<Task> Get()
        {
            using (var db = new TodoDbDB())
            {
                var tasks = db.Tasks.LoadWith(x => x.Importance).LoadWith(x => x.Owner).LoadWith(x => x.Users).ToList();
                tasks.ForEach(t => { t.Owner.Password = null; } );
                return tasks;
            }
        }
    }
}