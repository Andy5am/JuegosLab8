using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public AudioClip click;
    private bool on = true;
    public Text texto;
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if(Physics.Raycast(myRay,out hitInfo))
        {
            if (hitInfo.collider.gameObject.CompareTag("Objeto"))
            {
                canvas.transform.Find("Panel").gameObject.SetActive(true);
                texto.text = hitInfo.collider.name;
                if(hitInfo.collider.name == "Puerta")
                {
                    texto.text = hitInfo.collider.name + "\nPresione E para abrir";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Destroy(hitInfo.collider.gameObject);
                    }
                }
            }else if (!hitInfo.collider.gameObject.CompareTag("Objeto"))
            {
                canvas.transform.Find("Panel").gameObject.SetActive(false);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (on)
            {
                GetComponent<AudioSource>().PlayOneShot(click);
                on = !on;
                GetComponent<Light>().intensity = 0;
            }
            else if (!on)
            {
                GetComponent<AudioSource>().PlayOneShot(click);
                on = !on;
                GetComponent<Light>().intensity = 3;
            }
        }
    }
}
