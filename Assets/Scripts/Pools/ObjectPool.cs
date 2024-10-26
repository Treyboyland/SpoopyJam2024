using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField]
    protected bool canGenerateMore;

    [SerializeField]
    protected int initialCount;

    [SerializeField]
    protected T objectToGenerate;

    protected List<T> pool = new List<T>();

    // Start is called before the first frame update
    protected void Start()
    {
        for (int i = 0; i < initialCount; i++)
        {
            CreateObject();
        }
    }

    protected virtual T CreateObject()
    {
        var newObject = Instantiate(objectToGenerate, transform);
        newObject.gameObject.SetActive(false);
        pool.Add(newObject);
        return newObject;
    }

    public T GetObject()
    {
        foreach (var item in pool)
        {
            if (!item.gameObject.activeInHierarchy)
            {
                return item;
            }
        }

        return canGenerateMore ? CreateObject() : null;
    }
}