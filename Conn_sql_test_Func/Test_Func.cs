using Conn_mysql_X;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Conn_sql_test_Func
{
    public class Test_Func
    {
        public static void Main(string[] args)
        {
            //Arrange
            string BeginName = "test";
            string BeginName1 = "test123";
            string BeginPWD = "6789";
            string Test_PWD_Correct = "9999";
            int BeginLev = 55688;



            //Act
            Conn_sql.Add_member(BeginName, BeginPWD, BeginLev);
            Conn_sql.Change_pwd(BeginName, "9999");


            //Assert
            string Ans;
            Ans = Conn_sql.Get_data(BeginName);

            if (Ans == Test_PWD_Correct)
            {
                Console.WriteLine("Correct!!");
            }
            else
            {
                Console.WriteLine("Wrong!!!!!!!!!!!!!!!");
            }

            Conn_sql.del_member(BeginName);


        }
    }
}
