using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace Ebelemece_2
{
    class veriler
    {
        public static void arama()
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0;Data Source=Save.mdb");
            baglanti.Open();
            string sql = "Select * from levels";
            OleDbCommand komut = new OleDbCommand(sql, baglanti);
            OleDbDataReader reader = komut.ExecuteReader();
            reader.Read();
            Game1.veritabani = Convert.ToInt32(reader.GetValue(1));
            baglanti.Close();
        }

        public static void guncellestirme()
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0;Data Source=Save.mdb");
            baglanti.Open();
            string sql = "Update levels set [level] = '" + Game1.veritabani + "'";
            OleDbCommand komut = new OleDbCommand(sql, baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}
