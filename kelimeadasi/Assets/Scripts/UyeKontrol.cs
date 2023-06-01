using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Networking;

public class UyeKontrol : MonoBehaviour
{
    public GameObject[] paneller;
    public TMPro.TMP_InputField[] GirisInput;
    public TMPro.TMP_InputField[] KayitInput;

    public void _girisYap()
    {
        StartCoroutine(girisYap(GirisInput[0].text, GirisInput[1].text, this.ResponseCallback));
    }

    IEnumerator girisYap(string kullaniciAdi, string parola, Action<string> callback = null)
    {
        WWWForm form = new WWWForm();

        form.AddField("Islem", "Giris");
        form.AddField("Kullanici", kullaniciAdi);
        form.AddField("Parola", parola);

        UnityWebRequest www = UnityWebRequest.Post("https://ozgurturk.com.tr/unity/index.php", form);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            if (callback != null)
            {
                string Data = www.downloadHandler.text;
                callback(Data);
            }
        }
    }

    public void _KayitOl()
    {
        StartCoroutine(kayitOl(this.ResponseCallback));
    }

    IEnumerator kayitOl(Action<string> callback = null)
    {
        WWWForm form = new WWWForm();

        form.AddField("Islem", "Kayit");
        form.AddField("AdSoyad", KayitInput[0].text);
        form.AddField("Email", KayitInput[1].text);
        form.AddField("Kullanici", KayitInput[2].text);
        form.AddField("Parola", KayitInput[3].text);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/Unity_DB/index.php", form);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            if (callback != null)
            {
                string Data = www.downloadHandler.text;
                callback(Data);
            }
        }
    }

    private void ResponseCallback(string data)
    {
        Debug.Log(data);
    }
}