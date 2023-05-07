using System;

namespace Domain.Projects.Interfaces
{
    public interface IButtonInfo
    {
        Guid Id { get; }
        string Name { get; set; }
    }
}