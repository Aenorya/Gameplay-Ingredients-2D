using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private float volume = 0.5f;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TextMeshProUGUI volumeTxt;

    void Start()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            volume = PlayerPrefs.GetFloat("Volume");
        }
        volumeSlider.value = volume;
        ChangeVolume();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            volumeSlider.gameObject.SetActive(!volumeSlider.IsActive());
            Time.timeScale = volumeSlider.IsActive()? 0 : 1;
        }
    }

    public void ChangeVolume()
    {
        volume = volumeSlider.value;
        volumeTxt.text = string.Format("{0:00}",volume * 100);
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
