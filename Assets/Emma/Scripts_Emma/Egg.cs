using UnityEngine;

public class Egg : MonoBehaviour
{
    public float throwForce = 1f;

    public float upForce = 1f;

    void Update()
    {
        transform.position += transform.right * Time.deltaTime * throwForce;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {          
            Destroy(this.gameObject, 2);

        }


    }
}
