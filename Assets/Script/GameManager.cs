using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Object");

        for (int i = 0; i < allObjects.Length; i++)
        {
            for (int j = i + 1; j < allObjects.Length; j++)
            {
                Collider colA = allObjects[i].GetComponent<Collider>();
                Collider colB = allObjects[j].GetComponent<Collider>();

                if (colA != null && colB != null)
                {
                    Physics.IgnoreCollision(colA, colB, true);
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
