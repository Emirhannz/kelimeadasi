using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class veriCekme : MonoBehaviour
{
    public string[] gelen_veriler = new string[12];
    public Text[] textler;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(kayit_cek());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator kayit_cek()
    {
        WWWForm form = new WWWForm();
        form.AddField("komut", "veriCekme");
        string url = "http://localhost/veriTabani.php";
        WWW w = new WWW(url, form);
        yield return w;
        gelen_veriler = w.text.Split(";");

        for(int i=0;i< gelen_veriler.Length-1 ;i++)
        {
            textler[i].text = "" + gelen_veriler[i];
        }
        Debug.Log(w.text);
    }
}
