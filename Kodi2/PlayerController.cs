using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float HorizontalInput;
    public float speed = 10.0f; // hra�i af player
    public float xRange = 10.0f;

    public GameObject projectilePrefab; // vi� munum geyma object sj�lf, �� k�llum vi� �a� projectile svo a� vi� vitum a� �etta er prefab sem vi� �tlum a� henda s��ar
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xRange) // verra en -10 stoppar vinstri megin
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z); //stoppar player fara til vinstri svo hann fer ekki af mappinu
        }
        if (transform.position.x > xRange) // �a� er betra en 10 stoppar h�gra megin
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z); //stoppar player fara til h�gri svo hann fer ekki af mappinu
        }
        HorizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * HorizontalInput * Time.deltaTime * speed); //�a� veit a� �a� ver�ur j�kv�tt til neikv�tt og vi� �tlum a� tryggja a� �a� uppf�rir yfirvinnu og ekki hvern einasta ramma
                                                                                       //�a� kallar l�ka � speedi�

        if (Input.GetKeyDown(KeyCode.Space)) // tj�kkar ef �a� �tt � spacebar
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation); //instantiate b�r til obejcts sem er n� �egar til og l�tur �a� spawna projectile hj� sama sta� og playerinn me� prefab rotation
        }
    }
}
