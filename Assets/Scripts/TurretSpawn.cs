using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawn : MonoBehaviour
{
    public static TurretSpawn main;

    [SerializeField] GameObject[] turretType;
    int turretIndex = 0;

    void Awake()
    {
        main = this;
    }

    public GameObject GetTurret()
    {
        return turretType[turretIndex];
    }
}
