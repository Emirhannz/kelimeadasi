using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public AudioSource menuMusic; // Anamenü müziðini temsil eden AudioSource
    public AudioSource gameMusic; // Oyun ekraný müziðini temsil eden AudioSource
    public AudioSource saat;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Anamenü müziðini baþlat
        menuMusic.Play();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "anamennnu")
        {
            if (!menuMusic.isPlaying)
            {
                menuMusic.Play();
            }
            saat.Stop();
            gameMusic.Stop();
        }

        else if (scene.name == "GameScreen" || scene.name == "bolum2" || scene.name == "bolum3")
        {
            menuMusic.Pause();

           
                gameMusic.Play();
                saat.Play();
            
        }
        else if (scene.name == "AYARLAR" || scene.name == "SkorTablosu" || scene.name == "oyna" )
        {
            if (!menuMusic.isPlaying)
            {
                menuMusic.UnPause();
            }

            gameMusic.Stop();
            saat.Stop();
        }
    }

}
