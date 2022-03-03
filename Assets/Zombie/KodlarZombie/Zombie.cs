using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float zombiHP=100;
    Animator ZombiAnim;
    bool zombiOLU;
     

    void Start()
    {
        ZombiAnim = this.GetComponent<Animator>();
    }

   
    void Update()
    {
        if (zombiHP <= 0)
        {
            zombiOLU = true;
        }
        if (zombiOLU == true)
        {
            ZombiAnim.SetBool("Dead", true);
            StartCoroutine(YokOL());
        }
        else
        {
            //İLERİDE HAREKET KODU BURAYA 
        }
    }


    IEnumerator YokOL()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);

    }

    public void HasarAL()
    {
        zombiHP -= Random.Range(15, 25);
    }
}
