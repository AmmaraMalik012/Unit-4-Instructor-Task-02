using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Over_Time : MonoBehaviour
{
    public float destroyTimer = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    // Update is called once per frame
    

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(destroyTimer);
        Destroy(gameObject);
    }
}
