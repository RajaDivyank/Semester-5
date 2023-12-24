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
        public bool API_PERSON_DELETEBYID(int PersonId)
        {
            try
            {
                Person_DALBase person_DALBase = new Person_DALBase();
                if (person_DALBase.API_PERSON_DELETEBYID(PersonId))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }catch(Exception Ex)
            {
                return false;
            }
        }
        public bool API_PERSON_Insert_Record(PersonModel personModel)
        {
            try
            {
                Person_DALBase person_DALBase = new Person_DALBase();
                if (person_DALBase.API_PERSON_Insert_Record(personModel))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool API_PERSON_UpdateByPERSONID(int PersonId,PersonModel personModel)
        {
            try
            {
                Person_DALBase person_DALBase = new Person_DALBase();
                if (person_DALBase.API_PERSON_UpdateByPERSONID(PersonId,personModel))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
