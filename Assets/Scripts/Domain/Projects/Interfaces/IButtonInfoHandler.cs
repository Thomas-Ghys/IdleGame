namespace Domain.Projects.Interfaces
{
    public interface IButtonInfoHandler
    {
        IButtonInfo ButtonInfo { get; }

        void Initialize(IButtonInfo buttonInfo);
    }
}