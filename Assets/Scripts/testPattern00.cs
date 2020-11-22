using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPattern00 : MonoBehaviour
{
    int count = 0;
    float timer = 1f;
    GameObject bb;

    // Start is called before the first frame update
    void Start()
    {
        //BulletManager.LoadBullets("Bullets");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            for (int i = 0; i < 10; ++i) {
                float angle = 360f * i / 10f + 2 * count;
                BulletManager.Fire("Skele_Bullet", (Vector2)transform.position + new Vector2((count % 5) * Mathf.Cos(Mathf.Deg2Rad*angle), (count % 5) * Mathf.Sin(Mathf.Deg2Rad*angle)), angle + 45, 2f);
            }
            ++count;
            timer = 0.1f;
        }
    }
}
