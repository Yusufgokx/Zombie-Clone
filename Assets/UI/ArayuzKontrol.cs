using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArayuzKontrol : MonoBehaviour
{
    public Text mermiText;
    public Text saglikText;
    public GameObject sahteMenu;
    public bool oyunDurdu;

    GameObject Oyuncu;
    
    void Start()
    {
        Oyuncu = GameObject.Find("SWAT");
    }

    void Update()
    {
        mermiText.text = Oyuncu.GetComponent<AtesSistemi>().GetSarjor().ToString()+"/"+ Oyuncu.GetComponent<AtesSistemi>().GetCephane().ToString();
        saglikText.text = "HP:" + Oyuncu.GetComponent<KarakterKontroller>().GetSaglik();
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (oyunDurdu == true)
            {
                OyunuDevamEttir();
            }
            else if (oyunDurdu == false)
            {
                OyunuDurdur();
            }
        
        }
      




    }
    public void OyunuDevamEttir()
    {
        sahteMenu.SetActive(false);
        Time.timeScale = 1;
        oyunDurdu =false;    
    }
    public void OyunuDurdur()
    {
        sahteMenu.SetActive(true);
        Time.timeScale = 0;
        oyunDurdu = true;
    }



}
