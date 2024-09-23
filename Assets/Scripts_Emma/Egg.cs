using UnityEngine;

public class Egg : MonoBehaviour
{
    public float throwForce = 1f;

    //public int Damage = 1;

    void Update()
    {

        transform.position += transform.right * Time.deltaTime * throwForce;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit: " + collision.tag);

        Destroy(this.gameObject);
    }
}
