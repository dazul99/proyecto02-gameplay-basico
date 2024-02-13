using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_control : MonoBehaviour
{
    [SerializeField]private float sped = 10f;

    private float horizontalInput;

    private float xRange = 15f;

    [SerializeField] private GameObject foodPrefab;

    private bool gamestarted = false;
    private int gamemode = 1;

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
        Instantiate(foodPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Quaternion.identity);
        if(gamemode == 3)
        {
            Instantiate(foodPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Quaternion.Euler(0,-45,0));
            Instantiate(foodPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Quaternion.Euler(0, 45, 0));
        }
    }

    void Update()
    {
        if (gamestarted)
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

    public void GameStart(int hell)
    {
        gamestarted = true;
        gamemode= hell;
    }

}
