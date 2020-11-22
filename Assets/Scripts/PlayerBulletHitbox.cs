using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletHitbox : MonoBehaviour
{
    private CharacterController cc;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponentInParent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out BulletScript bs) 
            && !cc.isIFrame)
        {
            cc.PhysicalHit(bs.damage);
            Destroy(collision.gameObject);
        }
    }
}
