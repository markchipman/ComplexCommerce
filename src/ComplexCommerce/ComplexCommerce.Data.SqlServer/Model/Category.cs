//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ComplexCommerce.Data.SqlServer.Model
{
    public partial class Category
    {
        #region Primitive Properties
    
        public virtual System.Guid Id
        {
            get;
            set;
        }
    
        public virtual System.Guid StoreLocaleId
        {
            get { return _storeLocaleId; }
            set
            {
                if (_storeLocaleId != value)
                {
                    if (StoreLocale != null && StoreLocale.Id != value)
                    {
                        StoreLocale = null;
                    }
                    _storeLocaleId = value;
                }
            }
        }
        private System.Guid _storeLocaleId;
    
        public virtual string Name
        {
            get;
            set;
        }
    
        public virtual string Description
        {
            get;
            set;
        }
    
        public virtual string RouteUrl
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
        public virtual ICollection<CategoryXProductXStoreLocale> CategoryXProductXStoreLocale
        {
            get
            {
                if (_categoryXProductXStoreLocale == null)
                {
                    var newCollection = new FixupCollection<CategoryXProductXStoreLocale>();
                    newCollection.CollectionChanged += FixupCategoryXProductXStoreLocale;
                    _categoryXProductXStoreLocale = newCollection;
                }
                return _categoryXProductXStoreLocale;
            }
            set
            {
                if (!ReferenceEquals(_categoryXProductXStoreLocale, value))
                {
                    var previousValue = _categoryXProductXStoreLocale as FixupCollection<CategoryXProductXStoreLocale>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupCategoryXProductXStoreLocale;
                    }
                    _categoryXProductXStoreLocale = value;
                    var newValue = value as FixupCollection<CategoryXProductXStoreLocale>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupCategoryXProductXStoreLocale;
                    }
                }
            }
        }
        private ICollection<CategoryXProductXStoreLocale> _categoryXProductXStoreLocale;
    
        public virtual StoreLocale StoreLocale
        {
            get { return _storeLocale; }
            set
            {
                if (!ReferenceEquals(_storeLocale, value))
                {
                    var previousValue = _storeLocale;
                    _storeLocale = value;
                    FixupStoreLocale(previousValue);
                }
            }
        }
        private StoreLocale _storeLocale;

        #endregion

        #region Association Fixup
    
        private void FixupStoreLocale(StoreLocale previousValue)
        {
            if (previousValue != null && previousValue.Category.Contains(this))
            {
                previousValue.Category.Remove(this);
            }
    
            if (StoreLocale != null)
            {
                if (!StoreLocale.Category.Contains(this))
                {
                    StoreLocale.Category.Add(this);
                }
                if (StoreLocaleId != StoreLocale.Id)
                {
                    StoreLocaleId = StoreLocale.Id;
                }
            }
        }
    
        private void FixupCategoryXProductXStoreLocale(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (CategoryXProductXStoreLocale item in e.NewItems)
                {
                    item.Category = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (CategoryXProductXStoreLocale item in e.OldItems)
                {
                    if (ReferenceEquals(item.Category, this))
                    {
                        item.Category = null;
                    }
                }
            }
        }

        #endregion

    }
}
