using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace bankapp3
{
    class AccountCrud
    {
        SqlConnection conn;
        SqlCommand cmd;
        public int Generate()
        {
            conn = ConnectionHelp.GetConnection();
            conn.Open();
            cmd = new SqlCommand("GenerateAccNo", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            return Convert.ToInt32(dr["accno"]);

        }
        public string AddAccount(Account a)
        {

            conn = ConnectionHelp.GetConnection();
            conn.Open();
            cmd = new SqlCommand("procAccountInsert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accountno", a.acno);
            cmd.Parameters.AddWithValue("@firstname", a.fname);
            cmd.Parameters.AddWithValue("@lastname", a.lname);
            cmd.Parameters.AddWithValue("@city", a.city);
            cmd.Parameters.AddWithValue("@state", a.state);
            cmd.Parameters.AddWithValue("@dateofopening", a.date);
            cmd.Parameters.AddWithValue("@amount", a.amount);
            cmd.Parameters.AddWithValue("@cheqfacil", a.cheq);
            cmd.Parameters.AddWithValue("@accounttype", a.actype);
            cmd.Parameters.AddWithValue("@status", a.status);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            
            conn.Close();
            return "Account Added Successfully";
        }

        public Account[] ShowAccount()
        {
            conn = ConnectionHelp.GetConnection();
            conn.Open();
            cmd = new SqlCommand("procAccountShow", conn);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            catch (Exception)
            {

                throw;
            }
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            int c = dt.Rows.Count;
            Account[] ar = new Account[c];
            Account a = null;
            int i = 0;
            foreach (DataRow d in dt.Rows)
            {
                a = new Account();
                a.acno = Convert.ToInt32(d["Accountno"]);
                a.fname = d["firstname"].ToString();
                a.lname = d["lastname"].ToString();
                a.city = d["city"].ToString();
                a.state = d["state"].ToString();
                a.date = d["dateofopening"].ToString();
                a.amount = Convert.ToInt32(d["amount"]);
                a.cheq = d["cheqfacil"].ToString();
                a.actype = d["accounttype"].ToString();
                a.status = d["status"].ToString();
                ar[i++] = a;
            }
            conn.Close();
            return ar;
        }

        
        public void SearchAccount(int accountno, out string firstname, out string lastname, out string city, out string state, out int amount,
            out string cheqfacil, out string accounttype)

        {
            conn = ConnectionHelp.GetConnection();
            conn.Open();
            cmd = new SqlCommand("prcSearchAccount1", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accountno", accountno);
            cmd.Parameters.Add(new SqlParameter("@firstname", SqlDbType.VarChar, 30));
            cmd.Parameters["@firstname"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add(new SqlParameter("@lastname", SqlDbType.VarChar, 30));
            cmd.Parameters["@lastname"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add(new SqlParameter("@city", SqlDbType.VarChar, 30));
            cmd.Parameters["@city"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add(new SqlParameter("@state", SqlDbType.VarChar, 30));
            cmd.Parameters["@state"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add(new SqlParameter("@amount", SqlDbType.VarChar, 30));
            cmd.Parameters["@amount"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add(new SqlParameter("@cheqfacil", SqlDbType.VarChar, 30));
            cmd.Parameters["@cheqfacil"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add(new SqlParameter("@accounttype", SqlDbType.VarChar, 30));
            cmd.Parameters["@accounttype"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            firstname = cmd.Parameters["@firstname"].Value.ToString();
            lastname = cmd.Parameters["@lastname"].Value.ToString();
            city = cmd.Parameters["@city"].Value.ToString();
            state = cmd.Parameters["@state"].Value.ToString();
            amount = Convert.ToInt32(cmd.Parameters["@amount"].Value.ToString());
            cheqfacil = cmd.Parameters["@cheqfacil"].Value.ToString();
            accounttype = cmd.Parameters["@accounttype"].Value.ToString();

        }
        
        public string Close(int a)
        {
            conn = ConnectionHelp.GetConnection();
            conn.Open();
            cmd = new SqlCommand("proAccountclose", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accountno", a);
            cmd.ExecuteNonQuery();
            conn.Close();
            return "account deleted";
        }
        
        public string WithdrawAccount(int n, int amount)
        {
            conn = ConnectionHelp.GetConnection();
            conn.Open();
            cmd = new SqlCommand("prcAccountWithdraw", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accountno", n);
            cmd.Parameters.AddWithValue("@withdrawamount", amount);
            cmd.Parameters.Add(new SqlParameter("@result", SqlDbType.VarChar, 30));
            cmd.Parameters["@result"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            string result = cmd.Parameters["@result"].Value.ToString();
            return result;
        }

        public string depositaccount(int n, int amount)
        {
            conn = ConnectionHelp.GetConnection();
            conn.Open();
            cmd = new SqlCommand("prcAccoundeposit", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accountno", n);
            cmd.Parameters.AddWithValue("@depositamount", amount);
            cmd.Parameters.Add(new SqlParameter("@result", SqlDbType.VarChar, 30));
            cmd.Parameters["@result"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            string result = cmd.Parameters["@result"].Value.ToString();
            return result;
        }
    }
}
