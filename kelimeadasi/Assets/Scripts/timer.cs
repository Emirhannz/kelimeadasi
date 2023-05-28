using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    private Text info;
    private float sayac;
    public Slider zaman;
    public GameObject s�re_bitti_panel;
    private void Awake()
    {
        info = GameObject.FindWithTag("info").GetComponent<Text>();
        zaman = GameObject.Find("Timer").GetComponent<Slider>();
    }
    void Start()
    {
        zaman.maxValue = 10;
        zaman.minValue = 0;
        zaman.wholeNumbers = false;
        zaman.value = zaman.maxValue;
        sayac = zaman.value;
        
    }

    
    void Update()
    {   
        if(zaman.value > zaman.minValue)
        {
            sayac -= Time.deltaTime;
            zaman.value = sayac;
            info.text = ((int)zaman.value).ToString();
        }
        
        /*if(zaman.value == zaman.minValue)
        {
            s�re_bitti_panel.SetActive(true);
        }*/
    }
}
