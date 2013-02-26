//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Architectural overview and usage guide: 
// http://blogofrab.blogspot.com/2010/08/maintenance-free-mocking-for-unit.html
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Data;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ComplexCommerce.Data.SqlServer.Model
{
    /// <summary>
    /// The interface for the generic object context. This contains all of
    /// the <code>ObjectContext</code> properties that are implemented in the 
    /// concrete ObjectContext class. This interface was created so these members
    /// can be mocked, as ObjectContext doesn't have a default public constructor.
    /// </summary>
    public interface IObjectContext : IDisposable
    {
        void AcceptAllChanges();
        void AddObject(string entitySetName, object entity);
        TEntity ApplyCurrentValues<TEntity>(string entitySetName, TEntity currentEntity) where TEntity : class;
        TEntity ApplyOriginalValues<TEntity>(string entitySetName, TEntity originalEntity) where TEntity : class;
        void ApplyPropertyChanges(string entitySetName, object changed);
        void Attach(System.Data.Objects.DataClasses.IEntityWithKey entity);
        void AttachTo(string entitySetName, object entity);
        int? CommandTimeout { get; set; }
        DbConnection Connection { get; }
        ObjectContextOptions ContextOptions { get; }
        void CreateDatabase();
        string CreateDatabaseScript();
        EntityKey CreateEntityKey(string entitySetName, object entity);
        T CreateObject<T>() where T : class;
        ObjectSet<TEntity> CreateObjectSet<TEntity>() where TEntity : class;
        ObjectSet<TEntity> CreateObjectSet<TEntity>(string entitySetName) where TEntity : class;
        void CreateProxyTypes(IEnumerable<Type> types);
        ObjectQuery<T> CreateQuery<T>(string queryString, params ObjectParameter[] parameters);
        bool DatabaseExists();
        string DefaultContainerName { get; set; }
        void DeleteDatabase();
        void DeleteObject(object entity);
        void Detach(object entity);
        void DetectChanges();
        void Dispose();
        int ExecuteFunction(string functionName, params ObjectParameter[] parameters);
        ObjectResult<TElement> ExecuteFunction<TElement>(string functionName, params ObjectParameter[] parameters);
        ObjectResult<TElement> ExecuteFunction<TElement>(string functionName, MergeOption mergeOption, params ObjectParameter[] parameters);
        int ExecuteStoreCommand(string commandText, params object[] parameters);
        ObjectResult<TElement> ExecuteStoreQuery<TElement>(string commandText, params object[] parameters);
        ObjectResult<TEntity> ExecuteStoreQuery<TEntity>(string commandText, string entitySetName, MergeOption mergeOption, params object[] parameters);
        object GetObjectByKey(System.Data.EntityKey key);
        void LoadProperty(object entity, string navigationProperty);
        void LoadProperty(object entity, string navigationProperty, MergeOption mergeOption);
        void LoadProperty<TEntity>(TEntity entity, Expression<Func<TEntity, object>> selector);
        void LoadProperty<TEntity>(TEntity entity, Expression<Func<TEntity, object>> selector, MergeOption mergeOption);
        System.Data.Metadata.Edm.MetadataWorkspace MetadataWorkspace { get; }
        ObjectStateManager ObjectStateManager { get; }
        void Refresh(RefreshMode refreshMode, IEnumerable collection);
        void Refresh(RefreshMode refreshMode, object entity);
        int SaveChanges();
        int SaveChanges(bool acceptChangesDuringSave);
        int SaveChanges(SaveOptions options);
        ObjectResult<TElement> Translate<TElement>(DbDataReader reader);
        ObjectResult<TEntity> Translate<TEntity>(DbDataReader reader, string entitySetName, MergeOption mergeOption);
        bool TryGetObjectByKey(EntityKey key, out object value);
    }
}