using System.ComponentModel.DataAnnotations;

namespace SimpleProjectManagement.Models.Enums
{
    /// <summary>
    /// Статусы по приоритетам
    /// </summary>
    public enum Priority
    {
        /// <summary>
        /// Без приоритета
        /// </summary>
        None = 0,

        /// <summary>
        /// Самый низкий приоритет - задачи можно брать в работу, 
        /// если других приоритетов нет
        /// </summary>
        Lowest = 1,

        /// <summary>
        /// Низкий приоритет - несрочная и не очень важная задача
        /// </summary>
        Low = 2,

        /// <summary>
        /// Средний приоритет - срочно и не очень важно
        /// </summary>
        Medium = 3,

        /// <summary>
        /// Высокий приоритет - важно и не срочно
        /// </summary>
        High = 4,

        /// <summary>
        /// Критичный приоритет - важно и срочно
        /// </summary>
        Critical = 5
    }
}
