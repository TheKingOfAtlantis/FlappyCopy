using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Followed: https://www.raywenderlich.com/847-object-pooling-in-unity#toc-anchor-003


[System.Serializable]
public class ObjectPoolItem
{
    public GameObject template;      // The template used to instantiate new game objects
    public int poolSize = 1;       // The size of the pool
    public bool expandable = true; // Whether the pool can dynamically allocate new game objects if needed
}

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    
    public List<ObjectPoolItem> poolItems; // The template used to instantiate new game objects
    public List<GameObject> pool;      // The pool which contains the game objects


    private void Awake() => Instance = this;

    // Use this for initialization
    void Start()
    {
        pool = new List<GameObject>();
        foreach(ObjectPoolItem item in poolItems)
        {
            for(int i = 0; i < item.poolSize; i++)
                createInstance(item.template);
        }
    }

    GameObject createInstance(GameObject template)
    {
        GameObject instance = Instantiate(template);
        instance.SetActive(false);
        pool.Add(instance);
        return instance;
    }

    /*
     * @brief Returns an inactive pooled object if avaliable (else null)
     */
    public GameObject GetObject(string tag)
    {
        // First we check if already have an object with that tag which is not being used
        // If we can't find one check if we can expand that list for the given tag

        foreach(GameObject instance in pool)
            // Return the first object which is not active in the hierarchy
            // That matches the given tag
            if(!instance.activeInHierarchy && instance.tag == tag)
                return instance;

        // If no free objects avaliable => Check if we can expand
        // If so create a new object and return that
        // Else return null

        foreach (ObjectPoolItem item in poolItems)
            if(item.template.tag == tag && item.expandable)
                return createInstance(item.template);

        return null;
    }


    public void restPool()
    {
        foreach (GameObject obj in pool)
            obj.SetActive(false);
    }

}
