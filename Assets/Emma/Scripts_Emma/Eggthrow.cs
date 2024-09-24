using UnityEngine;

public class Eggthrow : MonoBehaviour
{
    [SerializeField] private GameObject _egg;
    [SerializeField] private Transform ThrowPointStart;

    [SerializeField] private float throwRate = 0.5f;

    [SerializeField] private float nextThrow = 0.5f;

    void Update()
    {
        Trowing();
    }

    private void Trowing()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextThrow)
        {
            nextThrow = Time.time + throwRate;
            
            GameObject _throwInstance  = Instantiate(_egg, ThrowPointStart.position, Quaternion.identity);

            Debug.Log("Throwing");
        }
    }
}
