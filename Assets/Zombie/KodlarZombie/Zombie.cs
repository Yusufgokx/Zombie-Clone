using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public float zombiHP=100;
    Animator ZombiAnim;
    bool zombiOLU;

    private float mesafe;
    public float kovalamaMesafe;
    public float SaldiriMesafe;
    NavMeshAgent zombiNavMesh;

    GameObject hedefOyuncu;
    void Start()
    {
        ZombiAnim = this.GetComponent<Animator>();
        hedefOyuncu = GameObject.Find("SWAT");
        zombiNavMesh = this.GetComponent<NavMeshAgent>();
    }

   
    void Update()
    {
        this.transform.LookAt(hedefOyuncu.transform.position);
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
            mesafe = Vector3.Distance(this.transform.position, hedefOyuncu.transform.position);
            if (mesafe < kovalamaMesafe) 
            {
                zombiNavMesh.isStopped = false;
                zombiNavMesh.SetDestination(hedefOyuncu.transform.position);
                ZombiAnim.SetBool("yuruyor",true);
                ZombiAnim.SetBool("saldiriyor", false);
                this.transform.LookAt(hedefOyuncu.transform.position);
                


            }
            else
            {
                zombiNavMesh.isStopped = true ;
                ZombiAnim.SetBool("yuruyor", false);
                ZombiAnim.SetBool("saldiriyor", false);
                
            }
            if (mesafe < SaldiriMesafe) 
            {
                this.transform.LookAt(hedefOyuncu.transform.position);
                zombiNavMesh.isStopped = true;
                ZombiAnim.SetBool("yuruyor", false);
                ZombiAnim.SetBool("saldiriyor", true);
                
                
            }


        }
    }
    public void HasarVer()
    {
        hedefOyuncu.GetComponent<KarakterKontroller>().HasarAL();
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
