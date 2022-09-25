using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPooler : MonoBehaviour
{
    public GameObject pooledObject;
    public int numberOfObjects;
    private List<GameObject> gameObjects;


    void Start()
    {
        gameObjects=new List<GameObject>();
        for(int i=0;i<numberOfObjects;i++)
        {
            GameObject gameObject = Instantiate(pooledObject);
            gameObject.SetActive(false);
            gameObjects.Add(gameObject);

        }
    }

    public GameObject GetPooledGameObject()
    {
        foreach(GameObject gameObject in gameObjects)
        {
            if(!gameObject.activeInHierarchy)
                return gameObject;
        }
        GameObject gameObj=Instantiate(pooledObject);
        gameObj.SetActive(false);
        gameObjects.Add(gameObj);
        return gameObj;

    }
    
}
