using UI.DevPage;
using UI.Global;

namespace Domain.Projects.Interfaces
{
    public interface IButtonInfoHandler
    {
        IButtonInfo ButtonInfo { get; }
        IPageHandler PageHandler { get; }

        void Initialize(IButtonInfo buttonInfo, DevPageHandler devPageHandler);
    }
}