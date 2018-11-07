using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DapperLibrary.Model;

namespace DaoTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string cd = "111";
            var dao = new ProductTypeDao();
            var lisExpected = dao.SearchByCD(cd);
            var listProductType = dao.GetALL();
            var listActual = new List<PRODUCT_TYPE>();
            foreach (var type in listProductType)
            {
                if (type.PRODUCT_TYPE_CD.Contains(cd))
                {
                    listActual.Add(type);
                }
            }
            
            Assert.AreEqual(lisExpected,listActual);
           
        }
    }
}
