using FactoryMethod.Solution_2;

namespace FactoryMethod
{
    public interface IDataFactory
    {
        void Save(string data, string key);
        void SaveByEnum(string data, ServiceEnum key);
    }
}
