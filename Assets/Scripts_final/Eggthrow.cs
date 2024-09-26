using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Eggthrow : MonoBehaviour
{

    [SerializeField] private GameObject _egg;
    
    [SerializeField] private Transform ThrowPointStart;

    [SerializeField] private float throwRate;

    [SerializeField] private float nextThrow;

    [SerializeField] private int eggCount = 6;

    public Animator animator;

    public static Eggthrow instance;
    public Canvas EggCountCanvas;
    [SerializeField] private TMP_Text EggCountText;

    private void Start()
    {

        instance = this;
        EggCountText.text = eggCount.ToString();


        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (eggCount == 0)
        {
            Debug.Log("Out of eggs");
            animator.SetBool("IsThrowing", false);
            return;
        }

        Throwing();        
    }

    private void EggCounter(int eggS)
    {
        eggCount += eggS;       
    }

    void Throwing()
    {

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextThrow)
        {
            EggCounter(-1);

            updateEggText(eggCount);

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

    private void updateEggText(int egg)
    {
        EggCountText.text = eggCount.ToString();
    }

    public void IsThrowing()
    {
        animator.SetBool("IsThrowing", true);
    }
}
