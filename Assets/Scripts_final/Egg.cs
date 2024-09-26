using UnityEngine;

public class Egg : MonoBehaviour
{
    private Rigidbody2D eggRigidbody;
    private int damage = 1;

    [SerializeField] private Transform ThrowStart;
    [SerializeField] private Vector2 throwDirection = new Vector3(0.5f, 0.5f, 0f);

    [SerializeField] private float eggForce;
    [SerializeField] private Rigidbody2D PlayerRb;
    private void Start()
    {

        eggRigidbody = GetComponent<Rigidbody2D>();
        if (eggRigidbody != null)
        {
            Vector2 playerVelocity = PlayerRb.velocity;

            Vector2 eggVelocity = (throwDirection.normalized * eggForce) + playerVelocity;

            eggRigidbody.AddForce(eggVelocity, ForceMode2D.Impulse);

            Vector3 arcThrowDirection = ThrowStart.forward + ThrowStart.up;

            Debug.Log("Adding force");
            //eggRigidbody.AddForce(throwDirection.normalized * eggForce, ForceMode2D.Impulse);

        }
        else
            Debug.Log("No force added");
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
