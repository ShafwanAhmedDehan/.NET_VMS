using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerVMS.Interface
{
    public interface BasicOperation <CLASS, ID, RET>
    {
        CLASS Get(ID id);
        RET Create(CLASS values);
        RET Update(CLASS values, ID id);
        List<CLASS> Get();
        bool Delete(ID id);
    }
}
