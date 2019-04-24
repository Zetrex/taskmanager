using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        // GET: api/ToDo
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ToDo/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(uint id)
        {
            TaskItem taskItem = null;
            try
            {
                taskItem = new TaskItem(id);
            }
            catch (ArgumentException ex)
            {
                Response.StatusCode = 400;
                return Content(ex.Message);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 404;
                return Content(ex.Message);
            }

            return new JsonResult(taskItem);
        }

        // POST: api/ToDo
        [HttpPost]
        public ActionResult Post([FromBody] string text)
        {
            try
            {
                TaskItem.Create(text);
            }
            catch (ArgumentException ex)
            {
                Response.StatusCode = 400;
                return Content(ex.Message);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 404;
                return Content(ex.Message);
            }

            Response.StatusCode = 200;
            return Content("Запись успешно добавлена");
        }

        // PUT: api/ToDo/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string text)
        {
            try
            {
                TaskItem.Update((uint)id, text);
            }
            catch (ArgumentException ex)
            {
                Response.StatusCode = 400;
                return Content(ex.Message);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 404;
                return Content(ex.Message);
            }

            Response.StatusCode = 200;
            return Content("Запись успешно изменена");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                TaskItem.Delete((uint)id);
            }
            catch (ArgumentException ex)
            {
                Response.StatusCode = 400;
                return Content(ex.Message);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 404;
                return Content(ex.Message);
            }

            Response.StatusCode = 200;
            return Content("Запись успешно удалена");
        }
    }
}
