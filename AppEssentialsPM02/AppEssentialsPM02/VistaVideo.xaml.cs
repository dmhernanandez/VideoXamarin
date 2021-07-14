using MediaManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEssentialsPM02
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaVideo : ContentPage
    {
        String url = null;
        public VistaVideo()
        {
            InitializeComponent();
            url = ruta.Text;
        }



        void BtnPlayVideo_Clicked(object sender, System.EventArgs e)
        {
            CrossMediaManager.Current.Play();
        }

        void BtnStopVideo_Clicked(object sender, System.EventArgs e)
        {
            CrossMediaManager.Current.Stop();
        }
    }
}