using Necnat.Abp.NnLibCommon.Entities;
using Necnat.Abp.NnLibCommon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;

namespace NnGames.Abp.NnLibPoe.Repositories
{
    public abstract class JsonRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IGetSetEntity<TKey>
    {
        public IAbpLazyServiceProvider LazyServiceProvider { get; set; } = default!;
        public IAsyncQueryableExecuter AsyncExecuter => LazyServiceProvider.LazyGetRequiredService<IAsyncQueryableExecuter>();
        public bool? IsChangeTrackingEnabled => false;

        public Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var list = Load();
            list.RemoveAll(predicate.Compile());
            Save(list);

            return Task.CompletedTask;      
        }

        public Task DeleteAsync(TKey id, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var list = Load();
            list.RemoveAll(x => x.Id!.Equals(id));
            Save(list);

            return Task.CompletedTask;
        }

        public Task DeleteAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            return DeleteAsync(entity.Id, autoSave, cancellationToken);
        }

        public Task DeleteDirectAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return DeleteAsync(predicate, true, cancellationToken);
        }

        public Task DeleteManyAsync(IEnumerable<TKey> ids, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var list = Load();
            list.RemoveAll(x => ids.Contains(x.Id!));
            Save(list);

            return Task.CompletedTask;
        }

        public Task DeleteManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            return DeleteManyAsync(entities.Select(x => x.Id), autoSave, cancellationToken);
        }

        public Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            var list = Load();
            var entity = list.Where(predicate.Compile()).FirstOrDefault();

            return Task.FromResult(entity);
        }

        public Task<TEntity?> FindAsync(TKey id, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            var list = Load();
            var entity = list.Where(x => x.Id!.Equals(id)).FirstOrDefault();

            return Task.FromResult(entity);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            return (await FindAsync(predicate, includeDetails, cancellationToken)) ?? throw new EntityNotFoundException(typeof(TEntity)) ; 
        }

        public async Task<TEntity> GetAsync(TKey id, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            return (await FindAsync(id, includeDetails, cancellationToken)) ?? throw new EntityNotFoundException(typeof(TEntity));
        }

        public Task<long> GetCountAsync(CancellationToken cancellationToken = default)
        {
            var list = Load();
            return Task.FromResult((long)list.Count);
        }

        public Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            var list = Load();
            var entity = list.Where(predicate.Compile()).ToList();

            return Task.FromResult(entity);
        }

        public Task<List<TEntity>> GetListAsync(bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Load());
        }

        public async Task<List<TEntity>> GetPagedListAsync(int skipCount, int maxResultCount, string sorting, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            return (await GetQueryableAsync()).OrderByIf<TEntity, IQueryable<TEntity>>(!sorting.IsNullOrWhiteSpace(), sorting)
            .PageBy(skipCount, maxResultCount)
            .ToList();
        }

        public Task<IQueryable<TEntity>> GetQueryableAsync()
        {
            return Task.FromResult(Load().AsQueryable());
        }

        public Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var list = Load();
            entity.Id = NextKey(list.Max(x => x.Id) ?? default!);
            list.Add(entity);
            Save(list);

            return Task.FromResult(entity);
        }

        public Task InsertManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var list = Load();

            var max = list.Max(x => x.Id) ?? default!;
            foreach (var entity in entities)
            {
                entity.Id = NextKey(max);
                list.Add(entity);

                max = entity.Id;
            }

            Save(list);

            return Task.CompletedTask;
        }

        public Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var list = Load();
            list.RemoveAll(x => x.Id!.Equals(entity.Id));
            list.Add(entity);

            return Task.FromResult(entity);
        }

        public Task UpdateManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var list = Load();
            list.RemoveAll(x => entities.Select(y => y.Id).Contains(x.Id!));

            var max = list.Max(x => x.Id) ?? default!;
            foreach (var entity in entities)
            {
                entity.Id = NextKey(max);
                list.Add(entity);

                max = entity.Id;
            }

            return Task.CompletedTask;
        }

        public IQueryable<TEntity> WithDetails()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> WithDetails(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<TEntity>> WithDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<TEntity>> WithDetailsAsync(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            throw new NotImplementedException();
        }

        private List<TEntity> Load()
        {
            return JsonUtil.ReadFromJsonFile<List<TEntity>>(GetJsonFilePath());
        }

        private void Save(List<TEntity> entityList)
        {
            JsonUtil.WriteToJsonFile(GetJsonFilePath(), entityList);
        }

        public abstract TKey NextKey(TKey key);

        public abstract string GetJsonFilePath();
    }
}
