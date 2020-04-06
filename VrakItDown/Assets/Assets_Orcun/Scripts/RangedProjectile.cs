using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 15;
    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask whatIsSolid;
    //public GameObject destroyEffect;
    void Start()
    {
        //destroying projectile after lifeTime
        Invoke(nameof(DestroyProjectile), lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        //invisible ray to detect enemy&wall collider
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                //hit dmg
                hitInfo.collider.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
            //Going be destroyed anyway
            DestroyProjectile();
        }
        //calculating where to fly
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        //adding a destroy effect
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
