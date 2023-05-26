using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class admin : MonoBehaviour
{
    public string[] sozluk;
    public Text puan_txt;
    List<GameObject> isaretli_butonlar;
    string kelime = null;
    public bool tiklandi = false;
    public GameObject bitti_panel;
    int puan = 0;
    int bulunan_kelime_sayisi = 0;




    void Start()
    {
        isaretli_butonlar = new List<GameObject>();
    }

    public void isaretli_buton_olustur(GameObject button)
    {
        isaretli_butonlar.Add(button);
        kelime = null;

        foreach(GameObject butonlar in isaretli_butonlar)
        {
            kelime = kelime + butonlar.name;
            puan_txt.text = kelime;
        }
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tiklandi = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            tiklandi = false;
            yazi_olustur();
            puan_txt.text = puan.ToString();
        }


    }
    void yazi_olustur()
    {
        foreach (string kelimler in sozluk)
        {
            if (kelimler == kelime)
            {
                puan += 100;
                bulunan_kelime_sayisi++;
                foreach(GameObject buton in isaretli_butonlar)
                {
                    buton.GetComponent<button>().yok_ol = true;
                }
            }
        }

        isaretli_butonlar.Clear();
        kelime = null;

        if(bulunan_kelime_sayisi == sozluk.Length)
        {
            bitti_panel.SetActive(true);
        }

    }
}
