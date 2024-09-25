using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggUpdate : MonoBehaviour
{
    private Rigidbody2D eggRigidbody;

    [SerializeField] private Transform ThrowStart;

    [SerializeField] private float eggForce = 0.3f;

    [SerializeField] private Vector3 throwDirection = new Vector3(1f, 1f, 0f);  // Direction of the throw
    
    // agnes test
     public int damage = 1;
     //

    private void Start()
    {
        eggRigidbody = GetComponent<Rigidbody2D>();
        if (eggRigidbody != null)
        {
            Debug.Log("Rigidbody found. Applying force...");

            Vector3 arcThrowDirection = ThrowStart.forward + ThrowStart.up;
            eggRigidbody.AddForce(throwDirection.normalized * eggForce, ForceMode2D.Impulse);
        }

        else
        {
            Debug.Log("Rigidbody not found...");
        }

    }
    void Update()
    {
        //transform.position += transform.right * Time.deltaTime * eggForce;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(this.gameObject, 2);

            Debug.Log("Hit: " +  other.tag);

        }
    }
    // agnes test
    void OnCollisionEnter2D(Collision2D collision){
        if (collision.collider.tag == "Enemy")
        {
            collision.collider.gameObject.GetComponent<Enemy>().Damage(damage);
            Destroy(gameObject);
        }
    }
    //
}







