using MainContents.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace MainContents
{
    public class MainContentsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var _regionManager = containerProvider.Resolve<IRegionManager>();
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(Views.MainContents));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}