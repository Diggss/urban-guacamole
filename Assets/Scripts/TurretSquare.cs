using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSquare : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Color hoverColor;
    Vector3 pos = new Vector3(0f,-1.419999953f,0f);

    GameObject turret;
    Color startColor;
    // Start is called before the first frame update
    void Awake()
    {
        startColor = sr.color;
    }

    void OnMouseEnter() {
        sr.color = hoverColor;
    }

    void OnMouseExit() {
        sr.color = startColor;
    }

    void OnMouseDown() {
        if(turret != null) return;
        GameObject turretBuild = TurretSpawn.main.GetTurret();
        turret = Instantiate(turretBuild, transform.position, Quaternion.identity);
    }
}
