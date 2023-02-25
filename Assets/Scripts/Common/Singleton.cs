using UnityEngine;

namespace Project.Common.Patterns
{
    [DisallowMultipleComponent]
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        protected static T instance;

        public static T Instance
        {
            get
            {
                if (instance is null)
                    Debug.LogError("Instance of " + typeof(T) +
                                   " singleton not initialized yet! Can't acces!. Please add it to the scene.");
                return instance;
            }
        }

        public static bool HasInstance => Instance;

        protected virtual void Awake()
        {
            if (!(instance is null))
            {
                if (instance != this)
                {
                    Destroy(gameObject);
                }
                return;
            }
            instance = (T)this;
            Initialize();
        }

        protected virtual void OnDestroy()
        {
            if (instance == this)
            {
                instance = null;
            }
        }

        protected virtual void Initialize()
        {
            if (instance.transform.parent)
            {
                return;
            }
        }
    }
}