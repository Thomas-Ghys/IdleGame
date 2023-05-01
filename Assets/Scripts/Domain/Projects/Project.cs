using System;
using UnityEngine;

namespace Domain.Projects
{
    public class Project
    {
        public Project(string name, int requirementCurrent, int requirementTotal, Color color)
        {
            Id = Guid.NewGuid();
            Name = name;
            RequirementCurrent = requirementCurrent;
            RequirementTotal = requirementTotal;
            Color = color;
        }

        public Guid Id { get; private set; }
        public string Name { get; set; }
        public int RequirementCurrent { get; set; }
        public int RequirementTotal { get; set; }
        public Color Color { get; set; }
    }
}