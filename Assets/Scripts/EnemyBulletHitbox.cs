using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletHitbox : MonoBehaviour
{
    private EnemyController ec;
    // Start is called before the first frame update
    void Start()
    {
        ec = GetComponentInParent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Hit");
        if (collision.gameObject.layer == LayerMask.NameToLayer("PlayerAttack"))
        {
            ec.PhysicalHit(collision.gameObject.GetComponent<BulletScript>().damage);
            Destroy(collision.gameObject);
        }
    }
}
