using UI.DevPage;
using UI.Global;

namespace Domain.Projects.Interfaces
{
    public interface IButtonInfoHandler
    {
        IButtonInfo ButtonInfo { get; }
        
        // TODO: Sambar: Later, make this generic so other handlers can be used to reference back.
        IPageHandler DevPageHandler { get; }

        void Initialize(IButtonInfo buttonInfo, DevPageHandler devPageHandler);
    }
}