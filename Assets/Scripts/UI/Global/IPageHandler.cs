using Domain.Projects.Interfaces;

namespace UI.Global
{
    public interface IPageHandler
    {
        void InvokeButton(IButtonInfo buttonInfo);
        void CollapseAllPanels();
    }
}