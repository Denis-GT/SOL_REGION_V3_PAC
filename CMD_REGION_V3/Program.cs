using LIB_REGION;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD_REGION_V3
{
  internal class Program
  {
    static void Main(string[] args)
    {
      C_BASE La_Base = new C_BASE();

      List<C_REGION> Liste_Regions = La_Base.Get_All_Region();
      Console.WriteLine(Liste_Regions.Count);

      foreach (var un_element in Liste_Regions) {
        Console.WriteLine(un_element.Debug());
      }

      List<C_DEPARTEMENT> Liste_Departements = La_Base.Get_Depatements_By_Region(Liste_Regions[0]);
      Console.WriteLine(Liste_Departements.Count);

      foreach (var Un_Departement in Liste_Departements) {
        Console.WriteLine(Un_Departement.Debug());
      }

      List<C_VILLE> Liste_Villes = La_Base.Get_Villes_By_Departement(Liste_Departements[0]);
      Console.WriteLine(Liste_Villes.Count);

      foreach (var Une_Ville in Liste_Villes) {
        Console.WriteLine(Une_Ville.Debug());
      }
    }
  }
}
