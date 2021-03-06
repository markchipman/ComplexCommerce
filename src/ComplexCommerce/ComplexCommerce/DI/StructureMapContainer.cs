﻿using System;
using System.Collections.Generic;
using StructureMap;
using ComplexCommerce.Shared.DI;

namespace ComplexCommerce.DI
{
    // Container to pass the instance of the DI container to Controller for resolving dependencies
    public class StructureMapContainer 
        : IDependencyInjectionContainer
    {
        private readonly StructureMap.IContainer container;

        public StructureMapContainer(StructureMap.IContainer container)
        {
            this.container = container;
        }

        #region IDependencyInjectionContainer Members

        public object Resolve(Type type)
        {
            try
            {
                return container.GetInstance(type);
            }
            catch (StructureMapException ex)
            {
                string message = ex.Message + "\n" + container.WhatDoIHave();
                throw new Exception(message);
            }
        }

        public IEnumerable<object> GetInstances(Type type)
        {
            return container.GetAllInstances(type) as IEnumerable<object>;
        }

        #endregion
    }
}