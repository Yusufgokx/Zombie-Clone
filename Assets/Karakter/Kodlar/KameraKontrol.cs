using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraKontrol : MonoBehaviour
{
    public Transform hedef;
    public Vector3 hedefMesafe;

    [SerializeField]
    private float fareHassasiyeti;
    float fareX, fareY;
    void Start()
    {
        
    }
    private void Update()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, hedef.position + hedefMesafe, Time.deltaTime * 10);
        fareX += Input.GetAxis("Mouse X")*fareHassasiyeti;
        fareY += Input.GetAxis("Mouse Y")*fareHassasiyeti;
        this.transform.eulerAngles = new Vector3(fareY, fareX, 0);
        hedef.transform.eulerAngles= new Vector3(0, fareX, 0);


    }
}
