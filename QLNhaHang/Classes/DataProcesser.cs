using System.Data;
using Microsoft.Data.SqlClient;

namespace QLNhaHang.Classes
{
    public class DataProcesser
    {
        internal static readonly string strConnect = @"Data Source =Loc\SQLEXPRESS; Database =QuanlyNhaHang;Integrated Security =True;TrustServercertificate=True";
        SqlConnection sqlConnect = null;
        // mo ket noi
        public SqlConnection TaoKetNoi()
        {
            return new SqlConnection(strConnect);
        }

        private void KetNoiCSDL()
        {
            sqlConnect ??= new SqlConnection(strConnect);
            if (sqlConnect.State != ConnectionState.Open)
            {
                sqlConnect.Open();
            }
        }

        // Dong ket noi
        private void DongCSDL()
        {
            sqlConnect?.Dispose();
            sqlConnect = null;
        }

        // Lay mot bang tu CSDL
        public DataTable DocBang(string sql)
        {
            try
            {
                KetNoiCSDL();
                DataTable dulieu = new DataTable();
                using SqlDataAdapter adapter = new SqlDataAdapter(sql, sqlConnect);
                adapter.Fill(dulieu);
                return dulieu;
            }
            finally
            {
                DongCSDL();
            }
        }

        // Thuc hien INSERT/UPDATE/DELETE
        public int CapNhapDuLieu(string sql)
        {
            try
            {
                KetNoiCSDL();
                using SqlCommand sqlCommand = new SqlCommand(sql, sqlConnect);
                int result = sqlCommand.ExecuteNonQuery();
                return result > 0 ? 1 : 0;
            }
            finally
            {
                DongCSDL();
            }
        }
    }
}
