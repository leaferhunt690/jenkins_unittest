using Conn_mysql_X;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Conn_mysql_test
{
    [TestClass()]
    public class SQL_Func_UnitTest_Fail
    {
        [TestMethod()]
        public void Test_Fail ()
        {
            //Arrange
            string BeginName = "test";
            string BeginName1 = "test123";
            string BeginPWD = "6789";
            string Test_PWD_Correct = "9999";
            string Test_PWD_Wrong = "6666";
            int BeginLev = 55688;

            //Act
            Conn_sql.del_member(BeginName);
            Conn_sql.Add_member(BeginName, BeginPWD, BeginLev);
            Conn_sql.Change_pwd(BeginName, "9999");


            //Assert
            string ans;
            ans = Conn_sql.Get_data(BeginName);
            Assert.AreEqual(Test_PWD_Wrong, ans);



            //string Ans;
            //Ans = Conn_sql.Get_data(BeginName1);

            //if (Ans == Test_PWD_Correct)
            //{
            //    Console.WriteLine("Correct!!");
            //}
            //else
            //{
            //    Console.WriteLine("Wrong!!!!!!!!!!!!!!!");
            //}

        }
    }
}
