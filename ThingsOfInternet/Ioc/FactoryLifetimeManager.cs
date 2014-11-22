using System;
using System.Diagnostics.Contracts;
using Microsoft.Practices.Unity;

namespace ThingsOfInternet.Ioc
{
    /// <summary>
    /// http://xhalent.wordpress.com/2011/02/02/resolving-instances-using-delegates-in-unity/
    /// </summary>
    public class FactoryLifetimeManager : LifetimeManager
    {
        private LifetimeManager baseManager;
        private Func<object> sourceFunc = null;

        public FactoryLifetimeManager(Func<object> sourceFunc, 
                                      LifetimeManager baseManager = null)
        {
            Contract.Requires(sourceFunc != null, "sourceFunc must be provided");
            this.sourceFunc = sourceFunc;
            this.baseManager = baseManager;
        }

        public override object GetValue()
        {
            object result = null;

            if (baseManager != null)
            {
                result = baseManager.GetValue();
            }

            if (result == null)
            {
                result = sourceFunc();

                if (baseManager != null)
                {
                    baseManager.SetValue(result);
                }
            }

            return result;
        }

        public override void RemoveValue()
        {
            if (baseManager != null)
            {
                baseManager.RemoveValue();
            }
        }

        public override void SetValue(object newValue)
        {
            if (baseManager != null)
            {
                baseManager.SetValue(newValue);
            }
        }
    }
}

