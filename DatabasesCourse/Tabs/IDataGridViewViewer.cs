using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabasesCourse.DatabaseModel;

namespace DatabasesCourse.Tabs
{
    interface IDataGridViewViewer
    {
        public DatabaseContext Context { get; set; }

        void UpdateDataGridView();
    }
}
