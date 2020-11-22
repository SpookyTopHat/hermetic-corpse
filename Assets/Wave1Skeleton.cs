using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave1Skeleton : MonoBehaviour
{
    private float timer = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            BulletManager.Fire("Skele_Bullet", transform.position, 270f, 5);
            timer = 1f;
        }
    }
}
