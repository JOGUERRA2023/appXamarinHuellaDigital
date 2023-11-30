using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace appXamarinHuellaDigital.Models
{
    public class FingerprintData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] FingerprintTemplate { get; set; }
    }
}
