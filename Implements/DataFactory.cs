using FactoryMethod.Solution_2;
using static FactoryMethod.Solution_1.DelegateService;

namespace FactoryMethod.Implements
{
    public class DataFactory : IDataFactory
    {
        private IData _dataNew;
        private IData _dataUpdate;
        private IData _dataDelete;
        private readonly Func<ServiceEnum, IData> _factory;
        public DataFactory(ServiceResolver<IData> dataNew,
            ServiceResolver<IData> dataUpdate,
            ServiceResolver<IData> dataDelete,
            Func<ServiceEnum, IData> factory)
        {
            _dataNew = dataNew(nameof(DataNew));
            _dataUpdate = dataNew(nameof(DataUpdate));
            _dataDelete = dataNew(nameof(DataDelete));
            _factory = factory;
        }
        public void Save(string data, string key)
        {
            switch (key)
            {
                case nameof(DataUpdate): _dataNew.Query(""); break;
                case nameof(DataNew): _dataUpdate.Query(""); break;
                case nameof(DataDelete): _dataDelete.Query(""); break;
            }
        }

        public void SaveByEnum(string data, ServiceEnum key)
        {
            var service = _factory(key);
            service.Query("");
        }
    }
}
