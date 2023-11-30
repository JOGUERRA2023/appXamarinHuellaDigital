using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using appXamarinHuellaDigital.Interface;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(appXamarinHuellaDigital.Droid.SQLite.CreateBD))]
namespace appXamarinHuellaDigital.Droid.SQLite
{
    public class CreateBD : ISQLiteBD
    {
        public SQLiteConnection GetConnectionBD()
        {
            var filename = "DBIDENTIDAD.db3";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), filename);
            var connection = new SQLiteConnection(path);
            return connection;
        }
    }
}