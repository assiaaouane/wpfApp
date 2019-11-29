using MetroAPILibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1.ViewModel
{
    public class ArretViewModel : INotifyPropertyChanged
    {

        public string lon;
        public string lat;
        ICommand button;

        public ICommand Button
        {
            get;
            set;
        }




        public ArretViewModel()
        {
            this.Lon = "5.71025";
            this.Lat = "45.17794";
            this.Distance = "800";
            Button = new RelayCommand(LoadArrets);
        }

        public Dictionary<String, Arret> arrets;
        public Dictionary<String, Arret> Arrets
        {
            get { return arrets; }
            set
            {
                if (arrets != value)
                {
                    arrets = value;
                    OnPropertyChanged(nameof(arrets));
                }
            }

        }


        public string Lon {
            get { return lon; }
            set {
                lon = value;
                OnPropertyChanged("Lon");
            } }
       

        public string Lat
        {
            get { return lat; }
            set
            {
                lat = value;
                OnPropertyChanged("Lat");
            }
        }
      


        public string Distance
        {
            get { return distance; }
            set
            {
                distance = value;
                OnPropertyChanged("Distance");
            }
        }
        public string distance;
        public string Url (string latitude,string longitude,string distance)
        {
            string adresse = "https://data.metromobilite.fr/api/linesNear/json?x="+latitude+"&y="+longitude+"&dist="+distance+"&details=true";
            return adresse;
        }


        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }


        public void LoadArrets()
        {
          

            MetroAPI library = new MetroAPI();
            String Myurl = Url(Lon, Lat, Distance);
            Dictionary<String, Arret> DicoJsonApi = library.DicoArrets(Myurl);

            Arrets = DicoJsonApi;
       }


       

    }
     
}
