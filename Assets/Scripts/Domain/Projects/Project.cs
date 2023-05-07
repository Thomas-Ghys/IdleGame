using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Common;
using Domain.Projects.Interfaces;
using UnityEngine;

namespace Domain.Projects
{
    public class Project : IButtonInfo
    {
        public Project(string name, IProjectRequirement projectRequirement, Color color)
        {
            Id = Guid.NewGuid();
            Name = name;
            ProjectRequirement = projectRequirement;
            Color = color;
            Stats = new List<ProjectStat>();
        }

        public Guid Id { get; private set; }
        public string Name { get; set; }
        public IProjectRequirement ProjectRequirement { get; set; }
        public Color Color { get; set; }
        public TimeSpan TimeActive { get; set; }
        public string TimeActiveAsString => TimeFormatter.FormatForButton(TimeActive);
        public IEnumerable<ProjectStat> Stats { get; set; }

        public Project CloneWithNewId()
        {
            return new Project(Name, ProjectRequirement.Clone(), Color)
            {
                Id = Guid.NewGuid(),
                Stats = Stats.Select(p => p.CloneWithNewId())
            };
        }
    }
}