using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPattern00 : MonoBehaviour
{

    float timer = 3f;
    GameObject bb;

    // Start is called before the first frame update
    void Start()
    {
        BulletManager.LoadBullets("Bullets");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            for (int i = 0; i < 10; ++i) {
                BulletManager.Fire("BallBoring", transform.position, 360f*i/10f, 2f);
            }

            timer = 3f;
        }
    }
}
