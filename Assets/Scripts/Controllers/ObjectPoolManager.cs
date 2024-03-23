using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Controllers
{
    public class PooledObjectInfo
    {
        public string LookupString;
        public List<GameObject> InactiveObject = new List<GameObject>();
    }
    
    public class ObjectPoolManager : MonoBehaviour
    {
        public static List<PooledObjectInfo> ObjectPools = new List<PooledObjectInfo>();

        public static GameObject SpawnObject(GameObject objectToSpawn, Vector3 spawnPos, Quaternion spawnRotation)
        {
            PooledObjectInfo pool = ObjectPools.Find(p => p.LookupString == objectToSpawn.name);

            if (pool == null)
            {
                pool = new PooledObjectInfo() { LookupString = objectToSpawn.name };
                ObjectPools.Add(pool);
            }
            
            // Check if there are any inactive object in the pool
            GameObject spawnableObject = pool.InactiveObject.FirstOrDefault();

            if (spawnableObject == null)
            {
                spawnableObject = Instantiate(objectToSpawn, spawnPos, spawnRotation);
            }
            else
            {
                spawnableObject.transform.position = spawnPos;
                spawnableObject.transform.rotation = spawnRotation;
                pool.InactiveObject.Remove(spawnableObject);
                spawnableObject.SetActive(true);
            }

            return spawnableObject;
        }

        public static void ReturnObjectToPool(GameObject obj)
        {
            // Remove postfix "(Clone)"
            string fixedName = obj.name.Substring(0, obj.name.Length - 7);
            PooledObjectInfo pool = ObjectPools.Find(p => p.LookupString == fixedName);

            if (pool == null)
            {
                Debug.Log("This GameObject doesn't belong to any pool");
            }
            else
            {
                obj.SetActive(false);
                pool.InactiveObject.Add(obj);
            }
        }
    }
}