using appXamarinHuellaDigital.Cache;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace appXamarinHuellaDigital.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserAdd : ContentPage
    {
       
        public UserAdd()
        {
            InitializeComponent();
           
        }
       

        private async void btnHuella_Clicked(object sender, EventArgs e)
        {
            var result = await CrossFingerprint.Current.IsAvailableAsync(true);

            if (result)
            {
                var auth = await CrossFingerprint.Current.AuthenticateAsync(new AuthenticationRequestConfiguration("Autenticación por huella digital", "Utilice su huella digital para la autenticación"), new CancellationTokenSource(TimeSpan.FromSeconds(10)).Token);

                if (auth.Authenticated)
                {
                    //Fingerprint validation passed, you can proceed to the app
                     App.Current.MainPage = new MainPage();
                }
            }
        }

      
        private async void PasswordTxt_Clicked(object sender, EventArgs e)
        {
            stClaves.Opacity = 0; // Inicializa la opacidad en 0 al inicio
            stClaves.IsVisible = true;
            await Task.WhenAll(
            stClaves.FadeTo(0.2, 1000) // Duración de 10 segundos
        );

            await Task.WhenAll(
                stClaves.FadeTo(1, 1000) // Duración de 10 segundos
            );
            FingerprintView.IsVisible = false;
        }

        private void txtUsuario_Focused(object sender, FocusEventArgs e)
        {
            stClaves.IsVisible = false;
            FingerprintView.IsVisible = true;
        }

        private void txtUsuario_Unfocused(object sender, FocusEventArgs e)
        {

        }
        private async void AnimateVisibilityAsync(bool isVisible)
        {
            var stackLayout = stClaves;
            if (stackLayout != null)
            {
                double targetOpacity = isVisible ? 1 : 0;
                uint duration = 500; // Duración de la animación en milisegundos
                await stackLayout.FadeTo(targetOpacity, duration);
            }
        }
    }
 }
