using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartMenuManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public TMP_Dropdown resolutionDropdown;
    public Slider volumeSlider;

    public void OnClickNewGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnClickContinue()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnClickOptions()
    {
        optionsPanel.SetActive(true);
    }

    public void OnClickBackFromOptions()
    {
        optionsPanel.SetActive(false);
    }

    public void OnResolutionChanged(int index)
    {
        switch (index)
        {
            case 0: Screen.SetResolution(1920, 1080, FullScreenMode.Windowed); break;
            case 1: Screen.SetResolution(1280, 720, FullScreenMode.Windowed); break;
            case 2: Screen.SetResolution(800, 600, FullScreenMode.Windowed); break;
        }
    }

    public void OnVolumeChanged(float value)
    {
        AudioListener.volume = value;
    }
}