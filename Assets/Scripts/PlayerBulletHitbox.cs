using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletHitbox : MonoBehaviour
{
    private PlayerController pc;
    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet")
            && !pc.IsIFrame)
        {
            pc.PhysicalHit(collision.gameObject.GetComponent<BulletScript>().damage);
            Destroy(collision.gameObject);
        }
    }
}
