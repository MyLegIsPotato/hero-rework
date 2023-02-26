using UnityEngine;

namespace Project.Common.Factory
{
    public interface ISpawnable<T>
    {
        T Spawn(Transform spawnPoint);
        void Despawn();
    }
}
