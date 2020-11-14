using System;
using System.Collections.Generic;

namespace ToDo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание TODO лист
            // + 2. добавить новые задачи в лист
            // + 1. просмотреть лист
            // + 4. удалить из листа задачу
            // + 5. редактировать 
            // + 3. отметить что мы выполнили задачу

            WorkTask workTask = new WorkTask();

            workTask.Done();



            List<TodoTask> todoList = new List<TodoTask>
            {
                new TodoTask { Title = "Поесть", DueDate = new DateTime(2020, 11, 9, 13, 0, 0) },
                new TodoTask { Title = "Поспать", DueDate = new DateTime(2020, 11, 8, 18, 0, 0) },
                new TodoTask { Title = "Сделать домашку", DueDate = new DateTime(2020, 11, 10, 18, 0, 0) },
            };

            bool isExit = false;
            while (!isExit)
            {
                ShowMenu();
                var answerCommand = Console.ReadLine();

                switch (answerCommand)
                {
                    case "add":
                        AddTaskToTodoList(todoList);
                        continue;
                    case "edit":
                        ShowTodoList(todoList);
                        EditTaskToTodoList(todoList);
                        continue;
                    case "list":
                        ShowTodoList(todoList);
                        continue;
                    case "complete":
                        ShowTodoList(todoList);
                        CompleteTask(todoList);
                        continue;
                    case "remove":
                        RemoveTask(todoList);
                        continue;
                    case "exit":
                        Console.WriteLine("Программа завершена");
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Неправильная команда");
                        break;
                }
                Console.WriteLine("-----------------------------------");
            }
        }

        static void RemoveTask(List<TodoTask> todoList)
        {
            Console.WriteLine("Введите порядковый номер задачи, которую вы хотите удалить");
            string answerIndex = Console.ReadLine();

            bool isParsed = int.TryParse(answerIndex, out int index);
            if (isParsed && index < todoList.Count)
            {
                todoList.RemoveAt(index);
            }
            else
            {
                Console.WriteLine($"Не найдена задача с порядковым номером {answerIndex}");
            }
        }

        static void CompleteTask(List<TodoTask> todoList)
        {
            Console.WriteLine("Введите порядковый номер задачи, которую выполнили");
            string answerIndex = Console.ReadLine();

            bool isParsed = int.TryParse(answerIndex, out int index);
            if (isParsed && index < todoList.Count)
            {
                todoList[index].Done();
            }
            else
            {
                Console.WriteLine($"Не найдена задача с порядковым номером {answerIndex}");
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("Введите команду:");
            Console.WriteLine("добавить задачу - add");
            Console.WriteLine("отметить выполненным - complete");
            Console.WriteLine("удалить задачу - remove");
            Console.WriteLine("вывести список задач - list");
            Console.WriteLine("выйти из программы - exit");
        }

        static void AddTaskToTodoList(List<TodoTask> todoList)
        {
            Console.WriteLine("Добавьте задачу в лист");
            Console.WriteLine("Введите название задачи");
            string answerTitle = Console.ReadLine();

            Console.WriteLine("Введите дату задачи(yyyy/MM/DD HH:mm)");
            string answerDateTime = Console.ReadLine();

            TodoTask newTodoTask = new TodoTask
            {
                Title = answerTitle,
                DueDate = DateTime.Parse(answerDateTime)
            };

            todoList.Add(newTodoTask);
        }

        static void EditTaskToTodoList(List<TodoTask> todoList)
        {
            Console.WriteLine("Введите порядковый номер задачи, которую хотите отредактировать");
            string answerIndex = Console.ReadLine();

            bool isParsed = int.TryParse(answerIndex, out int index);
            if (!isParsed || index >= todoList.Count)
            {
                Console.WriteLine($"Не найдена задача с порядковым номером {answerIndex}");
                return;
            }

            Console.WriteLine("Добавьте задачу в лист");
            Console.WriteLine("Введите название задачи");
            string answerTitle = Console.ReadLine();

            Console.WriteLine("Введите дату задачи(yyyy/MM/DD HH:mm)");
            string answerDateTime = Console.ReadLine();

            todoList[index].Title = answerTitle;
            todoList[index].DueDate = DateTime.Parse(answerDateTime);
        }

        static void ShowTodoList(List<TodoTask> todoList)
        {
            Console.WriteLine("Список задач");

            for (int i = 0; i < todoList.Count; i++)
            {
                TodoTask task = todoList[i];
                Console.WriteLine($"{i}.{task.Title} - {task.Status} - {task.DueDate}");
            }
        }
    }

    public class WorkTask : TodoTask
    {
        public WorkTask()
        {
            Status = TaskStatus.InProgress;
        }

        public decimal Bill { get; set; }

        public override void Done()
        {
            if (Status == TaskStatus.InProgress)
                base.Done();
        }
    }

    public class TodoTask
    {
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public TaskStatus Status { get; protected set; }

        public virtual void Done()
        {
            Status = TaskStatus.Done;
        }
    }

    public enum TaskStatus
    {
        ToDo,
        InProgress,
        Done
    }
}
