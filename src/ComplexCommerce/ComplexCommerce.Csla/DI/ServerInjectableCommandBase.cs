﻿using System;
using System.Runtime.Serialization;
using CslaLibrary = Csla;
using Csla;

namespace ComplexCommerce.Csla.DI
{
    [Serializable]
    public abstract class ServerInjectableCommandBase<T> :
        CslaLibrary.CommandBase<T>
        where T : CslaLibrary.CommandBase<T>
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

        protected override void OnDeserialized(StreamingContext context)
        {
            //inject dependencies into instance 
            InjectDependencies();

            // call base class
            base.OnDeserialized(context);
        }

        protected void InjectDependencies()
        {
            if (!IsServerInjected)
            {
                Inject();
                IsServerInjected = true;
            }
        }

        private void Inject()
        {
            if (DI.IoC.Container != null)
                DI.IoC.Container.Inject(this);
            // TODO: Throw sensible exception here explaining how to configure the container
            // for use in dependency injection.
        }
    }
}
