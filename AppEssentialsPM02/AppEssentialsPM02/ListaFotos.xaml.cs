using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using AppEssentialsPM02;
using System.Globalization;
using Plugin.Media.Abstractions;
using System.Windows.Input;
using System.Diagnostics;

namespace AppEssentialsPM02
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaFotos : ContentPage
    {

        private int ItemID;
        private string ItemRoute;
        private string ItemName;
        private string ItemDesc;
        public List<pictures> pictures { get; set; }
        public ICommand ReproducirCommand { protected set; get; }

        public class ImageFileToImageSourceConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var path = (string)value;
                return ImageSource.FromFile(path);
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
        

        public ListaFotos()
        {
            ReproducirCommand = new Command<pictures>(async (key) =>
            {
                pictures SelectPictures = key as pictures;

                ItemID = SelectPictures.id;
                ItemRoute = SelectPictures.ImageRoute;
                ItemName = SelectPictures.Name;
                ItemDesc = SelectPictures.Desc;

                String var_id = Convert.ToString(ItemID);

                seleccion.Text = ItemName;
                Debug.WriteLine("----------------Selecciona los ITEM-------------------");
                Debug.WriteLine(ItemName);

                var Datos_VerVideo = new pictures
                {
                    id = ItemID,
                    ImageRoute = ItemRoute,
                    Name = ItemName,
                    Desc = ItemDesc
                };


                var inf = new VistaVideo();
                Debug.WriteLine("Var Info");
                inf.BindingContext = Datos_VerVideo;
                Debug.WriteLine("Ya se Envio el Binding");
                await Navigation.PushAsync(inf);
                Debug.WriteLine("abre la ventana");

                //await DisplayAlert("info", SelectPictures.id.ToString(), "OK");
            });
            
            BindingContext = this;
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB);
            conexion.CreateTable<pictures>();
            var listafotos = conexion.Table<pictures>().ToList();
            ListaFotosBD.ItemsSource = listafotos;
            conexion.Close();



            //new MediaFile(file.Path, () => file.OpenStreamForReadAsync().Result, albumPath: null);

            //pictures pic = new pictures();

            /*carga.Text = pic.ImageRoute;*/

            //fotodb.Source = pic.ImageRoute;


        }

        private async void ListaFotosBD_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var almacenar = e.SelectedItem as pictures;

            ItemID = almacenar.id;
            ItemRoute = almacenar.ImageRoute;
            ItemName = almacenar.Name;
            ItemDesc = almacenar.Desc;

            String var_id = Convert.ToString(ItemID);

            seleccion.Text = ItemName;

            var Datos_VerVideo = new pictures
            {
                id = ItemID,
                ImageRoute = ItemRoute,
                Name = ItemName,
                Desc = ItemDesc
            };

            var inf = new VistaVideo();
            inf.BindingContext = Datos_VerVideo;
            await Navigation.PushAsync(inf);

        }

        //private async void SwipeItem_Invoked(object sender, EventArgs e)
        //{

        //}

        private void SwipeItem_Invoked_1(object sender, EventArgs e)
        {

        }
    }
}