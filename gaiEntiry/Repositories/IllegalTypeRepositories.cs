using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gaiEntiry.Repositories;

namespace gaiEntiry.Repositories
{
    class IllegalTypeRepositories
    {
        //+получить виды нарушений
        public static List<IllegalType> GetAllIllegalTypes()
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                var result = db.IllegalType.ToList();
                return result;
            }
        }
        //+создать вид нарушения

        public static string CreateIllegalType(string IllegalType, int Fine, bool Notice, int Tod)
        {
            string result = "Такой вид нарушения уже существует";
            using (gaiEngEntities db = new gaiEngEntities())
            {
                bool checkIsExist = db.IllegalType.Any(u => u.IllegalType1 == IllegalType
                    && u.Fine == Fine && u.Tod == Tod && u.Notice == Notice);
                if (!checkIsExist)
                {
                    IllegalType newIllegalType = new IllegalType
                    {
                        IllegalType1 = IllegalType,
                        Fine = Fine,
                        Notice = Notice,
                        Tod = Tod
                    };
                    db.IllegalType.Add(newIllegalType);
                    db.SaveChanges();
                    result = "Вид нарушения добавлен";
                }
                return result;
            }
        }
        //+изменить вид нарушения
        public static string EditIllegalType(IllegalType oldIllegalType, string newIllegalType, int newFine, bool newNotice, int newTod)
        {
            string result = "Такого вида нарушения не существует";
            using (gaiEngEntities db = new gaiEngEntities())
            {
                IllegalType illegalType = db.IllegalType.FirstOrDefault(u => u.id == oldIllegalType.id);
                illegalType.IllegalType1 = newIllegalType;
                illegalType.Fine = newFine;
                illegalType.Notice = newNotice;
                illegalType.Tod = newTod;
                db.SaveChanges();
                result = "Вид нарушения " + illegalType.IllegalType1 + " изменен";
            }
            return result;

        }


        //+удалить вид нарушения
        public static string DeleteIllegalType(IllegalType illegalType)
        {
            string result = "Такого вида нарушения не существует";
            using (gaiEngEntities db = new gaiEngEntities())
            {
                var tmp = db.IllegalType.Where(u => u.id == illegalType.id).FirstOrDefault(); ;
                db.IllegalType.Remove(tmp);
                db.SaveChanges();
                result = "Вид нарушения " + illegalType.IllegalType1 + " удален";
            }
            return result;
        }


        //Получить вид нарушения по id
        public static IllegalType GetIllegalTypeById(int id)
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                IllegalType it = db.IllegalType.FirstOrDefault(u => u.id == id);
                return it;
            }
        }
    }
}
