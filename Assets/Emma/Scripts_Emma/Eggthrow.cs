using UnityEngine;

public class Eggthrow : MonoBehaviour
{
    [SerializeField] private GameObject _egg;
    [SerializeField] private Transform ThrowPointStart;

    [SerializeField] private float ThrowRate = 0.5f;

    [SerializeField] private float throwJourney = 1f;

    void Update()
    {
        Trowing();
    }

    private void Trowing()
    {

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > throwJourney)
        {
            ThrowRate = Time.time + ThrowRate;
            
            GameObject _throwInstance  = Instantiate(_egg, ThrowPointStart.position, Quaternion.identity);

            Debug.Log("Throwing");

        }
    }
}
