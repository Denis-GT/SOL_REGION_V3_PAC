using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using LIB_REGION;

namespace WPF_REGIONS_V3.COORDINATION
{
  internal class C_COORDINATION : C_NOTIFIABLE
  {
    C_DATA La_Data;

    private List<C_EMETTEUR> _Ma_Liste_Emetteurs_Ville;
    public List<C_EMETTEUR> Ma_Liste_Emetteurs_Ville {
      get { return _Ma_Liste_Emetteurs_Ville; }
      set { _Ma_Liste_Emetteurs_Ville = value; Signale_Changement(); }
    }

    private C_EMETTEUR _Emetteur_Selectionne;
    public C_EMETTEUR Emetteur_Selectionne {
      get { return _Emetteur_Selectionne; }
      set { _Emetteur_Selectionne = value; Signale_Changement(); }
    }

    private List<C_EMETTEUR> _Ma_Liste_Emetteurs;
    public List<C_EMETTEUR> Ma_Liste_Emetteurs {
      get { return _Ma_Liste_Emetteurs; }
      set { _Ma_Liste_Emetteurs = value; Signale_Changement(); }
    }

    private List<C_REGION> _Liste_Regions;
    public List<C_REGION> Liste_Regions {
      get { return _Liste_Regions; }
      set { _Liste_Regions = value; Signale_Changement(); }
    }

    private C_REGION _Region_Selectionne;
    public C_REGION Region_Selectionne {
      get { return _Region_Selectionne; }
      set { _Region_Selectionne = value; Signale_Changement(); }
    }

    private List<C_DEPARTEMENT> _Liste_Departements;
    public List<C_DEPARTEMENT> Liste_Departements {
      get { return _Liste_Departements; }
      set { _Liste_Departements = value; Signale_Changement(); }
    }

    private C_DEPARTEMENT _Departement_Selectionne;
    public C_DEPARTEMENT Departement_Selectionne {
      get { return _Departement_Selectionne; }
      set { _Departement_Selectionne = value; Signale_Changement(); }
    }

    private List<C_VILLE> _Liste_Villes;
    public List<C_VILLE> Liste_Villes {
      get { return _Liste_Villes; }
      set { _Liste_Villes = value; Signale_Changement(); }
    }

    private C_VILLE _Ville_Selectionne;
    public C_VILLE Ville_Selectionne {
      get { return _Ville_Selectionne; }
      set { _Ville_Selectionne = value; Signale_Changement(); }
    }


    public C_COORDINATION()
    {
      La_Data = new C_DATA();
      Liste_Regions = La_Data.Get_All_Region();
    }

    internal void Charge_Liste_Departements_Pour_Region_Selectionne()
    {
      if (Region_Selectionne != null) {
        Liste_Departements = La_Data.Get_Departements_By_Region(Region_Selectionne);
      }
    }

    internal void Charge_Liste_Ville_Pour_Departement_Selectionne()
    {
      if (Departement_Selectionne != null) {
        Liste_Villes = La_Data.Get_Villes_By_Departement(Departement_Selectionne);
      }
    }

    internal Map Centre_Carte_Sur_Ville(Map P_Carte)
    {
      {
        if (Ville_Selectionne != null) {
          P_Carte.Children.Clear();
          float Latitude = Ville_Selectionne.gps_lat;
          float Longitude = Ville_Selectionne.gps_lng;
          P_Carte.Center = new Location(Latitude, Longitude);
          Ma_Liste_Emetteurs_Ville = La_Data.Get_All_Emetteurs_By_Code_Postal(Ville_Selectionne.zip_code);
          Ma_Liste_Emetteurs = new List<C_EMETTEUR>(Ma_Liste_Emetteurs_Ville);
          for (int Index = 0; Index < Ma_Liste_Emetteurs_Ville.Count; Index++) {
            Pushpin Mon_Point = new Pushpin();
            Choix_Couleur_Pin(Mon_Point, Ma_Liste_Emetteurs_Ville[Index]);
            Mon_Point.Location = new Location(Ma_Liste_Emetteurs_Ville[Index].XY[0], Ma_Liste_Emetteurs_Ville[Index].XY[1]);
            P_Carte.Children.Add(Mon_Point);
          }
          P_Carte.ZoomLevel = 12;
        }
        return P_Carte;
      }
    }

    internal Map Centre_Carte_Sur_Emetteur(Map P_Carte)
    {
      if (Emetteur_Selectionne != null) {

        P_Carte.ZoomLevel = 17;
        float Latitude = Emetteur_Selectionne.XY[0];
        float Longitude = Emetteur_Selectionne.XY[1];
        P_Carte.Center = new Location(Latitude, Longitude);
      }
      return P_Carte;
    }

    internal void Free_Cheked(Map P_Carte)
    {
      List<C_EMETTEUR> Ma_Liste = new List<C_EMETTEUR>();
      Ma_Liste = La_Data.Filter_List_Emetteurs_By_Adm("FREE MOBILE", Ma_Liste_Emetteurs_Ville);
      foreach (var Un_Emetteur in Ma_Liste) {
        Ma_Liste_Emetteurs.Add(Un_Emetteur);
      }
      Ajoute_Points(Ma_Liste, P_Carte);
    }

    internal void Free_UnCheked(Map P_Carte)
    {
      Ma_Liste_Emetteurs = La_Data.Clear_Emetteurs_By_Adm("FREE MOBILE", Ma_Liste_Emetteurs);
      P_Carte.Children.Clear();
      Ajoute_Points(Ma_Liste_Emetteurs, P_Carte);
    }

    internal void SFR_Checked(Map P_Carte)
    {
      List<C_EMETTEUR> Ma_Liste = new List<C_EMETTEUR>();
      Ma_Liste = La_Data.Filter_List_Emetteurs_By_Adm("SFR", Ma_Liste_Emetteurs_Ville);
      foreach (var Un_Emetteur in Ma_Liste) {
        Ma_Liste_Emetteurs.Add(Un_Emetteur);
      }
      Ajoute_Points(Ma_Liste, P_Carte);
    }

    internal void SFR_UnChecked(Map P_Carte)
    {
      Ma_Liste_Emetteurs = La_Data.Clear_Emetteurs_By_Adm("SFR", Ma_Liste_Emetteurs);
      P_Carte.Children.Clear();
      Ajoute_Points(Ma_Liste_Emetteurs, P_Carte);
    }

    internal void Bouygues_Checked(Map P_Carte)
    {
      List<C_EMETTEUR> Ma_Liste = new List<C_EMETTEUR>();
      Ma_Liste = La_Data.Filter_List_Emetteurs_By_Adm("BOUYGUES TELECOM", Ma_Liste_Emetteurs_Ville);
      foreach (var Un_Emetteur in Ma_Liste) {
        Ma_Liste_Emetteurs.Add(Un_Emetteur);
      }
      Ajoute_Points(Ma_Liste, P_Carte);
    }

    internal void Bouygues_UnChecked(Map P_Carte)
    {
      Ma_Liste_Emetteurs = La_Data.Clear_Emetteurs_By_Adm("BOUYGUES TELECOM", Ma_Liste_Emetteurs);
      P_Carte.Children.Clear();
      Ajoute_Points(Ma_Liste_Emetteurs, P_Carte);
    }

    internal void Orange_Checked(Map P_Carte)
    {
      List<C_EMETTEUR> Ma_Liste = new List<C_EMETTEUR>();
      Ma_Liste = La_Data.Filter_List_Emetteurs_By_Adm("ORANGE", Ma_Liste_Emetteurs_Ville);
      foreach (var Un_Emetteur in Ma_Liste) {
        Ma_Liste_Emetteurs.Add(Un_Emetteur);
      }
      Ajoute_Points(Ma_Liste, P_Carte);
    }

    internal void Orange_UnChecked(Map P_Carte)
    {
      Ma_Liste_Emetteurs = La_Data.Clear_Emetteurs_By_Adm("ORANGE", Ma_Liste_Emetteurs);
      P_Carte.Children.Clear();
      Ajoute_Points(Ma_Liste_Emetteurs, P_Carte);
    }

    internal void Vodafone_Checked(Map P_Carte)
    {
      List<C_EMETTEUR> Ma_Liste = new List<C_EMETTEUR>();
      Ma_Liste = La_Data.Filter_List_Emetteurs_By_Adm("PMT/VODAFONE TELECOM", Ma_Liste_Emetteurs_Ville);
      foreach (var Un_Emetteur in Ma_Liste) {
        Ma_Liste_Emetteurs.Add(Un_Emetteur);
      }
      Ajoute_Points(Ma_Liste, P_Carte);
    }

    internal void Vodafone_UnChecked(Map P_Carte)
    {
      Ma_Liste_Emetteurs = La_Data.Clear_Emetteurs_By_Adm("PMT/VODAFONE TELECOM", Ma_Liste_Emetteurs);
      P_Carte.Children.Clear();
      Ajoute_Points(Ma_Liste_Emetteurs, P_Carte);
    }

    internal void Dauphin_Checked(Map P_Carte)
    {
      List<C_EMETTEUR> Ma_Liste = new List<C_EMETTEUR>();
      Ma_Liste = La_Data.Filter_List_Emetteurs_By_Adm("DAUPHIN TELECOM", Ma_Liste_Emetteurs_Ville);
      foreach (var Un_Emetteur in Ma_Liste) {
        Ma_Liste_Emetteurs.Add(Un_Emetteur);
      }
      Ajoute_Points(Ma_Liste, P_Carte);
    }

    internal void Dauphin_UnChecked(Map P_Carte)
    {
      Ma_Liste_Emetteurs = La_Data.Clear_Emetteurs_By_Adm("DAUPHIN TELECOM", Ma_Liste_Emetteurs);
      P_Carte.Children.Clear();
      Ajoute_Points(Ma_Liste_Emetteurs, P_Carte);
    }

    internal void Outremer_Checked(Map P_Carte)
    {
      List<C_EMETTEUR> Ma_Liste = new List<C_EMETTEUR>();
      Ma_Liste = La_Data.Filter_List_Emetteurs_By_Adm("OUTREMER TELECOM", Ma_Liste_Emetteurs_Ville);
      foreach (var Un_Emetteur in Ma_Liste) {
        Ma_Liste_Emetteurs.Add(Un_Emetteur);
      }
      Ajoute_Points(Ma_Liste, P_Carte);
    }

    internal void Outremer_UnChecked(Map P_Carte)
    {
      Ma_Liste_Emetteurs = La_Data.Clear_Emetteurs_By_Adm("OUTREMER TELECOM", Ma_Liste_Emetteurs);
      P_Carte.Children.Clear();
      Ajoute_Points(Ma_Liste_Emetteurs, P_Carte);
    }

    internal void Digicel_Checked(Map P_Carte)
    {
      List<C_EMETTEUR> Ma_Liste = new List<C_EMETTEUR>();
      Ma_Liste = La_Data.Filter_List_Emetteurs_By_Adm("DIGICEL", Ma_Liste_Emetteurs_Ville);
      foreach (var Un_Emetteur in Ma_Liste) {
        Ma_Liste_Emetteurs.Add(Un_Emetteur);
      }
      Ajoute_Points(Ma_Liste, P_Carte);
    }

    internal void Digicel_UnChecked(Map P_Carte)
    {
      Ma_Liste_Emetteurs = La_Data.Clear_Emetteurs_By_Adm("DIGICEL", Ma_Liste_Emetteurs);
      P_Carte.Children.Clear();
      Ajoute_Points(Ma_Liste_Emetteurs, P_Carte);
    }

    internal void Nouv_Caledonie_Checked(Map P_Carte)
    {
      List<C_EMETTEUR> Ma_Liste = new List<C_EMETTEUR>();
      Ma_Liste = La_Data.Filter_List_Emetteurs_By_Adm("Gouv Nelle Calédonie (OPT)", Ma_Liste_Emetteurs_Ville);
      foreach (var Un_Emetteur in Ma_Liste) {
        Ma_Liste_Emetteurs.Add(Un_Emetteur);
      }
      Ajoute_Points(Ma_Liste, P_Carte);
    }

    internal void Nouv_Caledonie_UnChecked(Map P_Carte)
    {
      Ma_Liste_Emetteurs = La_Data.Clear_Emetteurs_By_Adm("Gouv Nelle Calédonie (OPT)", Ma_Liste_Emetteurs);
      P_Carte.Children.Clear();
      Ajoute_Points(Ma_Liste_Emetteurs, P_Carte);
    }

    private void Choix_Couleur_Pin(Pushpin P_Point, C_EMETTEUR P_Emetteur)
    {
      if (P_Emetteur.Adm == "SFR") {
        P_Point.Background = new SolidColorBrush(Colors.OrangeRed);
      }
      if (P_Emetteur.Adm == "ORANGE") {
        P_Point.Background = new SolidColorBrush(Colors.Orange);
      }
      if (P_Emetteur.Adm == "DIGICEL") {
        P_Point.Background = new SolidColorBrush(Colors.White);
      }
      if (P_Emetteur.Adm == "FREE MOBILE") {
        P_Point.Background = new SolidColorBrush(Colors.Red);
      }
      if (P_Emetteur.Adm == "SPM TELECOM") {
        P_Point.Background = new SolidColorBrush(Colors.Blue);
      }
      if (P_Emetteur.Adm == "PMT/VODAFONE") {
        P_Point.Background = new SolidColorBrush(Colors.Gray);
      }
      if (P_Emetteur.Adm == "DAUPHIN TELECOM") {
        P_Point.Background = new SolidColorBrush(Colors.CadetBlue);
      }
      if (P_Emetteur.Adm == "BOUYGUES TELECOM") {
        P_Point.Background = new SolidColorBrush(Colors.AliceBlue);
      }
      if (P_Emetteur.Adm == "OUTREMER TELECOM") {
        P_Point.Background = new SolidColorBrush(Colors.Violet);
      }
      if (P_Emetteur.Adm == "Gouv Nelle Calédonie (OPT)") {
        P_Point.Background = new SolidColorBrush(Colors.Black);
      }
    }

    private void Ajoute_Points(List<C_EMETTEUR> P_Liste_Emetteurs, Map P_Carte)
    {
      for (int Index = 0; Index < P_Liste_Emetteurs.Count; Index++) {
        Pushpin Mon_Point = new Pushpin();
        Choix_Couleur_Pin(Mon_Point, P_Liste_Emetteurs[Index]);
        Mon_Point.Location = new Location(P_Liste_Emetteurs[Index].XY[0], P_Liste_Emetteurs[Index].XY[1]);
        P_Carte.Children.Add(Mon_Point);
      }
    }
  }
}