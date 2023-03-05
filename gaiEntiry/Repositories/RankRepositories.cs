using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Repositories
{
    class RankRepositories
    {
        public static List<Rank> GetAllRanks()
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                var result = db.Rank.ToList();
                return result;
            }
        }
        //+добавить звание

        public static string CreateRank(string Rank)
        {
            string result = "Такое звание уже есть";
            using (gaiEngEntities db = new gaiEngEntities())
            {
                var checkIsExist = db.Rank.Any(u => u.Rank1 == Rank);
                if (!checkIsExist)
                {
                    Rank newRank = new Rank
                    {
                        Rank1 = Rank
                    };

                    db.Rank.Add(newRank);
                    db.SaveChanges();
                    result = "Звание добавлено";
                }
                return result;
            }
        }
        //+изменить звание

        public static string EditRank(Rank oldRank, string newRank)
        {
            string result = "Такого звания не существует";
            using (gaiEngEntities db = new gaiEngEntities())
            {
                Rank rank = db.Rank.FirstOrDefault(u => u.id == oldRank.id);
                rank.Rank1 = newRank;
                db.SaveChanges();
                result = "Звание изменено";
            }
            return result;
        }

        //+удалить звание

        public static string DeleteRank(Rank rank)
        {
            string result = "Такого звания не существует";
            using (gaiEngEntities db = new gaiEngEntities())
            {
                var tmp = db.Rank.Where(u => u.id == rank.id).FirstOrDefault();
                db.Rank.Remove(tmp);
                db.SaveChanges();
                result = "Звание удалено";
            }
            return result;
        }


        //получить звание по id

        public static Rank GetRankById(int id)
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                Rank rank = db.Rank.FirstOrDefault(u => u.id == id);
                return rank;
            }
        }

        //получить сотрудника по id звания

        public static List<Worker> GetAllWorkersByRankId(int id)
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                List<Worker> workers = (from worker in WorkerRepositories.GetAllWorkers() where worker.idRank == id select worker).ToList();
                return workers;
            }
        }

        //получить звание по id сотрудника

        public static List<Rank> GetAllRanksByWorkerId(int id)
        {
            using (gaiEngEntities db = new gaiEngEntities())
            {
                List<Rank> ranks = (from rank in GetAllRanks() where rank.id == id select rank).ToList();
                return ranks;
            }
        }
    }
}
