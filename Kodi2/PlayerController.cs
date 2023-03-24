using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float HorizontalInput;
    public float speed = 10.0f; // hraði af player
    public float xRange = 10.0f;

    public GameObject projectilePrefab; // við munum geyma object sjálf, þá köllum við það projectile svo að við vitum að þetta er prefab sem við ætlum að henda síðar
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
        if (transform.position.x > xRange) // það er betra en 10 stoppar hægra megin
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z); //stoppar player fara til hægri svo hann fer ekki af mappinu
        }
        HorizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * HorizontalInput * Time.deltaTime * speed); //það veit að það verður jákvætt til neikvætt og við ætlum að tryggja að það uppfærir yfirvinnu og ekki hvern einasta ramma
                                                                                       //það kallar líka á speedið

        if (Input.GetKeyDown(KeyCode.Space)) // tjékkar ef það ýtt á spacebar
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation); //instantiate býr til obejcts sem er nú þegar til og lætur það spawna projectile hjá sama stað og playerinn með prefab rotation
        }
    }
}
