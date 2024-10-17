using LIB_REGION;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_REGIONS_V3.COORDINATION;

namespace WPF_REGIONS_V3
{
  /// <summary>
  /// Logique d'interaction pour MainWindow.xaml
  /// </summary>
  public partial class C_CADRE : Window
  {
    const string Cle_Map_Bing = "Ali9Y1IoLiP-YYE-y9MLphRgYYrQzTQdGFbjf035Vk8JCIz9RDLPsS-D7R6pN5s4";
    C_COORDINATION La_Coordination;
    public C_CADRE()
    {
      try {
        La_Coordination = new C_COORDINATION();
        InitializeComponent();

        La_Carte.CredentialsProvider = new ApplicationIdCredentialsProvider(Cle_Map_Bing);
        La_Carte.Mode = new AerialMode(true);
        La_Carte.ZoomLevel = 6;

        DataContext = La_Coordination;
      }
      catch (Exception P_Erreur) {
        MessageBox.Show(P_Erreur.Message, "ERREUR !", MessageBoxButton.OK, MessageBoxImage.Error);
        Close();
      }
    }

    private void LSTB_Regions_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      La_Coordination.Charge_Liste_Departements_Pour_Region_Selectionne();
    }

    private void LSTB_Departements_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      La_Coordination.Charge_Liste_Ville_Pour_Departement_Selectionne();
    }

    private void LSTB_Villes_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      Active_Bouttons();
      La_Carte = La_Coordination.Centre_Carte_Sur_Ville(La_Carte);
    }

    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      La_Coordination.Centre_Carte_Sur_Emetteur(La_Carte);
    }

    private void CKB_Free_Checked(object sender, RoutedEventArgs e)
    {
      if (LSTB_Villes.SelectedItem != null) {
        La_Coordination.Free_Cheked(La_Carte);
      }
    }

    private void CKB_Free_Unchecked(object sender, RoutedEventArgs e)
    {
      La_Coordination.Free_UnCheked(La_Carte);
    }

    private void CKB_SFR_Checked(object sender, RoutedEventArgs e)
    {
      if (LSTB_Villes.SelectedItem != null) {
        La_Coordination.SFR_Checked(La_Carte);
      }
    }

    private void CKB_SFR_Unchecked(object sender, RoutedEventArgs e)
    {
      La_Coordination.SFR_UnChecked(La_Carte);
    }

    private void CKB_Bouygues_Checked(object sender, RoutedEventArgs e)
    {
      if (LSTB_Villes.SelectedItem != null) {
        La_Coordination.Bouygues_Checked(La_Carte);
      }
    }

    private void CKB_Bouygues_Unchecked(object sender, RoutedEventArgs e)
    {
      La_Coordination.Bouygues_UnChecked(La_Carte);
    }

    private void CKB_Orange_Checked(object sender, RoutedEventArgs e)
    {
      if (LSTB_Villes.SelectedItem != null) {
        La_Coordination.Orange_Checked(La_Carte);
      }
    }

    private void CKB_Orange_Unchecked(object sender, RoutedEventArgs e)
    {
      La_Coordination.Orange_UnChecked(La_Carte);
    }

    private void CKB_Vodafone_Checked(object sender, RoutedEventArgs e)
    {
      if (LSTB_Villes.SelectedItem != null) {
        La_Coordination.Vodafone_Checked(La_Carte);
      }
    }

    private void CKB_Vodafone_Unchecked(object sender, RoutedEventArgs e)
    {
      La_Coordination.Vodafone_UnChecked(La_Carte);
    }

    private void CKB_Dauphin_Checked(object sender, RoutedEventArgs e)
    {
      if (LSTB_Villes.SelectedItem != null) {
        La_Coordination.Dauphin_Checked(La_Carte);
      }
    }

    private void CKB_Dauphin_Unchecked(object sender, RoutedEventArgs e)
    {
      La_Coordination.Dauphin_UnChecked(La_Carte);
    }

    private void CKB_Outremer_Checked(object sender, RoutedEventArgs e)
    {
      if (LSTB_Villes.SelectedItem != null) {
        La_Coordination.Outremer_Checked(La_Carte);
      }
    }

    private void CKB_Outremer_Unchecked(object sender, RoutedEventArgs e)
    {
      La_Coordination.Outremer_UnChecked(La_Carte);
    }

    private void CKB_Digicel_Checked(object sender, RoutedEventArgs e)
    {
      if (LSTB_Villes.SelectedItem != null) {
        La_Coordination.Digicel_Checked(La_Carte);
      }
    }

    private void CKB_Digicel_Unchecked(object sender, RoutedEventArgs e)
    {
      La_Coordination.Digicel_UnChecked(La_Carte);
    }

    private void CKB_Nouv_Caledonie_Checked(object sender, RoutedEventArgs e)
    {
      if (LSTB_Villes.SelectedItem != null) {
        La_Coordination.Nouv_Caledonie_Checked(La_Carte);
      }
    }

    private void CKB_Nouv_Caledonie_Unchecked(object sender, RoutedEventArgs e)
    {
      La_Coordination.Nouv_Caledonie_UnChecked(La_Carte);
    }

    private void CKB_All_Checked(object sender, RoutedEventArgs e)
    {
      if (LSTB_Villes.SelectedItem != null) {
        CKB_Free.IsChecked = true;
        CKB_SFR.IsChecked = true;
        CKB_Orange.IsChecked = true;
        CKB_Bouygues.IsChecked = true;
        CKB_Outremer.IsChecked = true;
        CKB_Dauphin.IsChecked = true;
        CKB_Digicel.IsChecked = true;
        CKB_SPM.IsChecked = true;
        CKB_Vodafone.IsChecked = true;
        CKB_Nouv_Caledonie.IsChecked = true;
      }
    }

    private void CKB_All_Unchecked(object sender, RoutedEventArgs e)
    {
      CKB_Free.IsChecked = false;
      CKB_SFR.IsChecked = false;
      CKB_Orange.IsChecked = false;
      CKB_Bouygues.IsChecked = false;
      CKB_Outremer.IsChecked = false;
      CKB_Dauphin.IsChecked = false;
      CKB_Digicel.IsChecked = false;
      CKB_SPM.IsChecked = false;
      CKB_Vodafone.IsChecked = false;
      CKB_Nouv_Caledonie.IsChecked = false;
    }

    private void CKB_Mode_Route_Click(object sender, RoutedEventArgs e)
    {
      if ((sender as CheckBox).IsChecked == true) {
        La_Carte.Mode = new RoadMode();
      } else {
        La_Carte.Mode = new AerialMode(true);
      }
    }


    private void Active_Bouttons()
    {
      CKB_All.IsChecked = true;
      CKB_Free.IsEnabled = true;
      CKB_SFR.IsEnabled = true;
      CKB_Orange.IsEnabled = true;
      CKB_Bouygues.IsEnabled = true;
      CKB_Outremer.IsEnabled = true;
      CKB_Dauphin.IsEnabled = true;
      CKB_Digicel.IsEnabled = true;
      CKB_SPM.IsEnabled = true;
      CKB_Vodafone.IsEnabled = true;
      CKB_Nouv_Caledonie.IsEnabled = true;
      CKB_All.IsEnabled = true;
    }

    private void Desactive_Bouttons()
    {
      CKB_All.IsChecked = false;
      CKB_Free.IsEnabled = false;
      CKB_SFR.IsEnabled = false;
      CKB_Orange.IsEnabled = false;
      CKB_Bouygues.IsEnabled = false;
      CKB_Outremer.IsEnabled = false;
      CKB_Dauphin.IsEnabled = false;
      CKB_Digicel.IsEnabled = false;
      CKB_SPM.IsEnabled = false;
      CKB_Vodafone.IsEnabled = false;
      CKB_Nouv_Caledonie.IsEnabled = false;
      CKB_All.IsEnabled = false;
    }

    //private void CKB_Recherche_Intelligente_Checked(object sender, RoutedEventArgs e)
    //{
    //  LSTB_Departements.IsEnabled = false;
    //  LSTB_Regions.IsEnabled = false;
    //  LSTB_Villes.IsEnabled = false;

    //  LSTB_Departements.Visibility = Visibility.Hidden;
    //  LSTB_Regions.Visibility = Visibility.Hidden;
    //  LSTB_Villes.Visibility = Visibility.Hidden;
    //}

    //private void CKB_Recherche_Intelligente_Unchecked(object sender, RoutedEventArgs e)
    //{
    //  LSTB_Departements.IsEnabled = true;
    //  LSTB_Regions.IsEnabled = true;
    //  LSTB_Villes.IsEnabled = true;

    //  LSTB_Departements.Visibility = Visibility.Visible;
    //  LSTB_Regions.Visibility = Visibility.Visible;
    //  LSTB_Villes.Visibility = Visibility.Visible;
    //}
  }
}
