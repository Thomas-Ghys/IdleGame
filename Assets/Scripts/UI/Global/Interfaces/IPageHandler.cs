using Domain.Projects.Interfaces;

namespace UI.Global.Interfaces
{
    public interface IPageHandler
    {
        void InvokeButton(IButtonInfo buttonInfo);
        void CollapseAllPanels();
    }
}