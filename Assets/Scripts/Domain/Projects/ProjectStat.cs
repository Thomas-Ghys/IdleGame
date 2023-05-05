using System;
using Domain.Common;

namespace Domain.Projects
{
    public class ProjectStat
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public MeasurementTypes MeasurementType { get; set; }
        public double Value { get; set; }
    }
}