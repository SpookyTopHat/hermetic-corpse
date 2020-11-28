using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave1 : MonoBehaviour
{
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        BulletManager.LoadBullets();
        EnemyManager.LoadEnemies();
        GameObject enm1 = Instantiate(EnemyManager.getPrefab("Skeleton"), new Vector2(0, 0), Quaternion.Euler(0, 180, 0));
        enm1.transform.SetParent(transform);
        StartCoroutine("SkeleShot", enm1);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount == 0)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator SkeleShot(GameObject enm) {
        while (enm) { 
            for (int i = 0; i <= 10; ++i)
            {
                BulletManager.Fire("Skele_Bullet", enm.transform.position, 90 + 360 * i / 10, 3);
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(2f);
        }
    }
}
