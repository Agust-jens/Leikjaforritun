using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed); // translate þannig að við getum fært það í þá átt sem við vildum. Forward við ætlum að færa það í þá átt sem það vísar.
                                                                       // deltatime þá ætlum við að uppfæra það með tímanum í stað þess að uppfæra það í hverjum ramma. speed fá hreyfingu
    }
}
