using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    private Text info;
    private float sayac;
    public Slider zaman;
    public GameObject süre_bitti_panel;
    private bool durduruldu = false;

    private void Awake()
    {
        info = GameObject.FindWithTag("info").GetComponent<Text>();
        zaman = GameObject.Find("Timer").GetComponent<Slider>();
    }

    void Start()
    {
        zaman.maxValue = 60;
        zaman.minValue = 0;
        zaman.wholeNumbers = false;
        zaman.value = zaman.maxValue;
        sayac = zaman.value;
    }


    void Update()
    {
        if (!durduruldu)
        {
            if (zaman.value > zaman.minValue)
            {
                sayac -= Time.deltaTime;
                zaman.value = sayac;
                info.text = ((int)zaman.value).ToString();
            }

            if (zaman.value == zaman.minValue)
            {
                SureBitti();
            }
        }
    }

    public void Durdur()
    {
        durduruldu = true;
    }

    private void SureBitti()
    {
        süre_bitti_panel.SetActive(true);
    }
}
