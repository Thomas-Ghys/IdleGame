using System;
using Domain.Common;
using Domain.Projects.Interfaces;

namespace Domain.Projects
{
    public class ProjectStat : IButtonInfo
    {
        public ProjectStat(string name, double value, MeasurementTypes measurementType)
        {
            Id = Guid.NewGuid();
            Name = name;
            Value = value;
            MeasurementType = measurementType;
        }

        public Guid Id { get; private set; }
        public string Name { get; set; }
        public MeasurementTypes MeasurementType { get; set; }
        public double Value { get; set; }

        public ProjectStat CloneWithNewId()
        {
            return new ProjectStat(Name, Value, MeasurementType);
        }
    }
}