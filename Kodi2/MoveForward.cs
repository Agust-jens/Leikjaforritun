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
        transform.Translate(Vector3.forward * Time.deltaTime * speed); // translate �annig a� vi� getum f�rt �a� � �� �tt sem vi� vildum. Forward vi� �tlum a� f�ra �a� � �� �tt sem �a� v�sar.
                                                                       // deltatime �� �tlum vi� a� uppf�ra �a� me� t�manum � sta� �ess a� uppf�ra �a� � hverjum ramma. speed f� hreyfingu
    }
}
