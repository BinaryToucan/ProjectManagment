using System.ComponentModel.DataAnnotations;

namespace SimpleProjectManagement.Models
{
    /// <summary>
    /// Класс юзера
    /// </summary>
    public class User
    {
        /// <summary>
        /// Id юзера
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя юзера
        /// </summary>
        [Required]
        [StringLength(30)]
        public required string Name { get; set; }

        /// <summary>
        /// Фамилия юзера
        /// </summary>
        [StringLength(30)]
        public string? Surname { get; set; }

        /// <summary>
        /// Задачи юзера
        /// </summary>
        public ICollection<TaskTracker> Tasks { get; set; } = [];

    }
}
