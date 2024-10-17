using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using Microsoft.Maps.MapControl.WPF;

namespace LIB_REGION
{

  public class C_BASE
  {
    public List<C_REGION> Les_Regions;
    public List<C_DEPARTEMENT> Les_Depatements;
    public List<C_VILLE> Les_Villes;
    public List<C_EMETTEUR> Les_Emetteurs;


    public C_BASE()
    {
      string Data_Json = File.ReadAllText("regions.json");
      Les_Regions = JsonSerializer.Deserialize<List<C_REGION>>(Data_Json);

      Data_Json = File.ReadAllText("departments.json");
      Les_Depatements = JsonSerializer.Deserialize<List<C_DEPARTEMENT>>(Data_Json);

      Data_Json = File.ReadAllText("cities.json");
      Les_Villes = JsonSerializer.Deserialize<List<C_VILLE>>(Data_Json);

      Data_Json = File.ReadAllText("Emetteurs_Reduits_2023.json");
      Les_Emetteurs = JsonSerializer.Deserialize<List<C_EMETTEUR>>(Data_Json);
    }

    //------------------------------------

    public List<C_REGION> Get_All_Region()
    {
      return Les_Regions;
    }

    public List<C_DEPARTEMENT> Get_Departements_By_Region(C_REGION P_Region)
    {
      List<C_DEPARTEMENT> Departements_Trouvee = new List<C_DEPARTEMENT>();

      foreach (var Un_Departement in Les_Depatements) {
        if (Un_Departement.region_code == P_Region.code) Departements_Trouvee.Add(Un_Departement);
      }
      return Departements_Trouvee;
    }

    public List<C_VILLE> Get_Villes_By_Departement(C_DEPARTEMENT P_Departement)
    {
      List<C_VILLE> Villes_Trouvees = new List<C_VILLE>();

      foreach (var Une_Ville in Les_Villes) {
        if (Une_Ville.department_code == P_Departement.code) Villes_Trouvees.Add(Une_Ville);
      }
      return Villes_Trouvees;
    }

    //Emetteurs ===========================================================
    public List<C_EMETTEUR> Get_All_Emetteurs_By_Code_Postal(string P_Code)
    {
      List<C_EMETTEUR> Emetteurs_Trouves = new List<C_EMETTEUR>();
      for (int Index = 0; Index < Les_Emetteurs.Count; Index++) {
        if (Les_Emetteurs[Index].CP == P_Code) {
          Emetteurs_Trouves.Add(Les_Emetteurs[Index]);
        }
      }
      return Emetteurs_Trouves;
    }

    public List<C_EMETTEUR> Filter_List_Emetteurs_By_Adm(string P_Adm, List<C_EMETTEUR> P_Emetteurs)
    {
      List<C_EMETTEUR> Emetteurs_Trouves = new List<C_EMETTEUR>();
      for (int Index = 0; Index < P_Emetteurs.Count; Index++) {
        if (P_Emetteurs[Index].Adm == P_Adm) {
          Emetteurs_Trouves.Add(P_Emetteurs[Index]);
        }
      }
      return Emetteurs_Trouves;
    }

    public List<C_EMETTEUR> Clear_Emetteurs_By_Adm(string P_Adm, List<C_EMETTEUR> P_Emetteurs)
    {
      List<C_EMETTEUR> Emetteurs = new List<C_EMETTEUR>();
      foreach (var Un_Emetteur in P_Emetteurs) {
        if (Un_Emetteur.Adm != P_Adm) {
          Emetteurs.Add(Un_Emetteur);
        }
      }
      return Emetteurs;
    }
  }
}
