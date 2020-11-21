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
        bb = (GameObject) Resources.Load("Bullets/BallBoring");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            for (int i = 0; i < 10; ++i) {
                BulletMovement.fire(bb, transform.position, new Vector2(Mathf.Cos(2*Mathf.PI/10*i), Mathf.Sin(2*Mathf.PI/10*i)));
            }
            timer = 3f;
        }
    }
}
