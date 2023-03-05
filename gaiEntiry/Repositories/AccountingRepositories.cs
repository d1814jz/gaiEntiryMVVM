using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gaiEntiry.Repositories;

namespace gaiEntiry.Repositories
{
    class AccountingRepositories
    {
        //-получить учет 
        public static List<Accounting> GetAllAccountings()
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                var result = db.Accounting.ToList();
                return result;
            }
        }
        //-добавить учет
        public static string CreateAccounting(string number, string color, DateTime firstDate, DateTime lastDate, Worker worker,
            Driver driver, Auto auto)
        {
            string result = "Уже существует";
            using (gaiEngEntities db = new gaiEngEntities())
            {
                bool checkIsExist = db.Accounting.Any(u => u.Number == number && u.Color == color && u.FirstDate == firstDate
                && u.LastDate == lastDate && u.idWorker == worker.id && u.idDriver == driver.id && u.idAuto == auto.id);
                if (!checkIsExist)
                {
                    Accounting accounting = new Accounting
                    {
                        Number = number,
                        Color = color,
                        FirstDate = firstDate,
                        LastDate = lastDate,
                        idWorker = worker.id,
                        idDriver = driver.id,
                        idAuto = auto.id
                    };
                    db.Accounting.Add(accounting);
                    db.SaveChanges();
                    result = "Автомобиль поставлен на учет";
                }
                return result;
            }
        }

        //-изменить учет
        public static string EditAccounting(Accounting oldAccounting, string newNumber, string newColor, DateTime newFirstDate,
            DateTime newLastDate, Worker newWorker, Driver newDriver, Auto newAuto)
        {
            string result = "Такой записи не существует";
            using (gaiEngEntities db = new gaiEngEntities())
            {
                Accounting accounting = db.Accounting.FirstOrDefault(u => u.id == oldAccounting.id);
                if (accounting != null)
                {
                    accounting.Number = newNumber;
                    accounting.Color = newColor;
                    accounting.FirstDate = newFirstDate;
                    accounting.LastDate = newLastDate;
                    accounting.idWorker = newWorker.id;
                    accounting.idDriver = newDriver.id;
                    accounting.idAuto = newAuto.id;
                    db.SaveChanges();
                    result = "Запись изменена";
                }
                return result;
            }

        }
        //-удалить учет 
        public static string DeleteAccounting(Accounting accounting)
        {
            string result = "Такого автомобиля не существует";
            using (gaiEngEntities db = new gaiEngEntities())
            {
                var tmp = db.Accounting.Where(u => u.id == accounting.id).FirstOrDefault();
                db.Accounting.Remove(tmp);
                db.SaveChanges();
                result = "Автомобиль снят с учета";
            }
            return result;
        }

        public static List<Accounting> GetAllAccountingsByAutoId(int id)
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                List<Accounting> accountings = (from accounting in GetAllAccountings() where accounting.id == id select accounting).ToList();
                return accountings;
            }
        }

        public static List<Accounting> GetAllAccountingsByDriverId(int id)
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                List<Accounting> accountings = (from accounting in GetAllAccountings() where accounting.id == id select accounting).ToList();
                return accountings;
            }
        }
        public static List<Accounting> GetAllAccountingsByWorkerId(int id)
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                List<Accounting> accountings = (from accounting in GetAllAccountings() where accounting.id == id select accounting).ToList();
                return accountings;
            }
        }
    }
}
