using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave2 : Wave
{
    private Camera mainCam;
    // Start is called before the first frame update
    void OnEnable ()
    {
        mainCam = FindObjectOfType<Camera>();//This assumes that the main camera is the only camera in play - a dangerous assumption
        BulletManager.LoadBullets();
        EnemyManager.LoadEnemies();
        (GameObject, float) d; // A tuple i'm using to pass multiple parameters to SkeleShot1. It represents the game object
        (GameObject, bool) t;

        GameObject enm1 = Instantiate(EnemyManager.getPrefab("Skeleton"), new Vector2(-5, 6), Quaternion.identity);
        enm1.transform.SetParent(transform);
        StartCoroutine("SkeleShot1", d = (enm1, -150));

        GameObject enm2 = Instantiate(EnemyManager.getPrefab("Skeleton"), new Vector2(5, 6), Quaternion.identity);
        enm2.transform.SetParent(transform);
        StartCoroutine("SkeleShot1", d = (enm2, -30));

        GameObject enm3 = Instantiate(EnemyManager.getPrefab("Skeleton"), new Vector2(0, 6), Quaternion.identity);
        enm3.transform.SetParent(transform);
        StartCoroutine("SkeleShot1", d = (enm3, -90));

        GameObject enm4 = Instantiate(EnemyManager.getPrefab("Golem"), new Vector2(-7, 4), Quaternion.identity);
        enm4.transform.SetParent(transform);
        StartCoroutine("GolemMove", t = (enm4, true));

        GameObject enm5 = Instantiate(EnemyManager.getPrefab("Golem"), new Vector2(7, 4), Quaternion.identity);
        enm5.transform.SetParent(transform);
        StartCoroutine("GolemMove", t = (enm5, false));

        StartCoroutine("Termination");
    }

    //Left flank shoots diagonally left, shots bounce
    //Right flank shoots diagonally right, shots bounce
    //Center shoots straight forward
    //I've done an evil thing here: used a tuple to store multiple params for input
    private IEnumerator SkeleShot1((GameObject enm, float angle) tuple)
    {
        float moveTimer = 0;
        while (moveTimer < 2)
        {
            tuple.enm.transform.position += new Vector3(0, -2.2f * Time.deltaTime, 0);
            moveTimer += Time.deltaTime;
            yield return null;
        }
        while (tuple.enm)
        { 
            StartCoroutine("BounceShot", BulletManager.Fire("Skele_Bullet", tuple.enm.transform.position, tuple.angle, 3));
            yield return new WaitForSeconds(0.5f);
        }
    }
     
    private IEnumerator GolemMove((GameObject enm, bool left) t)
    {
        float timer = 0;
        while (timer < 3)
        {
            t.enm.transform.position += new Vector3((t.left ? 1 : -1) * 1.3f * Time.deltaTime, 0, 0);
            timer += Time.deltaTime;
            yield return null;
        }
        StartCoroutine("GolemShot", t.enm);
        while (t.enm)
        {
            t.enm.transform.position += new Vector3((t.left ? 1 : -1) * 1.3f * Time.deltaTime * -Mathf.Cos(timer), 0, 0);
            timer += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator GolemShot(GameObject enm)
    {
        while (enm)
        {
            BulletManager.Fire("Golem_Bullet", enm.transform.position, -90, 2);
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator BounceShot(GameObject bullet)
    {
        int numBounces = 1;
        Vector2 viewBouncer;
        while (bullet && numBounces > 0)
        {
            viewBouncer = mainCam.WorldToViewportPoint(bullet.transform.position);
            if (viewBouncer.x < 0)
            {
                bullet.transform.right = Vector3.Reflect(bullet.transform.right, new Vector2(1, 0));
                --numBounces;
            }
            else if (viewBouncer.x > 1)
            {
                bullet.transform.right = Vector3.Reflect(bullet.transform.right, new Vector2(-1, 0));
                --numBounces;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
