using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour { 
    // Update is called once per frame
    void Update()
    {
        // Sn��u leikhlutnum sem �etta script er tengt vi� 15 inn � X axis,
        // 30 inn � Y axis og 45 inn � Z axis, margfalda�u me� deltaTime til a� gera �a� � sek�ndu frekar en � hvern frame.
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
