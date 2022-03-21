using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using NasabahAPI.Models;

namespace NasabahAPI.Provider
{
    public class NasabahProvider
    {
        private SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["Nasabah"].ToString());
        }
        public List<DataNasabahViewModel> GetAllData() {
            List<DataNasabahViewModel> listdataNasabah = new List<DataNasabahViewModel>();

            try
            {
                var con = GetConnection();
                con.Open();

                var cmd = new SqlCommand("[dbo].[GetDataNasabah]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@actionType", "ALL");

                cmd.CommandTimeout = 7200;
                var sd = new SqlDataAdapter(cmd);
                var dt = new DataTable();

                sd.Fill(dt);
                con.Close();

                if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        DataNasabahViewModel dtNas = new DataNasabahViewModel();
                        dtNas.ID = Convert.ToInt32(dr["ID"]);
                        dtNas.NoKTP = dr["NoKTP"].ToString();
                        dtNas.Nama = dr["Nama"].ToString();
                        dtNas.Alamat = dr["Alamat"].ToString();
                        dtNas.TempatLahir = dr["TempatLahir"].ToString();
                        dtNas.TanggalLahir = Convert.ToDateTime(dr["TanggalLahir"]);
                        dtNas.NoHP = dr["NoHP"].ToString();

                        listdataNasabah.Add(dtNas);
                    }
                }

            }
            catch (Exception err)
            {
                throw err;
            }

            return listdataNasabah;
        }
        public List<DataNasabahViewModel> GetDataByKTP(string NoKTP)
        {
            List<DataNasabahViewModel> listdataNasabah = new List<DataNasabahViewModel>();

            try
            {
                var con = GetConnection();
                con.Open();

                var cmd = new SqlCommand("[dbo].[GetDataNasabah]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@actionType", "ByKTP");
                cmd.Parameters.AddWithValue("@noKTP", NoKTP);

                cmd.CommandTimeout = 7200;
                var sd = new SqlDataAdapter(cmd);
                var dt = new DataTable();

                sd.Fill(dt);
                con.Close();

                if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        DataNasabahViewModel dtNas = new DataNasabahViewModel();
                        dtNas.ID = Convert.ToInt32(dr["ID"]);
                        dtNas.NoKTP = dr["NoKTP"].ToString();
                        dtNas.Nama = dr["Nama"].ToString();
                        dtNas.TempatLahir = dr["TempatLahir"].ToString();
                        dtNas.TanggalLahir = Convert.ToDateTime(dr["TanggalLahir"]);
                        dtNas.NoHP = dr["NoHP"].ToString();

                        listdataNasabah.Add(dtNas);
                    }
                }

            }
            catch (Exception err)
            {
                throw err;
            }

            return listdataNasabah;
        }
        public void CreateData(DataNasabahViewModel model)
        {
            var con = GetConnection();
            con.Open();

            var cmd = new SqlCommand("[dbo].[ManipulateDataNasabah]", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandTimeout = 7200;
            var sd = new SqlDataAdapter(cmd);
            var dt = new DataTable();

            cmd.Parameters.AddWithValue("@actionType", "CREATE");
            cmd.Parameters.AddWithValue("@noKTP", model.NoKTP);
            cmd.Parameters.AddWithValue("@alamat", model.Alamat);
            cmd.Parameters.AddWithValue("@nama", model.Nama);
            cmd.Parameters.AddWithValue("@tempatLahir", model.TempatLahir);
            cmd.Parameters.AddWithValue("@tanggalLahir", model.TanggalLahir);
            cmd.Parameters.AddWithValue("@noHP", model.NoHP);
            cmd.ExecuteNonQuery();

        }
        public void UpdateData(DataNasabahViewModel model)
        {
            var con = GetConnection();
            con.Open();

            var cmd = new SqlCommand("[dbo].[ManipulateDataNasabah]", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandTimeout = 7200;
            var sd = new SqlDataAdapter(cmd);
            var dt = new DataTable();

            cmd.Parameters.AddWithValue("@actionType", "UPDATE");
            cmd.Parameters.AddWithValue("@alamat", model.Alamat);
            cmd.Parameters.AddWithValue("@nama", model.Nama);
            cmd.Parameters.AddWithValue("@noHP", model.NoHP);
            cmd.Parameters.AddWithValue("@ID", model.ID);
            cmd.ExecuteNonQuery();

        }
        public void DeleteData(DataNasabahViewModel model)
        {
            var con = GetConnection();
            con.Open();

            var cmd = new SqlCommand("[dbo].[ManipulateDataNasabah]", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandTimeout = 7200;
            var sd = new SqlDataAdapter(cmd);
            var dt = new DataTable();

            cmd.Parameters.AddWithValue("@actionType", "DELETE");
            cmd.Parameters.AddWithValue("@ID", model.ID);
            cmd.ExecuteNonQuery();

        }
    }
}