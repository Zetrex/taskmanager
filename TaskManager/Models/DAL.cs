using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public static class DAL
    {
        /// <summary>
        /// Список задач
        /// </summary>
        private static List<TaskItem> TaskItemsList = new List<TaskItem>()
        {
            new TaskItem(0, "Найти вакансию"),
            new TaskItem(1, "Пройти интервью"),
            new TaskItem(2, "Сделать тестовое задание"),
            new TaskItem(3, "Устроиться на работу")
        };

        /// <summary>
        /// Получение задачи из списка
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static TaskItem GetTaskItem(uint id)
        {
            return TaskItemsList.Find(t => t.Id == id);
        }

        /// <summary>
        /// Получить список задач
        /// </summary>
        /// <returns></returns>
        public static List<TaskItem> GetTaskItemsList()
        {
            return TaskItemsList;
        }

        /// <summary>
        /// Создание новой задачи
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static uint CreateTaskItem(string text)
        {
            uint id = TaskItemsList.Max(t => t.Id) + 1;
            TaskItemsList.Add(new TaskItem(id, text));

            return id;
        }

        /// <summary>
        /// Изменить задачу
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newText"></param>
        /// <returns></returns>
        public static bool Update(uint id, string newText)
        {
            var taskItem = TaskItemsList.Find(t => t.Id == id);

            if (taskItem == null)
                return false;

            taskItem.Text = newText;

            return true;
        }

        /// <summary>
        /// Удалить задачу по ид
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete(uint id)
        {
            var taskItem = GetTaskItem(id);

            if (taskItem == null)
                return false;

            TaskItemsList.Remove(taskItem);

            return true;
        }
    }
}
