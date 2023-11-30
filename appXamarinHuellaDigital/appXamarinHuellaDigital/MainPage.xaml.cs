using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace appXamarinHuellaDigital
{
    public partial class MainPage : ContentPage
    {
        public Command DrawCompleted { get; set; }
        public MainPage()
        {
            InitializeComponent();
            DrawCompleted = new Command(() =>
            {
                var stream = drawingView.GetImageStream(300, 300);
                theImage.Source = ImageSource.FromStream(() => stream);
            });

            BindingContext = this;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            drawingView.Lines.Clear();
        }
    }
}
