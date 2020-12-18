using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave1 : Wave
{
    void OnEnable()
    {
        BulletManager.LoadBullets();
        EnemyManager.LoadEnemies();
        GameObject enm1 = Instantiate(EnemyManager.getPrefab("Skeleton"), new Vector2(0, 6), Quaternion.identity);
        enm1.transform.SetParent(transform);
        GameObject enm2 = Instantiate(EnemyManager.getPrefab("Skeleton"), new Vector2(-2, 8), Quaternion.identity);
        enm2.transform.SetParent(transform);
        GameObject enm3 = Instantiate(EnemyManager.getPrefab("Skeleton"), new Vector2(2, 8), Quaternion.identity);
        enm3.transform.SetParent(transform);
        StartCoroutine("SkeleShot", enm1);
        StartCoroutine("SkeleShot", enm2);
        StartCoroutine("SkeleShot", enm3);
        StartCoroutine("Termination");
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    //Defines Enemy Behavior
    private IEnumerator SkeleShot(GameObject enm)
    {
        float moveTimer = 0;
        while (moveTimer < 2)
        {
            enm.transform.position += new Vector3(0, -2.2f * Time.deltaTime, 0);
            moveTimer += Time.deltaTime;
            yield return null;
        }
        while (enm) { 
            BulletManager.Fire("Skele_Bullet", enm.transform.position, -90, 3);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
