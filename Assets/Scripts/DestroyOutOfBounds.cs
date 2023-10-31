using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] private float topBound = 25f;
    [SerializeField] private float botBound = -5f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z >= topBound)
        {
            Destroy(gameObject);
        }

        else if(transform.position.z <= botBound) 
        { 
            Destroy(gameObject); 
        }

    }
}
