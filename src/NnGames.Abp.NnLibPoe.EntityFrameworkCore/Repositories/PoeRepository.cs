using Necnat.Abp.NnLibCommon.Entities;
using System;

namespace NnGames.Abp.NnLibPoe.Repositories
{
    public abstract class PoeRepository<TEntity, TKey> : JsonRepository<TEntity, TKey>, IPoeRepository
        where TEntity : class, IGetSetEntity<TKey>
    {
        protected readonly string _jsonName;

        public PoeRepository(string jsonName)
        {
            _jsonName = jsonName;
        }

        string _poe = "Poe";
        public void SetPoe(string poe)
        {
            _poe = poe;
        }

        string _verison = "VerDevelopment";
        public void SetVersion(string verison)
        {
            _verison = verison;
        }

        public override string GetJsonFilePath()
        {
            return AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\net8.0", "") + $"JsonDb\\{_poe}\\{_verison}.{_jsonName}.json";
        }
    }
}
