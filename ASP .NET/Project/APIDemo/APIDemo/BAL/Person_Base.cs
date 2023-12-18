using APIDemo.DAL;
using APIDemo.Models;

namespace APIDemo.BAL
{
    public class Person_Base
    {
        public List<PersonModel> API_PERSON_SELECTALL()
        {
            try
            {
                Person_DALBase person_DALBase = new Person_DALBase();
                List<PersonModel> personModels = person_DALBase.API_PERSON_SELECTALL();
                return personModels;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public PersonModel API_PERSON_SELECTById(int PersonId)
        {
            try
            {
                Person_DALBase person_DAL = new Person_DALBase();
                PersonModel personModel = person_DAL.API_PERSON_SELECTById(PersonId);
                return personModel;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
