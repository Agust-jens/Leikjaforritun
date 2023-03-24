using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs; // býr til array af dýrum. array er til að velja hversu mörg gameobjects það eru
    private float spawnRangeX = 15;
    private float spawnPosZ = 20;
    private float startDelay = 2; // that way we know how long to wait  until we start spawning animals
    private float spawnInterval = 1.5f; // kalla aðferðina aftur á 1,5 sekúnda fresti
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval); // við munum ítrekað kalla spawrandomanial() aðferðina frá 2 sekúndum og við munum kalla hana aftur á 1,5 sekúndna fresti
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) //finnur út ef þú ýtir á S takkan á lyklaborðinu
        {
            SpawnRandomAnimal();
        }
    }
    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length); //velur random dýr í animal prefabs element. Getur líka sett númer 3 í staðinn fyrir animalprefabs.lenght
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ); //topboundið var set í 30 þá setjum við spawnið í 20

        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation); //nær í dýrinn og finnur hvar það spawnar
    }
}
