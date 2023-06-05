using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class UyeKontrol : MonoBehaviour
{
    public GameObject HataUyarisi;
    public GameObject[] paneller;
    public TMPro.TMP_InputField[] GirisInput;
    public TMPro.TMP_InputField[] KayitInput;

    public void _girisYap()
    {
        StartCoroutine(GirisYapRequest(GirisInput[0].text, GirisInput[1].text, ResponseCallback));
    }

    IEnumerator GirisYapRequest(string kullaniciAdi, string parola, Action<string> callback = null)
    {
        WWWForm form = new WWWForm();

        form.AddField("Islem", "Giris");
        form.AddField("Kullanici", kullaniciAdi);
        form.AddField("Parola", parola);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/Unity_DB/index.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (callback != null)
                {
                    string data = www.downloadHandler.text;
                    callback(data);
                }
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

        if (data.Contains("GİRİŞ BAŞARILI"))
        {
            // Anamenüye yönlendirme işlemini gerçekleştir
            SceneManager.LoadScene("anamennnu");
        }
        if (data.Contains("HATALI KULLANICI ADI VEYA PAROLA"))
        {
            HataUyarisi.SetActive(true); // Hatal� kullan�c� ad� veya parola durumunda HataUyarisi g�r�n�r hale getiriliyor
        }

    }
}