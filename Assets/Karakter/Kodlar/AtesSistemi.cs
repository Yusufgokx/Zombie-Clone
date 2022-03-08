using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtesSistemi : MonoBehaviour
{
    Camera kamera;
    public LayerMask zombikatman;
    public KarakterKontroller hpKontrol;
    Animator anim;

    public ParticleSystem muzzleFlash;

    private float sarjor = 5;
    private float cephane = 10;
    private float sarjorKapasitesi = 5;

    void Start()
    {
        kamera = Camera.main;
        anim =this.gameObject.GetComponent<Animator>();
        muzzleFlash.Stop();

    }

    
    void Update()
    {

        if (hpKontrol.YasiyorMu() == true)
        {
            if (Input.GetMouseButton(0))
            {
                if (sarjor > 0)
                {
                    anim.SetBool("atesEt", true);
                }
                if (sarjor <= 0)
                {
                    anim.SetBool("atesEt", false);
                }
                if (sarjor <= 0 && cephane > 0)
                {
                    anim.SetBool("sarjorDegistirme",true);
               
                }

            }
            else
            {
                anim.SetBool("atesEt", false);
            }

            /*if (Input.GetMouseButtonUp(0))
            {
                anim.SetBool("atesEt", false);
            }
           */
        }

    }
    public void SarjorDegistirme()
    {
        cephane -= sarjorKapasitesi - sarjor;
        sarjor = sarjorKapasitesi;
        anim.SetBool("sarjorDegistirme", false);
    }
    public void AtesEtme()
    {
        sarjor--;
        muzzleFlash.Play();
        Ray ray = kamera.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit, Mathf.Infinity, zombikatman))
        {
            hit.collider.gameObject.GetComponent<Zombie>().HasarAL();
        }

    }
}
