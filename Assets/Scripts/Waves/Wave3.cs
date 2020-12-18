using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave3 : Wave
{
    void OnEnable()
    {
        BulletManager.LoadBullets();
        EnemyManager.LoadEnemies();

        for (int i = 0; i < 6; ++i)
        {
            GameObject enm = Instantiate(EnemyManager.getPrefab("Skeleton"), new Vector2(-26 + 3f * i, 4 - 0.1f * i), Quaternion.identity);
            enm.transform.SetParent(transform);
            StartCoroutine("SkeleMove1", enm);
        }

        for (int i = 0; i < 6; ++i)
        {
            GameObject enm = Instantiate(EnemyManager.getPrefab("Skeleton"), new Vector2(26.5f - 3f * i, 3 - 0.1f * i), Quaternion.identity);
            enm.transform.SetParent(transform);
            StartCoroutine("SkeleMove2", enm);
        }
        StartCoroutine("Termination");
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    
    private IEnumerator SkeleMove1(GameObject enm)
    { 
        float moveTimer = 0;
        while (moveTimer < 3)
        {
            enm.transform.position += new Vector3(6f * Time.deltaTime, 0, 0);
            moveTimer += Time.deltaTime;
            yield return null;
        }
        StartCoroutine("SkeleShot", enm);
    }

    private IEnumerator SkeleMove2(GameObject enm)
    {
        float moveTimer = 0;
        while (moveTimer < 3)
        {
            enm.transform.position -= new Vector3(6f * Time.deltaTime, 0, 0);
            moveTimer += Time.deltaTime;
            yield return null;
        }
        StartCoroutine("SkeleShot", enm);
    }

    private IEnumerator SkeleShot(GameObject enm)
    {
        while (enm) {
            BulletManager.Fire("Skele_Bullet", enm.transform.position, -90, 3);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
