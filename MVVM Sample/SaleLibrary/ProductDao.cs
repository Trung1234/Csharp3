using System;
using System.Collections.Generic;
using System.Linq;
using SaleLibrary.Model;

namespace TESTEntitiesLibrary
{
    public class ProductDao
    {
        private static ProductDao _instance;
        public static ProductDao Instance()
        {
            if (_instance == null)
                _instance = new ProductDao();
            return _instance;
        }

        public List<PRODUCT> GetALl()
        {
            using (TESTEntities entity = new TESTEntities())
            {
                var rs = entity.PRODUCTs.ToList(); ;
                return rs;
            }
        }

        public PRODUCT GetById(string id)
        {
            using (TESTEntities entity = new TESTEntities())
            {
                return entity.PRODUCTs.Where(x => x.PRODUCT_TYPE.Equals(id)).SingleOrDefault();
            }
        }

        public void Add(PRODUCT product)
        {
            if (product != null)
            {
                using (TESTEntities entity = new TESTEntities())
                {
                    entity.PRODUCTs.Add(product);
                    entity.SaveChanges();
                }
            }
        }
        public void Edit(PRODUCT product)
        {
            try
            {
                if (product != null)
                {
                    using (TESTEntities entity = new TESTEntities())
                    {
                        var proEdit = entity.PRODUCTs.Where(x => x.PRODUCT_CD == product.PRODUCT_CD).SingleOrDefault();
                        if (proEdit != null)
                        {
                            proEdit.DATE_OFFERED = product.DATE_OFFERED;
                            proEdit.DATE_RETIRED = product.DATE_RETIRED;
                            proEdit.NAME = product.NAME;
                            proEdit.PRODUCT_TYPE_CD = product.PRODUCT_TYPE_CD;
                            entity.SaveChanges();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Del(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                using (TESTEntities entity = new TESTEntities())
                {
                    var proDel = entity.PRODUCTs.Where(x => x.PRODUCT_CD.Equals(id)).SingleOrDefault();
                    if (proDel != null)
                    {
                        entity.PRODUCTs.Remove(proDel);
                        entity.SaveChanges();
                    }
                }
            }
        }
    }
}
