using System.ComponentModel.DataAnnotations;

namespace SimpleProjectManagement.Models.Enums
{
    /// <summary>
    /// Статусы задач
    /// </summary>
    public enum StatusTask
    {
        /// <summary>
        /// Нет статуса
        /// </summary>
        [Display(Name = "Без статуса")]
        None = 0,

        /// <summary>
        /// В планах
        /// </summary>
        [Display(Name = "To Do")]
        ToDo = 1,

        /// <summary>
        /// Заморожено
        /// </summary>
        [Display(Name = "Hold")]
        Hold = 2,

        /// <summary>
        /// Переделать
        /// </summary>
        [Display(Name = "Rework")]
        Rework = 3,

        /// <summary>
        /// В работе
        /// </summary>
        [Display(Name = "In progress")]
        InProgress = 4,

        /// <summary>
        /// Код-ревью
        /// </summary>
        [Display(Name = "Code Review")]
        CodeReview = 5,

        /// <summary>
        /// В тесте
        /// </summary>
        [Display(Name = "Test")]
        Test = 6,

        /// <summary>
        /// Тесты пройдены
        /// </summary>
        [Display(Name = "Test Done")]
        TestDone = 7,

        /// <summary>
        /// Готово
        /// </summary>
        [Display(Name = "Done")]
        Done = 8
    }
}
