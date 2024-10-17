using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPF_REGIONS_V3.COORDINATION
{
  internal class C_NOTIFIABLE : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;
    public void Signale_Changement([CallerMemberName] string P_Nom = null)
    {
      if (PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(P_Nom));
    }
  }
}