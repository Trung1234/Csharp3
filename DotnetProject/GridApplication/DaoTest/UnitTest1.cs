using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DapperLibrary.Model;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace DaoTest
{
    [TestClass]
    public class UnitTest1
    {
        //Dau vao=>Dau ra
        //Ket qua mong muon
        //Ket qua chay: So sanh dau ra voi Dau ra mong muon=>true/false
        [TestMethod]
        public void TestBranchDao()
        {

            var expect = BranchDao.Instance().GetALL();
            var firstBranch = expect[0];
            var list = new List<BRANCH>()
            {
                new BRANCH {BRANCH_ID = 1,   ADDRESS = "3882 Main St.",CITY = "Waltham ",
                    NAME = "Headquarters" ,   STATE= "MA" ,  ZIP_CODE = "02451"  }
            };
            Assert.AreEqual(firstBranch, list);
        }

        #region ProductTypeDao

        /// <summary>
        /// Ham test cho Get all
        /// </summary>
        [TestMethod]
        public void TestProductTypeDaoGetAll()
        {


            var listProductType = ProductTypeDao.Instance().GetALL();
            int expect = 0;
            Assert.IsTrue(listProductType.Count > expect);


        }
        [TestMethod]
        public void TestProductTypeSearchCd()
        {

            string productCd = "IT";
            var listSearch = ProductTypeDao.Instance().SearchByCD("IT");
            Assert.IsTrue(listSearch.Where(x => x.PRODUCT_TYPE_CD.Contains(productCd)).Count() > 0);

        }

        [TestMethod]
        public void TestProductTypeSearchCdError()
        {


            var listSearch = ProductTypeDao.Instance().SearchByCD(null);
            Assert.IsTrue(listSearch == null);

        }


        [TestMethod]
        public void TestProductTypeAdd()
        {
            try
            {
                PRODUCT_TYPE pt = new PRODUCT_TYPE() { PRODUCT_TYPE_CD = "IT", NAME = "IT1" };
                ProductTypeDao.Instance().Add(pt);
                var getNewId = ProductTypeDao.Instance().SearchByCD(pt.PRODUCT_TYPE_CD);


            }
            catch (Exception ex)
            {
                Assert.IsFalse(ex.Data != null);
            }
        }
        [TestMethod]
        public void TestProductTypeAddSuccess()
        {
            try
            {
                PRODUCT_TYPE pt = new PRODUCT_TYPE() { PRODUCT_TYPE_CD = "IT11", NAME = "IT1" };
                ProductTypeDao.Instance().Add(pt);
                var getNewId = ProductTypeDao.Instance().SearchByCD(pt.PRODUCT_TYPE_CD);
                Assert.IsTrue(getNewId.Count > 0);

            }
            catch (Exception ex)
            {
                Assert.IsFalse(ex.Data != null);
            }
        }

        #endregion
    }

}
