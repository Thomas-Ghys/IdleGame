using UnityEngine;

public interface IButtonInfo
{
    string Name { get; set; }
    int RequirementCurrent { get; set; }
    int RequirementTotal { get; set; }
    Color Color { get; set; }
}
