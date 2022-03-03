using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private float zombiHP;
    bool zombiOLU;

    void Start()
    {
        if (zombiHP <= 0)
        {

        }
    }

   
    void Update()
    {
        
    }
    public void HasarAL()
    {
        zombiHP -= Random.Range(15, 25);
    }
}
