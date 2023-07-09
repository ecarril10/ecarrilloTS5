using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ecarrilloTS5
{
    public partial class MainPage : ContentPage
    {
        private String Url = "http://192.168.1.2/ws_qrCONNECTX/post.php";
        private HttpClient cliente = new HttpClient();
        private ObservableCollection<Equipo> post;
        public MainPage()
        {
            InitializeComponent();
            obtenerDatos();


        }

        private async void obtenerDatos()
        {
            var contenido = await cliente.GetStringAsync(Url);
            List<Equipo> listaPost = JsonConvert.DeserializeObject<List<Equipo>>(contenido);
            post = new ObservableCollection<Equipo>(listaPost);
            milista.ItemsSource = post;

        }
       
    }
}
