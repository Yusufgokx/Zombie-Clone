using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterKontroller : MonoBehaviour
{
    Animator anim;

    [SerializeField]
    private float karakterhiz;
    private float saglik = 100;


    bool Hayattami;
    void Start()
    {
        anim = this.GetComponent<Animator>();
        Hayattami = true;

    }


    void Update()
    {
        if (saglik <= 0)
        {
            Hayattami = false;
            anim.SetBool("YasiyorMu", Hayattami);
        }
        if (Hayattami == true)
        {
            Hareket();
        }



    }
    public bool YasiyorMu() //private olan değişkene başka scriptten erişmemizi sağlayan fonksyon
    {
        return Hayattami;

    }

    public void HasarAL()
    {
        saglik -= Random.Range(5, 10);
    }
    void Hareket()
    {
        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");
        anim.SetFloat("Horizontal", yatay);
        anim.SetFloat("Vertical", dikey);
        this.gameObject.transform.Translate(yatay * karakterhiz * Time.deltaTime, 0, dikey * karakterhiz * Time.deltaTime);

    }
}

