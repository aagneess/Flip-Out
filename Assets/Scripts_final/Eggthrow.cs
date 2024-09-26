using UnityEngine;

public class Eggthrow : MonoBehaviour
{

    [SerializeField] private GameObject _egg;
    
    [SerializeField] private Transform ThrowPointStart;

    [SerializeField] private float throwRate;

    [SerializeField] private float nextThrow;

    [SerializeField] private int eggCount = 12;

    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (eggCount == 0)
        {
            Debug.Log("Out of eggs");
            return;
        }

        Throwing();        
    }

    private void EggCounter(int eggS)
    {
        eggCount += eggS;
    }

    private void Throwing()
    {

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextThrow)
        {
            EggCounter(-1);
            
            

            nextThrow = Time.time + throwRate;
            
            GameObject _throwInstance  = Instantiate(_egg, ThrowPointStart.position, Quaternion.identity);



            Debug.Log(eggCount);

            IsThrowing();
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("IsThrowing", false);
        }

    }

    public void IsThrowing()
    {
        animator.SetBool("IsThrowing", true);
    }
}
