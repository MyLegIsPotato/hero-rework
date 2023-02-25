using UnityEngine;

namespace Project.Common.Factory
{
    public interface ISpawnable
    {
        void Spawn(Transform spawnPoint);
        void Despawn();
    }
}
