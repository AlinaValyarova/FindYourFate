using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindYourFate.Tests
{
    [TestClass]
    public class DataBaseTests
    {
        [TestMethod]
        public void openConnetionTests()
        {
            DataBase extend = new DataBase();
            extend.openConnetion();
            string actual = "Open";
            Assert.IsTrue(extend.getConnection().State.ToString() == actual);
        }

        [TestMethod]
        public void getConnectionTests()
        {
            DataBase dataBase = new DataBase();
            dataBase.openConnetion();
            Type extend = dataBase.getConnection().GetType();
            Type actual = typeof(SqlConnection);
            Assert.IsInstanceOfType(extend, extend);
        }

        [TestMethod]
        public void closeConnetionTests()
        {
            DataBase extend = new DataBase();
            extend.openConnetion();
            extend.closeConnetion();
            string actual = "Close";
            Assert.IsTrue(extend.getConnection().State.ToString() == actual);
        }
    }
}
