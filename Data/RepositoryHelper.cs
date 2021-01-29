using JWTExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTExample.Data
{
    public class RepositoryHelper
    {
        private readonly AuthDBContext _db;
        public RepositoryHelper(AuthDBContext db)
        {
            _db = db;
        }


        public List<Details> Todo(Guid id)
        {
            List<Details> lstReturn = new List<Details>();

            try
            {
                lstReturn = _db.todo.Where(x => x.MOTHER_UUID == id).ToList();
            }
            catch (Exception e)
            {
            }

            return lstReturn;
        }

        internal bool Register(UserCredentials user)
        {
            var exists = _db.credentials.Where(x => x.Name == user.Name).FirstOrDefault();

            if (exists != null)
            {
                return false;
            }
            else
            {
                _db.credentials.Add(user);

                _db.SaveChanges();

                return true;
            }
        }

        internal UserCredentials Login(UserCredentials user)
        {
            var exists = _db.credentials.Where(x => x.Name == user.Name && x.Password == user.Password).FirstOrDefault();

            if (exists != null)
            {

                return exists;

            }
            else
            {
                return null;
            }
        }

        public bool Add(Details d)
        {
            bool bReturn = false;

            try
            {

                _db.todo.Add(d);

                _db.SaveChanges();

                bReturn = true;
            }
            catch (Exception e)
            { 
            }

            return bReturn;
        }
        public bool Update(Details d)
        {
            bool bReturn = false;

            try
            {
                var record = _db.todo.Where(x => x.UUID == d.UUID).FirstOrDefault();

                if (record != null)
                {
                    record.MOTHER_UUID = d.MOTHER_UUID;

                    record.TODO = d.TODO;

                    _db.todo.Add(record);

                    _db.SaveChanges();

                    bReturn = true;
                }
            }
            catch (Exception e)
            {
            }

            return bReturn;
        }


        public bool Delete(Guid id)
        {
            bool bReturn = false;

            try
            {
                var record = _db.todo.Where(x => x.UUID == id).FirstOrDefault();

                _db.todo.Remove(record);

                _db.SaveChanges();

                bReturn = true;
            }
            catch (Exception e)
            {
            }

            return bReturn;
        }
    }
}
