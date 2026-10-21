using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data;
using Microsoft.Data.SqlClient;

namespace QLNhaHang.Classes
{
    public class DataProcesser
    {
        public static readonly string strConnect = @"Data Source =Loc\SQLEXPRESS; Database =QuanlyNhaHang;Integrated Security =True;TrustServercertificate=True";
        SqlConnection sqlConnect = null;
        // mo ket noi
        private void KetNoiCSDL()
        {
            sqlConnect = new SqlConnection(strConnect);
            if (sqlConnect.State != ConnectionState.Open)
            {
                sqlConnect.Open();
            }

        }

        // dong ket noi
        private void DongCSDL()
        {
            if (sqlConnect.State != ConnectionState.Closed)
            {
                sqlConnect.Close();
            }
            sqlConnect.Dispose();
        }
        // lay 1 bang tu csdl
        public DataTable DocBang(string sql)
        {
            DataTable dulieu = new DataTable();
            KetNoiCSDL();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, strConnect);
            adapter.Fill(dulieu);
            DongCSDL();
            return dulieu;

        }
        // ham thuc hien insert/update/delete- cap nhap du lieu
        public int CapNhapDuLieu(string sql)
        {
            KetNoiCSDL();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandText = sql;
            int result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                return 1;
            }
            else return 0;

        }
    }
}
