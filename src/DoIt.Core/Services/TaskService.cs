using DoIt.Core.DTOs.Tasks;
using DoIt.Core.Interfaces;
using DoIt.Data.Context;
using DoIt.Data.Entities.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;


namespace DoIt.Core.Services
{
    public class TaskService : ITaskService
    {
        private readonly DoItDbContext _db;

        public TaskService(DoItDbContext db)
        {
            _db = db;
        }

        public async Task<int> AddTaskAsync(AddTaskViewModel viewModel)
        {
            // Create TimeSpan from view model hours and minutes
            TimeSpan timeBlock = TimeSpan.FromMinutes((viewModel.TimeBlockHours * 60) + viewModel.TimeBlockMinutes);
            
            // Init entity model
            DoIt.Data.Entities.Tasks.Task newTask = new()
            {
                Title = viewModel.Title,
                UserId = viewModel.UserId,
                Created = DateTime.Now,
                Duration = viewModel.Duration,
                Reminder = viewModel.Reminder,
                TimeBlock = timeBlock,
                Description = viewModel.Description,
            };

            // Add new task to DB
            _db.Tasks.Add(newTask);

            // Save changes and return result
            return await _db.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task<int> ChangeTaskStatusAsync(int taskID)
        {
            // Retrieve task by id
            Data.Entities.Tasks.Task? task = await _db.Tasks.FindAsync(taskID);

            // Check task with that id is exist
            if (task == null)
                return await System.Threading.Tasks.Task.FromResult(0);

            // Change task status
            task.Done = !(task.Done);

            // Update and save changes
            _db.Tasks.Update(task);
            return await _db.SaveChangesAsync();
        }

        public async Task<List<InboxItemViewModel>> GetTasksForInbox()
        {
            // Retrieve list of tasks
            var tasks =  await _db.Tasks.Select(t => new InboxItemViewModel()
            {
                Id = t.Id,
                Title = t.Title,
                Created = t.Created,
                Duration = t.Duration,
                Reminder = t.Reminder,
                Done = t.Done,
                TimeBlock = t.TimeBlock
            })
                .OrderBy(t => t.Created) 
                .ToListAsync();

            return tasks;
        }
    }
}
