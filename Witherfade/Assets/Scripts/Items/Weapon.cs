using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Objects/Item/Weapon")]
public class Weapon : ScriptableObject
{
    public GameObject model;
    [Range(1, 10)] int weaponDmg;
    [Range(0, 3)] float attackRate;
    [Range(1, 50)] int weaponRange;
}
