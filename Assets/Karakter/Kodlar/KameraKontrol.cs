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

    Vector3 objROT;
    public Transform karakterVucut;
    KarakterKontroller karakterHp;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // fareyi ekrandan kaybeder 
        karakterHp =GameObject.Find("SWAT").GetComponent<KarakterKontroller>();
    }
    private void Update()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (karakterHp.YasiyorMu() == true)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, hedef.position + hedefMesafe, Time.deltaTime * 10);
            fareX += Input.GetAxis("Mouse X") * fareHassasiyeti;
            fareY += Input.GetAxis("Mouse Y") * fareHassasiyeti;
            if (fareY >= 25)
            {
                fareY = 25;
            }
            if (fareY < -40)
            {
                fareY = -40;
            }
            this.transform.eulerAngles = new Vector3(fareY, fareX, 0);
            hedef.transform.eulerAngles = new Vector3(0, fareX, 0);


            Vector3 gecici = this.transform.eulerAngles;
            gecici = this.transform.eulerAngles;
            gecici.z = 0;
            gecici.y = this.transform.localEulerAngles.y;
            gecici.x = this.transform.localEulerAngles.x + 10;
            objROT = gecici;
            karakterVucut.transform.eulerAngles = objROT;
        }

    }
}
