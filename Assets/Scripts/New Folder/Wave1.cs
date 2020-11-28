using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave1 : MonoBehaviour
{
    [SerializeField]
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        BulletManager.LoadBullets();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            StartCoroutine("TestShot");
            timer = 0;
        }
    }

    IEnumerator TestShot() {
        for(int i = 0; i <= 10; ++i)
        {
            BulletManager.Fire("Skele_Bullet", new Vector2(0, 0), 90 + 360 * i / 10, 3);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
