using Patterns.Singletons;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns
{
    public class Pool : SingletonMonoBehaviour<Pool>
    {
        [SerializeField]
        private GameObject _objectToPool;
        [SerializeField]
        private int _amountToPool = 0;
        private List<GameObject> _pooledObjects;

        public List<GameObject> PooledObjects { get { return _pooledObjects; } private set { _pooledObjects = value; } }
        public int AmountToPool { get { return _amountToPool; } }

        protected override void OnAwake()
        {
            base.OnAwake();

            _pooledObjects = new List<GameObject>();
            for (int i = 0; i < _amountToPool; ++i)
            {
                GameObject go = Instantiate(_objectToPool);
                go.SetActive(false);
                _pooledObjects.Add(go);
            }
        }

        public GameObject GetPooledObject()
        {
            for (int i = 0; i < _amountToPool; ++i)
            {
                if (!_pooledObjects[i].activeInHierarchy)
                {
                    GameObject go = _pooledObjects[i];
                    return go;
                }
            }

            return null;
        }
    }
}
