using DoIt.Core.DTOs.Tasks;
using DoIt.Core.Interfaces;
using DoIt.Data.Context;
using DoIt.Data.Entities.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
