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

        public VistaVideo()
        {
            InitializeComponent();
        }

        void BtnPlayVideo_Clicked(object sender, System.EventArgs e)
        {
            if (CrossMediaManager.Current.IsPlaying())
            {
                BtnPlay.ImageSource = "play.ico";
                BtnPlay.Text = "Play";
                CrossMediaManager.Current.Pause();

            }
            else
            {
                BtnPlay.Text = "Pause";
                BtnPlay.ImageSource = "pause.ico";
                CrossMediaManager.Current.Play();
            }
           
        }

        void BtnStopVideo_Clicked(object sender, System.EventArgs e)
        {
            CrossMediaManager.Current.Stop();
        }
        protected override bool OnBackButtonPressed()
        {
            ;
            DisplayAlert("hoa", "hey", "hola");
            return base.OnBackButtonPressed();

        }
    }
   
}