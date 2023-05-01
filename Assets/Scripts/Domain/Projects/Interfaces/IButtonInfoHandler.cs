using UI.DevPage;
using UI.DevPage.NewProjectsPage;
using UI.Global;
using UI.Global.Interfaces;

namespace Domain.Projects.Interfaces
{
    public interface IButtonInfoHandler
    {
        IButtonInfo ButtonInfo { get; }
        IPageHandler PageHandler { get; }

        void Initialize(IButtonInfo buttonInfo, DevPageHandler devPageHandler);
    }
}