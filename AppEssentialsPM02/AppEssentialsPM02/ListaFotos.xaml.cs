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
        public ICommand DeleteCommand { protected set; get; }

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
                pictures SelectedPictures = key as pictures;

                var inf = new VistaVideo();
                inf.BindingContext = SelectedPictures;
                await Navigation.PushAsync(inf);
                //await DisplayAlert("info", SelectPictures.id.ToString(), "OK");
            });

            DeleteCommand = new Command<pictures>(async (key) =>
            {
                pictures SelectPictures = key as pictures;
                App.InstanciaBD.DeletePicture(SelectPictures);
            });
        

        BindingContext = this;
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var listafotos = await App.InstanciaBD.GetPictures();
            ListaFotosBD.ItemsSource = listafotos;


        }

        //private async void SwipeItem_Invoked(object sender, EventArgs e)
        //{

        //}

        private void SwipeItem_Invoked_1(object sender, EventArgs e)
        {

        }
    }
}