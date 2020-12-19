using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletHitbox : MonoBehaviour
{
    private PlayerController pc;
    private Material mt;
    private Color[] hitboxColors;
    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponentInParent<PlayerController>();
        mt = GetComponent<MeshRenderer>().material;
        hitboxColors = new Color[] {Color.black, Color.red, Color.yellow, Color.green};
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
            mt.color = hitboxColors[pc.getHealth()];
            Destroy(collision.gameObject);
        }
    }
}
