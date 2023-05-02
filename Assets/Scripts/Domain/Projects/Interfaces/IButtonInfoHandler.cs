using UI.DevPage;
using UI.Global.Interfaces;

namespace Domain.Projects.Interfaces
{
    public interface IButtonInfoHandler
    {
        Project ButtonInfo { get; }

        void Initialize(Project buttonInfo);
    }
}