using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Common.Factory
{
    public abstract class EntityFactory<T> where T : ISpawnable<T>
    {
        public Transform CurrentSpawnPoint { get; private set; }
        private List<T> spawnables = new List<T>();
        
        public void Initialize(Transform spawnPoint)
        {
            CurrentSpawnPoint = spawnPoint;
        }
        
        /// <summary>
        /// Spawns an entity at current spawn point and returns it as type of Factory.
        /// </summary>
        /// <param name="spawnable"></param>
        /// <returns></returns>
        public virtual T Spawn(T spawnable)
        {
            T spawnedObject = spawnable.Spawn(CurrentSpawnPoint);
            spawnables.Add(spawnable);
            return spawnedObject;
        }
    
        public virtual void Despawn(T spawnable)
        {
            spawnable.Despawn();
            spawnables.Remove(spawnable);
        }
    
        public virtual void DespawnAll()
        {
            foreach (var spawnable in spawnables)
            {
                spawnable.Despawn();
            }
        
            spawnables.Clear();
        }
        
        public void ChangeSpawnPoint(Transform spawnPoint)
        {
            CurrentSpawnPoint = spawnPoint;
        }
    }
}
