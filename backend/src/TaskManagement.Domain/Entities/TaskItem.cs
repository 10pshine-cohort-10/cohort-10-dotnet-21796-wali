using System;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Domain.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public TaskItemStatus Status { get; set; } = TaskItemStatus.Pending;
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;
        public DateTime? DueDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }

        public int? AssignedToUserId { get; set; }
        public User AssignedToUser { get; set; }
    }
}