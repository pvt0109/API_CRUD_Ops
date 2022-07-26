using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_CURR_Converter.Models
{
    public class CRUDOps : CrudInterface
    {
        private List<CRUD> cRUDs = new List<CRUD>();
        private int _nextId = 1;

        public CRUDOps()
        {
            Add(new CRUD { Name = "Test1", Address = "India" });
            Add(new CRUD { Name = "Test2", Address = "America" });
            Add(new CRUD { Name = "Test3", Address = "UAE" });
            Add(new CRUD { Name = "Test4", Address = "England" });
            Add(new CRUD { Name = "Test5", Address = "Asia" });
            Add(new CRUD { Name = "Test6", Address = "China" });
        }
        public CRUD Add(CRUD item)
        {
            try
            {
                if (item == null)
                {
                    throw new ArgumentNullException("item");
                }
                item.Id = _nextId++;
                cRUDs.Add(item);
                return item;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }


        }

        public CRUD Get(int id)
        {
            try
            {
                return cRUDs.Find(p => p.Id == id);
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw new NotImplementedException();

            }


        }

        public IEnumerable<CRUD> GetAll()
        {
            try
            {
                return cRUDs;
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw new NotImplementedException();

            }


        }

        public void Remove(int id)
        {
            try
            {
                cRUDs.RemoveAll(p => p.Id == id);
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw new NotImplementedException();
            }


        }

        public bool Update(CRUD item)
        {
            try
            {
                if (item == null)
                {
                    throw new ArgumentNullException("item");
                }
                int index = cRUDs.FindIndex(p => p.Id == item.Id);
                if (index == -1)
                {
                    return false;
                }
                cRUDs.RemoveAt(index);
                cRUDs.Add(item);
                return true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw new NotImplementedException();
            }


        }
    }
}