using Domain.Projects.Interfaces;

namespace Domain.Projects
{
    public class ProjectFractionRequirement : IProjectRequirement
    {
        public ProjectFractionRequirement(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public int Numerator { get; }
        public int Denominator { get; }

        public IProjectRequirement Clone()
        {
            return new ProjectFractionRequirement(Numerator, Denominator);
        }
    }
}