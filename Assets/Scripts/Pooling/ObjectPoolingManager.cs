using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPooling
{
	public class ObjectPoolingManager : MonoBehaviour
	{
		public static ObjectPoolingManager _instance { get; protected set; }
		public List<ObjectPool> _objectPools { get; protected set; }

		[Header("Object Pools Profiles")]
		public List<ObjectPoolProfile> objectPoolProfiles;


		bool poolsInitialised = false;

		private void Awake()
		{
			if (poolsInitialised == false)
				StartCoroutine(InitialisationRoutine());


			if (_instance == null)
				_instance = this;
			else
				Destroy(_instance);

		}


		IEnumerator InitialisationRoutine()
		{
			_objectPools = new List<ObjectPool>();

			GameObject poolsParent = new GameObject("pooledObjectContainer");
			for (int i = 0; i < objectPoolProfiles.Count; i++)
			{
				for (int j = 0; j < objectPoolProfiles[i].pools.Length; j++)

					_objectPools.Add(new ObjectPool(objectPoolProfiles[i].pools[j], poolsParent.transform));

			}


			yield return null;
			poolsInitialised = true;
		}

		private void OnDestroy()
		{
			_instance = null;
		}


		public static ObjectPool GetMatchingPool(GameObject prefab)
		{

			for (int j = 0; j < _instance._objectPools.Count; j++)
			{
				if (prefab.name.Equals(_instance._objectPools[j]._poolData.prefab.name))
					return _instance._objectPools[j];

			}

			return null;
		}

	}

}