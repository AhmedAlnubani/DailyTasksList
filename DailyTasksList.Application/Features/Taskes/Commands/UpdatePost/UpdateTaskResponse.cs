﻿

namespace DailyTasksList.Application.Features.Taskes.Commands.UpdatePost
{
    #region Public Class
    public  class UpdateTaskResponse
    {
       #region Public Properties
        public long Id { get; set; }
        public required string Name { get; set; }
        public string? Priority { get; set; }
        public string? Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public string? Description { get; set; }

        #endregion Public Properties
    }
    #endregion Public Class
}
