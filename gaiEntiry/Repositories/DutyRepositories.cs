using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Repositories
{
    class DutyRepositories
    {
        //-все дежурства
        public static List<Duty> GetAllDuties()
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                var result = db.Duty.ToList();
                return result;
            }
        }
        //-добавить дежурство
        public static string CreateDuty(DateTime date, string place, Worker worker)
        {
            string result = "Уже существует";
            using (gaiEngEntities db = new gaiEngEntities())
            {
                bool checkIsExist = db.Duty.Any(u => u.Date == date && u.Place == place && u.idWorker == worker.id);
                if (!checkIsExist)
                {
                    Duty newDuty = new Duty
                    {
                        Date = date,
                        Place = place,
                        idWorker = worker.id
                    };
                    db.Duty.Add(newDuty);
                    db.SaveChanges();
                    result = "Дежурство добавлено";
                }
                return result;
            }
        }
        //-удалить дежурство
        public static string DeleteDuty(Duty duty)
        {
            string result = "Такого дежурства не существует";
            using (gaiEngEntities db = new gaiEngEntities())
            {
                var tmp = db.Duty.Where(u => u.Date == duty.Date && u.Place == duty.Place && u.idWorker == duty.idWorker)
                    .FirstOrDefault();
                db.Duty.Remove(tmp);
                db.SaveChanges();
                result = "Дежурство удалено";
            }
            return result;
        }

        //-изменить дежурство

        public static string EditDuty(Duty oldDuty, DateTime newDate, string newPlace, Worker newWorker)
        {
            string result = "Такого дежурства не существует";
            using (gaiEngEntities db = new gaiEngEntities())
            {
                Duty duty = db.Duty.FirstOrDefault(u => u.id == oldDuty.id);
                if (duty != null)
                {
                    duty.Date = newDate;
                    duty.Place = newPlace;
                    duty.idWorker = newWorker.id;
                    db.SaveChanges();
                    result = "Дежурство изменено";
                }
            }
            return result;
        }

        public static Duty GetDutyById(int id)
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                Duty duty = db.Duty.FirstOrDefault(u => u.id == id);
                return duty;
            }
        }
        //Получить дежурство по id сотрудника
        public static List<Duty> GetAllDutiesByWorkerId(int id)
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                List<Duty> duties = (from duty in GetAllDuties() where duty.idWorker == id select duty).ToList();
                return duties;
            }
        }

        //Получить сотрудика по id дежурства
        public static List<Worker> GetAllWorkersByDutyId(int id)
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                List<Worker> workers = (from worker in WorkerRepositories.GetAllWorkers() where worker.id == id select worker).ToList();
                return workers;
            }
        }
    }
}
