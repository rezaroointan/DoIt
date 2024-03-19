using DoIt.Core.DTOs.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoIt.Core.Interfaces
{
    public interface ITaskService
    {
        Task<int> AddTaskAsync(AddTaskViewModel viewModel);

        Task<List<InboxItemViewModel>> GetTasksForInboxAsync();

        Task<int> ChangeTaskStatusAsync(int taskID);

        Task<EditTaskViewModel?> GetTaskForEditAsync(int id);

        Task<int> EditTaskAsync(EditTaskViewModel viewModel);

        Task<int> DeleteTaskAsync(int id);

        Task<List<InboxItemViewModel>> GetTasksForTodayAsync();

        Task<List<InboxItemViewModel>> GetTaskForPlannedAsync();
    }
}
