using SimpleProjectManagement.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SimpleProjectManagement.Models;

/// <summary>
/// Класс задач
/// </summary>
public class TaskTracker
{
    /// <summary>
    /// Id задачи
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название задачи
    /// </summary>
    [Required]
    public required string Title { get; set; }

    /// <summary>
    /// Описание задачи
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Дата создания задачи
    /// </summary>
    [Display(Name = "Create Date")]
    [DataType(DataType.Date)]
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// Приоритет задачи
    /// </summary>
    public Priority Priority { get; set; } = Priority.None;

    /// <summary>
    /// Статус задачи
    /// </summary>
    public StatusTask Status { get; set; } = StatusTask.None;

    /// <summary>
    /// Внешний ключ для связи с таблицей Users
    /// </summary>
    public int? AssignId { get; set; }

    /// <summary>
    /// Исполнитель задачи
    /// </summary>
    public User? Assign { get; set; } = null;
}
