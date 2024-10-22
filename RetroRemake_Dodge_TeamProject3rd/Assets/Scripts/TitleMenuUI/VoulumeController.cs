using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VoulumeController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider BGMSlider;	// 볼륨을 조절할 Slider
    [SerializeField] private Slider SFXSlider;

    private void Awake()
    {
        // 슬라이더의 값이 변경될 때 AddListener를 통해 이벤트 구독
        BGMSlider.onValueChanged.AddListener(SetBGMVolume);
        SFXSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    void Start()
    {
        // PlayerPrefs에 Volume 값이 저장되어 있을 경우,
        if (PlayerPrefs.HasKey("BGMVolume"))
        {
            // Slider의 값을 저장해 놓은 값으로 변경.
            BGMSlider.value = PlayerPrefs.GetFloat("BGMVolume");            
        }
        else
        {
            BGMSlider.value = 0.5f;     // PlayerPrefs에 Volume이 없을 경우
        }

        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        }
        else
        {
            SFXSlider.value = 0.5f;
        }
            

        // audioMixer.SetFloat("audioMixer에 설정해놓은 Parameter", float 값)
        // audioMixer에 미리 설정해놓은 parameter 값을 변경하는 코드.
        // Mathf.Log10(BGMSlider.value) * 20 : 데시벨이 비선형적이기 때문에 해당 방식으로 값을 계산.
        audioMixer.SetFloat("BGM", Mathf.Log10(BGMSlider.value) * 20);
        audioMixer.SetFloat("SFX", Mathf.Log10(SFXSlider.value) * 20);
    }

    // Slider를 통해 걸어놓은 이벤트
    public void SetBGMVolume(float volume)
    {
        // 변경된 Slider의 값 volume으로 audioMixer의 Volume 변경하기
        audioMixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
        // 변경된 Volume 값 저장하기
        PlayerPrefs.SetFloat("BGMVolume", BGMSlider.value);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", BGMSlider.value);
    }
}