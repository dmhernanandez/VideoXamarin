using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using Xamarin.Essentials;
using SQLite;
using System.IO;

namespace AppEssentialsPM02
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FotoPage : ContentPage
    {


        public FotoPage()
        {
            InitializeComponent();
        }



        private async void toma_Clicked(object sender, EventArgs e)
        {
            //var tomarfoto = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions());
            var tomarfoto = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
            {
                Directory = "MyApp"
            });

            await DisplayAlert("Ubicacion Archivo", tomarfoto.Path, "Ok");

            string path = tomarfoto.Path;

            String Video_Nombre = null;

            while (Video_Nombre == null || Video_Nombre == "")
            {
                Video_Nombre = await DisplayPromptAsync("", "Por Favor añada un nombre al video");
            }

            String path2 = "/storage/emulated/0/Android/data/com.companyname.appessentialspm02/files/Movies/MyApp/" + Video_Nombre + ".mp4";

            File.Move(path, path2);

            String Video_Desc = null;

            while (Video_Desc == null || Video_Desc == "")
            {
                Video_Desc = await DisplayPromptAsync("", "Por Favor añada una descripcion al video");
            }

            #region desastres de carlos


            var lugar = new pictures
            {
                ImageRoute = path2,
                Name = Video_Nombre,
                Desc = Video_Desc

            };
            App.InstanciaBD.InsertPicture(lugar).Wait();
            #endregion




            /*var compartirFoto = tomarfoto.Path;
            await Share.RequestAsync(new ShareFileRequest
            {
                Title = "Foto",
                File = new ShareFile(compartirFoto)
            });*/
        }

        private async void Ver_Lista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaFotos());
        }

        private void Guardar_Clicked(object sender, EventArgs e)
        {

        }
    }
}