using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] animalsArray;
    private int animalindex;
    private int animalposition;
    private int prob;

    private float spawnposz = 20f;
    private float spawnrangex = 15f;

    [SerializeField] private float startdelay = 2f;
    private float spawninterval;


    private void Start()
    {
        
    }

    private void Spawnanimal()
    {
        animalindex = Random.Range(0, animalsArray.Length);
        Instantiate(animalsArray[animalindex], RandomAnimalPos(), Quaternion.Euler(0, 180, 0));
    }

    private Vector3 RandomAnimalPos()
    {
        float randomX = Random.Range(-spawnrangex, spawnrangex);
        return new Vector3(randomX, 0, spawnposz);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Spawn(float inter)
    {
        spawninterval = inter;
        InvokeRepeating("Spawnanimal", startdelay, spawninterval);
    }

}
