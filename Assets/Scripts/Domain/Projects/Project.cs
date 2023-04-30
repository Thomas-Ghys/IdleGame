using Domain.Projects.Interfaces;
using UnityEngine;

namespace Domain.Projects
{
    public class Project: IButtonInfo
    {
        public Project(string name, int requirementCurrent, int requirementTotal, Color color)
        {
            Name = name;
            RequirementCurrent = requirementCurrent;
            RequirementTotal = requirementTotal;
            Color = color;
        }
    
        public string Name { get; set; }
        public int RequirementCurrent { get; set; }
        public int RequirementTotal { get; set; }
        public Color Color { get; set; }
    }
}