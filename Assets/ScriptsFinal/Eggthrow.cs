using UnityEngine;

public class Eggthrow : MonoBehaviour
{
    [SerializeField] private GameObject _egg;
    
    [SerializeField] private Transform ThrowPointStart;

    [SerializeField] private float throwRate;

    [SerializeField] private float nextThrow;

    [SerializeField] private int eggCount = 12;

    void Update()
    {
        if (eggCount == 0)
        {
            Debug.Log("Out of eggs");
            return;
        }

        Trowing();        
    }

    private void EggCounter(int eggS)
    {
        eggCount += eggS;
    }

    private void Trowing()
    {

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextThrow)
        {
            EggCounter(-1);

            nextThrow = Time.time + throwRate;
            
            GameObject _throwInstance  = Instantiate(_egg, ThrowPointStart.position, Quaternion.identity);

            Debug.Log(eggCount);

        }
    }
}
