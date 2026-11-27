using System;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Application.DTOs
{
    public class TaskItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public TaskItemStatus Status { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public int CreatedByUserId { get; set; }
        public int? AssignedToUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateTaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;
        public DateTime? DueDate { get; set; }
        public int? AssignedToUserId { get; set; }
    }

    public class UpdateTaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public TaskItemStatus Status { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public int? AssignedToUserId { get; set; }
    }

    public class TaskSummaryDto
    {
        public int PendingCount { get; set; }
        public int InProgressCount { get; set; }
        public int CompletedCount { get; set; }
        public int TotalCount { get; set; }
    }
}