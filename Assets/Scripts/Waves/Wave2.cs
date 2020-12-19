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

        GameObject enm1 = Instantiate(EnemyManager.getPrefab("Skeleton"), new Vector2(-5, 6), Quaternion.identity);
        enm1.transform.SetParent(transform);
        StartCoroutine(SkeleShot1(enm1, -150));

        GameObject enm2 = Instantiate(EnemyManager.getPrefab("Skeleton"), new Vector2(5, 6), Quaternion.identity);
        enm2.transform.SetParent(transform);
        StartCoroutine(SkeleShot1(enm2, -30));

        GameObject enm3 = Instantiate(EnemyManager.getPrefab("Skeleton"), new Vector2(0, 6), Quaternion.identity);
        enm3.transform.SetParent(transform);
        StartCoroutine(SkeleShot1(enm3, -90));

        GameObject enm4 = Instantiate(EnemyManager.getPrefab("Golem"), new Vector2(-7, 4), Quaternion.identity);
        enm4.transform.SetParent(transform);
        StartCoroutine(GolemMove(enm4, true));

        GameObject enm5 = Instantiate(EnemyManager.getPrefab("Golem"), new Vector2(7, 4), Quaternion.identity);
        enm5.transform.SetParent(transform);
        StartCoroutine(GolemMove(enm5, false));

        StartCoroutine(Termination());
    }

    //Left flank shoots diagonally left, shots bounce
    //Right flank shoots diagonally right, shots bounce
    //Center shoots straight forward
    //I've done an evil thing here: used a tuple to store multiple params for input
    private IEnumerator SkeleShot1(GameObject enm, float angle)
    {
        float moveTimer = 0;
        while (moveTimer < 2)
        {
            enm.transform.position += new Vector3(0, -2.2f * Time.deltaTime, 0);
            moveTimer += Time.deltaTime;
            yield return null;
        }
        while (enm)
        { 
            StartCoroutine(BounceShot(BulletManager.Fire("Skele_Bullet", enm.transform.position, angle, 3)));
            yield return new WaitForSeconds(0.5f);
        }
    }
     
    private IEnumerator GolemMove(GameObject enm, bool left)
    {
        float timer = 0;
        while (timer < 3)
        {
            enm.transform.position += new Vector3((left ? 1 : -1) * 1.3f * Time.deltaTime, 0, 0);
            timer += Time.deltaTime;
            yield return null;
        }
        StartCoroutine(GolemShot(enm));
        while (enm)
        {
            enm.transform.position += new Vector3((left ? 1 : -1) * 1.3f * Time.deltaTime * -Mathf.Cos(timer), 0, 0);
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

        while (bullet && numBounces > 0)
        {
            
            if (bullet.transform.position.x < Boundaries.LeftWall || bullet.transform.position.x > Boundaries.RightWall)
            {
                bullet.transform.right = Vector3.Reflect(bullet.transform.right, new Vector2(1, 0));
                --numBounces;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
