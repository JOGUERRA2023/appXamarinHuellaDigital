using appXamarinHuellaDigital.Cache;
using Plugin.Fingerprint.Abstractions;
using Plugin.Fingerprint;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Xamarin.Forms;

namespace appXamarinHuellaDigital.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private bool isPassword = false;
        
        private string btnimagePass = "show.png";
        public string btnImagePass
        {
            get { return btnimagePass; }
            set
            {
                btnimagePass = value;
                OnPropertyChanged();
            }
        }

        private string Claveingresada = "Contraseña";
        public string ClaveIngresada
        {
            get { return Claveingresada; }
            set
            {
                Claveingresada = value;
                OnPropertyChanged();
            }
        }
        #region Texto Claves
        private string btn1="";
        public string Btn1
        {
            get { return btn1; }
            set { btn1 = value; OnPropertyChanged(); }
        }
        private string btn2;
        public string Btn2
        {
            get { return btn2; }
            set { btn2 = value; OnPropertyChanged(); }
        }
        private string btn3;
        public string Btn3
        {
            get { return btn3; }
            set { btn3 = value; OnPropertyChanged(); }
        }
        private string btn4;
        public string Btn4
        {
            get { return btn4; }
            set { btn4 = value; OnPropertyChanged(); }
        }
        private string btn5;
        public string Btn5
        {
            get { return btn5; }
            set { btn5 = value; OnPropertyChanged(); }
        }
        private string btn6;
        public string Btn6
        {
            get { return btn6; }
            set { btn6 = value; OnPropertyChanged(); }
        }
        private string btn7;
        public string Btn7
        {
            get { return btn7; }
            set { btn7 = value; OnPropertyChanged(); }
        }
        private string btn8;
        public string Btn8
        {
            get { return btn8; }
            set { btn8 = value; OnPropertyChanged(); }
        }
        private string btn9;
        public string Btn9
        {
            get { return btn9; }
            set { btn9 = value; OnPropertyChanged(); }
        }
        private string btn0;
        public string Btn0
        {
            get { return btn0; }
            set { btn0 = value; OnPropertyChanged(); }
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public LoginViewModel()
        {
            // Crear una lista de números del 0 al 9
            List<int> numeros = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Utilizar una instancia de Random para mezclar la lista
            Random random = new Random();
            for (int i = numeros.Count - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                int temp = numeros[i];
                numeros[i] = numeros[j];
                numeros[j] = temp;
            }
            Btn1= numeros[0].ToString();
            Btn2 = numeros[1].ToString();
            Btn3 = numeros[2].ToString();
            Btn4 = numeros[3].ToString();
            Btn5 = numeros[4].ToString();
            Btn6 = numeros[5].ToString();
            Btn7 = numeros[6].ToString();
            Btn8 = numeros[7].ToString();
            Btn9 = numeros[8].ToString();
            Btn0 = numeros[9].ToString();
        }


        public ICommand GetVerPassword => new Command(VerPassword);
        public ICommand GetElimarPassword => new Command(EliminarClave);
        public ICommand FingerprintCommand => new Command(GetFingerprintCommand);

        public void VerPassword()
        {
            if (ClaveIngresada != "Contraseña")
            {
                isPassword = !isPassword;
                ClaveIngresada = Constantes.Clave;
                if (isPassword == true)
                {
                    ClaveIngresada = _TempCalve;
                    btnImagePass = "hide.png";
                }
                else
                {
                    ClaveIngresada = new string('*', _TempCalve.Length);
                    btnImagePass = "show.png";
                }
            }
                

        }
        public void EliminarClave()
        {
            // Verifica que la cadena no esté vacía antes de intentar eliminar el último carácter
            if (!string.IsNullOrEmpty(ClaveIngresada))
            {
                // Borra el último carácter
                if(ClaveIngresada != "Contraseña")
                {
                    ClaveIngresada = ClaveIngresada.Remove(ClaveIngresada.Length - 1);
                    _TempCalve = _TempCalve.Remove(_TempCalve.Length - 1);
                    Constantes.Clave = ClaveIngresada;
                    if (ClaveIngresada == "")
                    {
                        _TempCalve = "";
                        ClaveIngresada = "Contraseña";
                        btnImagePass = "show.png";
                    }
                }
               
            }
            else
            {
                ClaveIngresada = "Contraseña";
                btnImagePass = "show.png";
            }
        }

        #region Asignar Password
        public ICommand Getbtn1 => new Command(btn1_Clicked);
        public ICommand Getbtn2 => new Command(btn2_Clicked);
        public ICommand Getbtn3 => new Command(btn3_Clicked);
        public ICommand Getbtn4 => new Command(btn4_Clicked);
        public ICommand Getbtn5 => new Command(btn5_Clicked);
        public ICommand Getbtn6 => new Command(btn6_Clicked);
        public ICommand Getbtn7 => new Command(btn7_Clicked);
        public ICommand Getbtn8 => new Command(btn8_Clicked);
        public ICommand Getbtn9 => new Command(btn9_Clicked);
        public ICommand Getbtn0 => new Command(btn0_Clicked);

        string _TempCalve="";
        private void btn1_Clicked()
        {
            if (ClaveIngresada == "Contraseña")
                Claveingresada = "";
            _TempCalve = _TempCalve + Btn1;
            if (btnImagePass == "show.png")
            {
                ClaveIngresada = new string('*', _TempCalve.Length);
            }
            else
            {
                ClaveIngresada = ClaveIngresada + Btn1;
            }
            
            Constantes.Clave = ClaveIngresada;
        }

        private void btn2_Clicked()
        {
            if (ClaveIngresada == "Contraseña")
                Claveingresada = "";
            _TempCalve = _TempCalve + Btn2;
            if (btnImagePass == "show.png")
            {
                ClaveIngresada = new string('*', _TempCalve.Length);
            }
            else
            {
                ClaveIngresada = ClaveIngresada + Btn2;
            }
        }

        private void btn3_Clicked()
        {
            if (ClaveIngresada == "Contraseña")
                Claveingresada = "";
            _TempCalve = _TempCalve + Btn3;
            if (btnImagePass == "show.png")
            {
                ClaveIngresada = new string('*', _TempCalve.Length);
            }
            else
            {
                ClaveIngresada = ClaveIngresada + Btn3;
            }
        }

        private void btn4_Clicked()
        {
            if (ClaveIngresada == "Contraseña")
                Claveingresada = "";
            _TempCalve = _TempCalve + Btn4;
            if (btnImagePass == "show.png")
            {
                ClaveIngresada = new string('*', _TempCalve.Length);
            }
            else
            {
                ClaveIngresada = ClaveIngresada + Btn4;
            }
        }

        private void btn5_Clicked()
        {
            if (ClaveIngresada == "Contraseña")
                Claveingresada = "";
            _TempCalve = _TempCalve + Btn5;
            if (btnImagePass == "show.png")
            {
                ClaveIngresada = new string('*', _TempCalve.Length);
            }
            else
            {
                ClaveIngresada = ClaveIngresada + Btn5;
            }
        }

        private void btn6_Clicked()
        {
            if (ClaveIngresada == "Contraseña")
                Claveingresada = "";
            _TempCalve = _TempCalve + Btn6;
            if (btnImagePass == "show.png")
            {
                ClaveIngresada = new string('*', _TempCalve.Length);
            }
            else
            {
                ClaveIngresada = ClaveIngresada + Btn6;
            }
        }

        private void btn7_Clicked()
        {
            if (ClaveIngresada == "Contraseña")
                Claveingresada = "";
            _TempCalve = _TempCalve + Btn7;
            if (btnImagePass == "show.png")
            {
                ClaveIngresada = new string('*', _TempCalve.Length);
            }
            else
            {
                ClaveIngresada = ClaveIngresada + Btn7;
            }
        }

        private void btn8_Clicked()
        {
            if (ClaveIngresada == "Contraseña")
                Claveingresada = "";
            _TempCalve = _TempCalve + Btn8;
            if (btnImagePass == "show.png")
            {
                ClaveIngresada = new string('*', _TempCalve.Length);
            }
            else
            {
                ClaveIngresada = ClaveIngresada + Btn8;
            }
        }

        private void btn9_Clicked()
        {
            if (ClaveIngresada == "Contraseña")
                Claveingresada = "";
            _TempCalve = _TempCalve + Btn9;
            if (btnImagePass == "show.png")
            {
                ClaveIngresada = new string('*', _TempCalve.Length);
            }
            else
            {
                ClaveIngresada = ClaveIngresada + Btn9;
            }
        }

        private void btn0_Clicked()
        {
            if (ClaveIngresada == "Contraseña")
                Claveingresada = "";
            _TempCalve = _TempCalve + Btn0;
            if (btnImagePass == "show.png")
            {
                ClaveIngresada = new string('*', _TempCalve.Length);
            }
            else
            {
                ClaveIngresada = ClaveIngresada + Btn0;
            }
        }
        #endregion
        public async void GetFingerprintCommand()
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
    }
}
