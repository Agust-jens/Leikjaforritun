using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Weapon/Gun")]//n�r gun script
public class GunData : ScriptableObject
{

    [Header("Info")]
    public new string name;

    [Header("Shooting")]
    public float damage; //S�nir og getur breytt damage
    public float maxDistance;//S�nir og getur breytt distance af byssuk�luni

    [Header("Reloading")]
    public int currentAmmo;//S�nir og getur breytt hversu miki� ammo �� ert me�
    public int magSize; //S�nir og getur breytt hva� max ammo �� getur veri� me�
    [Tooltip("In RPM")] public float fireRate;
    public float reloadTime; //S�nir og getur breytt hversu hratt �� hle�ur byssuna
    [HideInInspector] public bool reloading;

}
