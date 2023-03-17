using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; //reference player gameobject position
    private Vector3 offset; //store offsett value
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate() //þetta mun runna eftir allt hinn updateinn er buinn
    {
        transform.position = player.transform.position + offset; 
    }
}
