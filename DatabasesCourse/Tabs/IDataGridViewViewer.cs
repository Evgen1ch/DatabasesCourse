using DatabasesCourse.DatabaseModel;

namespace DatabasesCourse.Tabs
{
    interface IDataGridViewViewer
    {
        public DatabaseContext Context { get; set; }

        void UpdateDataGridView();
    }
}
