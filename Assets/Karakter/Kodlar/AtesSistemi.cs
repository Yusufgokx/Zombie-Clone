using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtesSistemi : MonoBehaviour
{
    Camera kamera;
    public LayerMask zombikatman;
    public KarakterKontroller hpKontrol;

    void Start()
    {
        kamera = Camera.main;
    }

    
    void Update()
    {

        if (hpKontrol.YasiyorMu()==true)
        {
            if (Input.GetMouseButton(0))
            {

                AtesEtme();
            }
        }   
        

    }

    void AtesEtme()
    {
        Ray ray = kamera.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit, Mathf.Infinity, zombikatman))
        {
            hit.collider.gameObject.GetComponent<Zombie>().HasarAL();
        }

    }
}
