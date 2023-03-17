using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour { 
    // Update is called once per frame
    void Update()
    {
        // Snúðu leikhlutnum sem þetta script er tengt við 15 inn í X axis,
        // 30 inn í Y axis og 45 inn í Z axis, margfaldaðu með deltaTime til að gera það á sekúndu frekar en á hvern frame.
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
