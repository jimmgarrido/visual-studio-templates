using MasterDetail.Helpers;
using MasterDetail.Interfaces;
using MasterDetail.Services;
using MasterDetail.Model;

namespace MasterDetail
{
    public partial class App 
    {
        public App()
        {
        }

        public static void Initialize()
        {
            ServiceLocator.Instance.Register<IDataStore<Item>, MockDataStore>();
        }
    }
}