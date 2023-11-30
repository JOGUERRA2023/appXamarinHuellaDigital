using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace appXamarinHuellaDigital.Interface
{
    public interface ISQLiteBD
    {
        SQLiteConnection GetConnectionBD();
    }
}
