using UnityEngine;

public class Egg : MonoBehaviour
{
    private Rigidbody2D eggRigidbody;

    [SerializeField] private Transform ThrowStart;

    [SerializeField] private float eggForce = 0.3f;

    [SerializeField] private Vector3 throwDirection = new Vector3(1f, 1f, 0f);  // Direction of the throw

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
}
