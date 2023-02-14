using gaiEntiry.Insert;
using gaiEntiry.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace gaiEntiry
{
    class OtherCommands
    {
        public static void getInsertWindow(string tableName)
        {
            Window windowInsert = null;
            switch (tableName)
            {
                case "Auto":
                    windowInsert = new InsertAuto();
                    break;
                case "Driver":
                    windowInsert = new InsertDriver();
                    break;
                case "IllegalType":
                    windowInsert = new InsertIllegalType();
                    break;
                case "Rank":
                    windowInsert = new InsertRank();
                    break;
            }
            windowInsert.Show();
        }

        public static void getUpdateWindow(string tableName, int id)
        {
            Window windowUpdate = null;
            switch (tableName)
            {
                case "Auto":
                    windowUpdate = new UpdateAuto(id);
                    break;
                case "Driver":
                    windowUpdate = new UpdateDriver(id);
                    break;
                case "IllegalType":
                    windowUpdate = new UpdateIllegalType(id);
                    break;
                case "Rank":
                    windowUpdate = new UpdateRank(id);
                    break;
            }
            windowUpdate.Show();
        }

        public static void deleteItemFromDictionary(string tableName, int id)
        {
            using(gaiEngEntities db = new gaiEngEntities())
            {
                var entity = null;
                switch (tableName)
                {
                    case "Auto":
                        entity = db.Auto; 
                        break;
                    case "Driver":
                        entity = db.Driver;
                        break;
                    case "IllegalType":
                        entity = db.IllegalType;
                        break;
                    case "Rank":
                       entity = db.Rank;
                        break;
                }
            }
        }
    }
}
