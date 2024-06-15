using Necnat.Abp.NnLibCommon.Entities;

namespace NnGames.Abp.NnLibPoe.Repositories
{
    public abstract class IntPoeRepository<TEntity> : PoeRepository<TEntity, int>
        where TEntity : class, IGetSetEntity<int>
    {
        protected IntPoeRepository(string jsonName) : base(jsonName)
        {
        }

        public override int NextKey(int key)
        {
            return key + 1;
        }
    }
}
