using UnityEngine;

public class Egg : MonoBehaviour
{
    private Rigidbody2D eggRigidbody;
    private int damage = 1;
    

    [SerializeField] private Transform ThrowStart;
    [SerializeField] private float eggForce = 0.3f;
    [SerializeField] private Vector3 throwDirection = new Vector3(0.5f, 0.5f, 0f);

    private void Start()
    {

        eggRigidbody = GetComponent<Rigidbody2D>();
        if (eggRigidbody != null)
        {
            Vector3 arcThrowDirection = ThrowStart.forward + ThrowStart.up;
            eggRigidbody.AddForce(throwDirection.normalized * eggForce, ForceMode2D.Impulse);
        }
    }
   
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            collision.collider.gameObject.GetComponent<Enemy>().Damage(damage);

            Destroy(gameObject, 0.1f);
        }

        else
        {
            Destroy(gameObject, 0.1f);
            Debug.Log(collision.gameObject.name);
        }
               
    }
}
