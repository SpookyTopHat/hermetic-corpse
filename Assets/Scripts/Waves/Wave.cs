using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Wave : MonoBehaviour
{
    public virtual IEnumerator Termination()
    {
        yield return new WaitForSeconds(2f);
        while (transform.childCount > 0)
        {
            yield return new WaitForSeconds(0.5f);
        }
        BulletManager.ClearBullets();
        Destroy(gameObject);
    }
}
