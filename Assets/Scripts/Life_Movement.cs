using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_Movement : MonoBehaviour
{
    float x, y, z;
    void Update () {
        
        x += Time.deltaTime * 50;
        y += Time.deltaTime * 50;
        z += Time.deltaTime * 50;
        transform.rotation = Quaternion.Euler(x,y,z);

    }
}
