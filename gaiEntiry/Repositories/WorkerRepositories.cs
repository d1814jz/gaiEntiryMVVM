using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gaiEntiry.Repositories;

namespace gaiEntiry.Repositories
{
    class WorkerRepositories
    {
        public static List<Worker> GetAllWorkers()
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                var result = db.Worker.ToList();
                return result;
            }
        }


        //-добавить сотрудника
        public static string CreateWorker(string LastName, string FirstName, string Surname, Rank rank)
        {
            string result = "Такой сотрудник уже есть";
            using (gaiEngEntities db = new gaiEngEntities())
            {
                bool checkIsExitst = db.Worker.Any(u => u.FirsName == FirstName && u.LastName == u.LastName && u.Surname == Surname && u.idRank == rank.id);
                if (!checkIsExitst)
                {
                    Worker newWorker = new Worker
                    {
                        LastName = LastName,
                        FirsName = FirstName,
                        Surname = Surname,
                        idRank = rank.id
                    };
                    db.Worker.Add(newWorker);
                    db.SaveChanges();
                    result = "Сотрудник добавлен";
                }
                return result;
            }
        }
        //изменить сотрудника

        public static string EditWorker(Worker oldWorker, string newLastName, string newFirstName, string newSurname, Rank newRank)
        {
            string result = "Такого сотрудника не существует";
            using (gaiEngEntities db = new gaiEngEntities())
            {
                Worker worker = db.Worker.FirstOrDefault(u => u.id == oldWorker.id);
                if (worker != null)
                {
                    worker.FirsName = newFirstName;
                    worker.LastName = newLastName;
                    worker.Surname = newSurname;
                    worker.idRank = newRank.id;
                    db.SaveChanges();
                    result = $"Сострудник изменен";
                }
            }
            return result;
        }

        //-удалить сотрудника
        public static string DeleteWorker(Worker worker)
        {
            string result = "Такого звания не существует";
            using (gaiEngEntities db = new gaiEngEntities())
            {
                var tmp = db.Worker.Where(u => u.id == worker.id).FirstOrDefault();
                db.Worker.Remove(tmp);
                db.SaveChanges();
                result = "Сотрудник удален";
            }
            return result;
        }

        public static Worker GetWorkerById(int id)
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                Worker worker = db.Worker.FirstOrDefault(u => u.id == id);
                return worker;
            }
        }
    }
}
