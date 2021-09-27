using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] protected GameObject ObjectType;
    [SerializeField] protected int MaxCountInPool;

    protected List<GameObject> Pool = new List<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < MaxCountInPool; i++)
        {
            InstantiateObject(ObjectType);
        }
    }

    protected void InstantiateObject(GameObject prefab)
    {
        GameObject createdObject = Instantiate(prefab, transform);
        InitializeObject(createdObject);
        Pool.Add(createdObject);
    }

    protected virtual void InitializeObject(GameObject prefab)
    {
        prefab.SetActive(false);
    }

    public bool TryGetObject(out GameObject result)
    {
        result = Pool.First(p => p.activeSelf == false);
        return result != null;
    }
}
