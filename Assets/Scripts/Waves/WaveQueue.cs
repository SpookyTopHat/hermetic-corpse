using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveQueue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount > 0)
        {
            if (!(transform.GetChild(0).gameObject.activeInHierarchy)) {
                transform.GetChild(0).gameObject.SetActive(true) ;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
