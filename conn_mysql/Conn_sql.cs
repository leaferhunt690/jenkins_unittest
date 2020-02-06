using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
namespace Conn_mysql_X
{
    public class Conn_sql
    {
        public static void Add_member(string name, string pwd, int lev)
        {
            string dbhost = "127.0.0.1"; //DB_Addr
            string dbuser = "root"; //DB_usr_name
            string dbpass = ""; //DB_usr_pwd
            string dbname = "unittest"; //DB_name

            string connstr = "server=" + dbhost + ";uid=" + dbuser + ";pwd=" + dbpass + ";database=" + dbname;
            MySqlConnection conn = new MySqlConnection(connstr);
            MySqlCommand command = conn.CreateCommand();
            conn.Open();

            //< add member >
            string account = name;
            string password = pwd;
            int level = lev;
            command.CommandText = "insert into member(account,password,level) values('" + account + "','" + password + "'," + level + ")";
            command.ExecuteNonQuery();
            //for (int i = 0; i < 10; i++)
            //{
            //    account = "account" + i.ToString();
            //    password = "password" + i.ToString();
            //    level = i * 10;
            //    command.CommandText = "insert into member(account,password,level) values('" + account + "','" + password + "'," + level + ")";
            //    command.ExecuteNonQuery();

            //}
            Console.WriteLine("Already added new member!");
            conn.Close();
        }
        public static void Change_pwd(string change_name, string new_pwd)
        {
            string nw_pwd = new_pwd;
            string cg_name = change_name;
            string dbhost = "127.0.0.1"; //DB_Addr
            string dbuser = "root"; //DB_usr_name
            string dbpass = ""; //DB_usr_pwd
            string dbname = "unittest"; //DB_name
            string connstr = "server=" + dbhost + ";uid=" + dbuser + ";pwd=" + dbpass + ";database=" + dbname;
            MySqlConnection conn = new MySqlConnection(connstr);
            MySqlCommand command = conn.CreateCommand();
            conn.Open();
            //< change password >
            string connstr_text = "Update member SET password='" + nw_pwd + "' WHERE account='" + cg_name + "'";
            command.CommandText = connstr_text;
            command.ExecuteNonQuery();
            Console.WriteLine("Already changed password!");
            conn.Close();

        }
        public static String Get_data(string get_name)
        {
            string s = "";
            string dbhost = "127.0.0.1"; //DB_Addr
            string dbuser = "root"; //DB_usr_name
            string dbpass = ""; //DB_usr_pwd
            string dbname = "unittest"; //DB_name
            string connstr = "server=" + dbhost + ";uid=" + dbuser + ";pwd=" + dbpass + ";database=" + dbname;
            MySqlConnection conn = new MySqlConnection(connstr);
            MySqlCommand command = conn.CreateCommand();
            conn.Open();
            //< collect data >
            string cmdtext = "select * from member where account = '" + get_name + "'";
            MySqlCommand cmd = new MySqlCommand(cmdtext, conn);
            MySqlDataReader reader = cmd.ExecuteReader(); //execure the reader
            //string s = reader.GetString();
            //Console.WriteLine(s);
            while (reader.Read())
            {
                s = reader.GetString(2);
                //Console.Write(s+"\n");
                return s;

            }
            //while (reader.Read())
            //{
            //    for (int i = 0; i < 4; i++)
            //    {
            //        string s = reader.GetString(i);
            //        Console.Write(s + "\t");
            //    }
            //    Console.Write("\n");
            //}
            conn.Close();
            return s;
        }

        public static void del_member(string name)
        {
            string dbhost = "127.0.0.1"; //DB_Addr
            string dbuser = "root"; //DB_usr_name
            string dbpass = ""; //DB_usr_pwd
            string dbname = "unittest"; //DB_name
            string connstr = "server=" + dbhost + ";uid=" + dbuser + ";pwd=" + dbpass + ";database=" + dbname;
            MySqlConnection conn = new MySqlConnection(connstr);
            MySqlCommand command = conn.CreateCommand();
            conn.Open();

            command.CommandText = "Delete FROM member WHERE account = '" + name + "'";
            command.ExecuteNonQuery();
            Console.WriteLine("Already deleted " + name + "!");
            conn.Close();
        }
        public static void Main()
        {
            Conn_mysql_X.Conn_sql.Add_member("NFULAB", "0616", 55688);

            //Conn_mysql_X.Conn_sql.Change_pwd("test", "9999");

            //Conn_mysql_X.Conn_sql.Get_data("Harry");

        }
    }

}