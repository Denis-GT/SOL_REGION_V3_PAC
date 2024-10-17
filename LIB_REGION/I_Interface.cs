using System.Collections.Generic;

namespace LIB_REGION
{
  interface I_Interface
  {
    List<C_REGION> Get_All_Region();
    List<C_DEPARTEMENT> Get_Departements_By_Region(C_REGION P_Region);
  }
}
