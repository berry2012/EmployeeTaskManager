using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeTaskManager.Data;
using EmployeeTaskManager.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TasksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks()
        {
            return await _context.TaskItems.ToListAsync();
        }

        // GET: api/tasks/{taskId}
        [HttpGet("{taskId}")]
        public async Task<ActionResult<TaskItem>> GetTask(int taskId)
        {
            var task = await _context.TaskItems.FindAsync(taskId);
            if (task == null)
                return NotFound();
            return task;
        }

        // PUT: api/tasks/{taskId}
        [HttpPut("{taskId}")]
        public async Task<IActionResult> UpdateTask(int taskId, TaskItem task)
        {
            if (taskId != task.TaskId)
                return BadRequest();

            _context.Entry(task).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.TaskItems.Any(t => t.TaskId == taskId))
                    return NotFound();
                throw;
            }
            return NoContent();
        }

        // DELETE: api/tasks/{taskId}
        [HttpDelete("{taskId}")]
        public async Task<IActionResult> DeleteTask(int taskId)
        {
            var task = await _context.TaskItems.FindAsync(taskId);
            if (task == null)
                return NotFound();

            _context.TaskItems.Remove(task);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}