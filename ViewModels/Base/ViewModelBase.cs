
using CommunityToolkit.Mvvm.ComponentModel;
using System.Security.AccessControl;

namespace Game.ViewModels.Base
{
    public abstract class ViewModelBase: ObservableObject
    {
        protected ViewModelBase() 
        {

        }

        public virtual Task InitialiseAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
    }
}
