using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour {

    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;
    [SerializeField] private Transform vfxHitBlood;
    [SerializeField] AudioSource enemyHit;

    private Rigidbody bulletRigidbody;

    private void Awake() {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Start() {
        float speed = 50f;
        bulletRigidbody.velocity = transform.forward * speed;

        Destroy(gameObject,0.7f);
    }

    private void OnTriggerEnter(Collider other) {
       
        if (other.GetComponent<BulletTarget>() != null) {
            // Hit target
            Instantiate(vfxHitGreen, transform.position, Quaternion.identity);

        }
        else if (other.GetComponent<Mine>() != null)
        {
            if (!other.GetComponent<BoxCollider>().isTrigger)
            {
                Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
                other.GetComponent<Mine>().Hit();
            }
            
        }

        else if (other.GetComponent<Enemy>() != null)
        {
            Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
            Instantiate(vfxHitBlood, transform.position, Quaternion.identity);
            enemyHit.pitch = (Random.Range(0.8f, 1.1f));
            enemyHit.Play();



            other.GetComponent<Enemy>().Hit();
        }

        else 
        
        {
            
            // Hit something else
            Instantiate(vfxHitRed, transform.position, Quaternion.identity);
        }
        Destroy(this);
        Destroy(gameObject,0.2f);
    }

}