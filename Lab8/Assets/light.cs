using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Luz"))
        {
            other.gameObject.GetComponent<Light>().color = Color.red;
            other.gameObject.GetComponent<Light>().intensity = Mathf.Sin(Time.time)*5;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Luz"))
        {
            other.gameObject.GetComponent<Light>().intensity = 0;
        }
    }
}
