using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_CURR_Converter.Models
{
    interface CrudInterface
    {
        IEnumerable<CRUD> GetAll();
        CRUD Get(int id);
        CRUD Add(CRUD item);
        void Remove(int id);
        bool Update(CRUD item);
    }
}
