using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaiEntiry.Interface
{
    public interface IAutoRepository
    {
        List<Auto> GetAllAutos();
        string CreateAuto(string Brand, string Model, int Year, string VinNumber);
        string EditAuto(Auto oldAuto, string newBrand, string newModel, int newYear, string newVinNumber);
        string DeleteAuto(Auto auto);
        Auto GetAutoById(int id);
    }
}
