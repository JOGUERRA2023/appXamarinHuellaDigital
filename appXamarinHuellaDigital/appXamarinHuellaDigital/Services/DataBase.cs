using appXamarinHuellaDigital.Interface;
using appXamarinHuellaDigital.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace appXamarinHuellaDigital.Services
{
    public class DataBase
    {
        private SQLiteConnection _BDConexion;
        public DataBase()
        {
            _BDConexion = DependencyService.Get<ISQLiteBD>().GetConnectionBD();
            _BDConexion.CreateTable<FingerprintData>();
        }
      
        public List<FingerprintData> GetListarMenu()
        {
            return _BDConexion.Query<FingerprintData>("select * from FingerprintData");
        }
        public List<FingerprintData> GetFingerprintAsync(string userName)
        {
            return  _BDConexion.Query<FingerprintData>("select * from FingerprintData Where UserName='"+userName+"'");
        }
        public int SaveFingerprintAsync(FingerprintData fingerprint)
        {
            if (fingerprint.Id != 0)
            {
                return _BDConexion.Insert(fingerprint);
            }
            else
            {
                return _BDConexion.Insert(fingerprint);
            }
        }
    }
}
