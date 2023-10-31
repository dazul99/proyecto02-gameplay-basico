using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_control : MonoBehaviour
{
    [SerializeField]private float sped = 10f;

    private float horizontalInput;

    private float xRange = 15f;

    [SerializeField] private GameObject foodPrefab;

    private void PlayerInBounds()
    {
        Vector3 pos = transform.position;

        if(pos.x < -xRange)
        {
            transform.position = new Vector3 (-xRange, pos.y, pos.z);
        }
        else if (pos.x > xRange)
        {
            transform.position = new Vector3(xRange, pos.y,pos.z);
        }
    }

    private void Shootfood()
    {
        Instantiate(foodPrefab, transform.position, Quaternion.identity);

    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(horizontalInput * sped * Time.deltaTime * Vector3.right);
        PlayerInBounds();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shootfood();
        }
    }
}
