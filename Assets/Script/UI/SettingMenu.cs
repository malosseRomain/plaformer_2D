using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Linq;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown ResDropDown;
    public Slider MusiqueSlider;
    public Slider EffetSonoreSlider;
    public Slider GlobalSoundSlider;

    Resolution[] resolutions;


    public void Start()
    {
        audioMixer.GetFloat("Musique", out float musiqueValSlider);
        MusiqueSlider.value = musiqueValSlider;
        audioMixer.GetFloat("EffetSonore", out float soundValSlider);
        EffetSonoreSlider.value = soundValSlider;
        audioMixer.GetFloat("VolumeGlobal", out float GlobalsoundValSlider);
        GlobalSoundSlider.value = GlobalsoundValSlider;

        resolutions = Screen.resolutions.Select(resolution => new Resolution {width = resolution.width, height = resolution.height}).Distinct().ToArray();
        ResDropDown.ClearOptions();
        List<string> Options = new List<string>();

        int CurrentRes = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string Option = resolutions[i].width + "x" + resolutions[i].height;
            Options.Add(Option);

            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                CurrentRes= i;
            }
        }

        ResDropDown.AddOptions(Options);
        ResDropDown.value = CurrentRes;
        ResDropDown.RefreshShownValue();

        Screen.fullScreen = true;
    }


    public void SetMusic(float volume)
    {
        audioMixer.SetFloat("Musique", volume);
    }

    public void SetEffetSonore(float volume)
    {
        audioMixer.SetFloat("EffetSonore", volume);
    }
    
    public void SetGlobalVolume(float volume)
    {
        audioMixer.SetFloat("VolumeGlobal", volume);
        audioMixer.SetFloat("EffetSonore", volume);
        audioMixer.SetFloat("Musique", volume);
    }
    
    public void SetFullScreen(bool isFullSreen)
    {
        Screen.fullScreen = isFullSreen;
    }

    public void SetResolution(int resolutionIndex) 
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void RecommencerJeu()
    {
        PlayerPrefs.DeleteAll();
    }
}