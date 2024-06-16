using MongoDB.Bson.Serialization;
using ProductsManagment.DAL.Libs;

namespace ProductsManagment.DAL
{
    public static class Mappings
    {
        public static void RegisterClassMaps()
        {

            if (!BsonClassMap.IsClassMapRegistered(typeof(Category)))
            {
                BsonClassMap.RegisterClassMap<Category>(cm =>
                {
                    cm.AutoMap();
                    cm.SetIsRootClass(true);
                    cm.AddKnownType(typeof(FreshProduct));
                    cm.AddKnownType(typeof(ElectricProduct));
                });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(FreshProduct)))
            {
                BsonClassMap.RegisterClassMap<FreshProduct>(cm =>
                {
                    cm.AutoMap();
                });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(ElectricProduct)))
            {
                BsonClassMap.RegisterClassMap<ElectricProduct>(cm =>
                {
                    cm.AutoMap();
                });
            }
        }
    }
}
