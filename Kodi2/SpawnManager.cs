using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs; // b�r til array af d�rum. array er til a� velja hversu m�rg gameobjects �a� eru
    private float spawnRangeX = 15;
    private float spawnPosZ = 20;
    private float startDelay = 2; // that way we know how long to wait  until we start spawning animals
    private float spawnInterval = 1.5f; // kalla a�fer�ina aftur � 1,5 sek�nda fresti
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval); // vi� munum �treka� kalla spawrandomanial() a�fer�ina fr� 2 sek�ndum og vi� munum kalla hana aftur � 1,5 sek�ndna fresti
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) //finnur �t ef �� �tir � S takkan � lyklabor�inu
        {
            SpawnRandomAnimal();
        }
    }
    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length); //velur random d�r � animal prefabs element. Getur l�ka sett n�mer 3 � sta�inn fyrir animalprefabs.lenght
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ); //topboundi� var set � 30 �� setjum vi� spawni� � 20

        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation); //n�r � d�rinn og finnur hvar �a� spawnar
    }
}
