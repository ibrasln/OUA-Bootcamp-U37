using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Manager
{
    using Player;

    public class ObjectPoolManager : MonoBehaviour
    {
        public static ObjectPoolManager instance;

        #region Tooltip
        [Tooltip("Populate this array with prefabs that you want to add to the pool, and specify the number of gameobjects to be created for each.")]
        #endregion
        [SerializeField] private Pool[] poolArray = null;

        private Dictionary<string, Queue<GameObject>> poolDictionary = new();

        [System.Serializable]
        public struct Pool
        {
            public string name;
            public int poolSize;
            public GameObject prefab;
        }

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            for (int i = 0; i < poolArray.Length; i++)
            {
                CreatePool(poolArray[i].poolSize, poolArray[i].prefab);
            }
        }

        private void CreatePool(int poolSize, GameObject prefab)
        {
            string name = prefab.name;

            poolDictionary.Add(name, new Queue<GameObject>());

            for (int i = 0; i < poolSize; i++)
            {
                GameObject go = Instantiate(prefab, transform);
                go.SetActive(false);
                poolDictionary[name].Enqueue(go);
            }
        }

        public GameObject GetObjectFromPool(string poolName)
        {
            if (poolDictionary.ContainsKey(poolName))
            {
                GameObject go = poolDictionary[poolName].Dequeue();
                go.SetActive(true);

                poolDictionary[poolName].Enqueue(go);
                
                return go;
            }
            return null;
        }
    }
}
