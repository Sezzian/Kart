using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public Slider SpeedSlider;
    public Slider SoundSlider;
    public Slider DifficultySlider;

    // Save all slider values and go to the main scene
    public void GotoMainPolice()
    {
        GlobalVariables.Instance.player = false;
        GlobalVariables.Instance.speed = SpeedSlider.value;
        GlobalVariables.Instance.sound = SoundSlider.value;
        GlobalVariables.Instance.difficulty = DifficultySlider.value;

        SceneManager.LoadScene("Main");
    }
    // save all slider values and go to the main scene
    public void GotoMainTaxi()
    {
        GlobalVariables.Instance.player = true;
        GlobalVariables.Instance.speed = SpeedSlider.value;
        GlobalVariables.Instance.sound = SoundSlider.value;
        GlobalVariables.Instance.difficulty = DifficultySlider.value;

        SceneManager.LoadScene("Main");
    }
    // go back to the start scene
    public void GotoStart()
    {
        SceneManager.LoadScene("UI");
    }
}
