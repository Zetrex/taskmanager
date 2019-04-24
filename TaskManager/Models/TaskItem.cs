using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    /// <summary>
    /// Задача
    /// </summary>
    public class TaskItem
    {
        /// <summary>
        /// Ид
        /// </summary>
        public uint Id { get => _Id; }
        private uint _Id;

        /// <summary>
        /// Текст задачи
        /// </summary>
        public string Text { get => _Text; set => _Text = value; }
        private string _Text;

        /// <summary>
        /// Получить задачу по ид
        /// </summary>
        /// <param name="id"></param>
        public TaskItem(uint id)
        {
            var taskItem = DAL.GetTaskItem(id);

            if (taskItem == null)
                throw new Exception("Задачи с id = " + id + " не существует");

            _Id = taskItem.Id;
            _Text = taskItem.Text;
        }

        public TaskItem(uint id, string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Не передан текст задачи");

            _Id = id;
            _Text = text;
        }

        /// <summary>
        /// Получить список задач
        /// </summary>
        /// <returns></returns>
        public static List<TaskItem> GetList()
        {
            return DAL.GetTaskItemsList();
        }

        /// <summary>
        /// Сохдать новую задачу
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static uint Create(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Не передан текст задачи");

            return DAL.CreateTaskItem(text);
        }

        /// <summary>
        /// Изменить задачу
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newText"></param>
        /// <returns></returns>
        public static bool Update(uint id, string newText)
        {
            if (string.IsNullOrWhiteSpace(newText))
                throw new ArgumentException("text is null or empty");

            return DAL.Update(id, newText);
        }

        /// <summary>
        /// Удалить задачу по ид
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete(uint id)
        {
            return DAL.Delete(id);
        }
    }
}
