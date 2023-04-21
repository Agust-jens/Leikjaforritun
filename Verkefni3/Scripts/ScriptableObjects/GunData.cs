using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Weapon/Gun")]//nær gun script
public class GunData : ScriptableObject
{

    [Header("Info")]
    public new string name;

    [Header("Shooting")]
    public float damage; //Sýnir og getur breytt damage
    public float maxDistance;//Sýnir og getur breytt distance af byssukúluni

    [Header("Reloading")]
    public int currentAmmo;//Sýnir og getur breytt hversu mikið ammo þú ert með
    public int magSize; //Sýnir og getur breytt hvað max ammo þú getur verið með
    [Tooltip("In RPM")] public float fireRate;
    public float reloadTime; //Sýnir og getur breytt hversu hratt þú hleður byssuna
    [HideInInspector] public bool reloading;

}
