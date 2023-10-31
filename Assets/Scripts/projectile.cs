using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class projectile : MonoBehaviour
{
    [SerializeField] private float sped = 20f;

    void Update()
    {
        transform.Translate(sped * Vector3.forward * Time.deltaTime);
        
    }
}
