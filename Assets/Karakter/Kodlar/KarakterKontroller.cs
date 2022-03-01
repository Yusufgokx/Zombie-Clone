using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterKontroller : MonoBehaviour
{
    Animator anim;

    [SerializeField]
    private float karakterhiz;
    
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }


    void Update()
    {
        Hareket();

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
