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
    }
}
