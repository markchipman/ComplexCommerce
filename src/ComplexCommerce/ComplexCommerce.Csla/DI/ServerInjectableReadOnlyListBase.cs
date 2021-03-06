﻿using System;
using System.Runtime.Serialization;
using CslaLibrary = Csla;
using Csla;

namespace ComplexCommerce.Csla.DI
{
    [Serializable]
    public abstract class ServerInjectableReadOnlyListBase<T, C> :
        CslaLibrary.ReadOnlyListBase<T, C>
        where T : CslaLibrary.ReadOnlyListBase<T, C>
    {
        [NonSerialized]
        private bool mIsServerInjected = false;

        private bool IsServerInjected
        {
            get { return mIsServerInjected; }
            set { mIsServerInjected = value; }
        }


        protected override void DataPortal_OnDataPortalInvoke(DataPortalEventArgs e)
        {
            //inject dependencies into instance 
            InjectDependencies();

            //call base class
            base.DataPortal_OnDataPortalInvoke(e);
        }

        protected override void Child_OnDataPortalInvoke(DataPortalEventArgs e)
        {
            //inject dependencies into instance 
            InjectDependencies();

            //call base class
            base.Child_OnDataPortalInvoke(e);
        }

        protected override void OnDeserialized()
        {
            //inject dependencies into instance 
            InjectDependencies();

            // call base class
            base.OnDeserialized();
        }

        protected void InjectDependencies()
        {
            if (!IsServerInjected)
            {
                Inject();
                IsServerInjected = true;
            }
        }

        //protected abstract void Inject();

        private void Inject()
        {
            if (DI.IoC.Container != null)
                DI.IoC.Container.Inject(this);
            // TODO: Throw sensible exception here explaining how to configure the container
            // for use in dependency injection.
        }
    }
}
