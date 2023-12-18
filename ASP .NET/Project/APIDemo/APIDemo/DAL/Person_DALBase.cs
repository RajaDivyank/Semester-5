using APIDemo.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace APIDemo.DAL
{
    public class Person_DALBase:DAL_Helper
    {

        public List<PersonModel> API_PERSON_SELECTALL()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_PERSON_SELECTALL");
                List<PersonModel > list = new List<PersonModel>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        PersonModel model = new PersonModel();
                        model.PersonId = Convert.ToInt32(dr["PersonId"].ToString());
                        model.PersonName = dr["PersonName"].ToString();
                        model.PersonContact = dr["PersonContact"].ToString();
                        model.PersonEmail = dr["PersonEmail"].ToString();
                        list.Add(model);
                        
                    }
                }
                return list;
            }catch (Exception ex)
            {
                return null;
            }
        }

        public PersonModel API_PERSON_SELECTById(int PersonId)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnStr);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_PERSON_SELECTById");
                sqlDatabase.AddInParameter(dbCommand, "PersonId", SqlDbType.Int, PersonId);
                PersonModel model = new PersonModel();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    model.PersonId = Convert.ToInt32(dr["PersonId"].ToString());
                    model.PersonName = dr["PersonName"].ToString();
                    model.PersonContact = dr["PersonContact"].ToString();
                    model.PersonEmail = dr["PersonEmail"].ToString();
                }
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
