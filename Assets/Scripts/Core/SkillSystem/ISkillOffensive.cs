using Project.Core.EnemiesSystem;

namespace Project.Core.SkillSystem
{
    public interface ISkillOffensive
    {
        IDamaging DamagingObject { get; }
    }
}