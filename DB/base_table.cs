using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 写真館システム.DB
{
    interface base_table
    {
        void Command(bool delete = false);
    }
}
