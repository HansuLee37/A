using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class settingScenePopUp : MonoBehaviour {
    public void Sensitivity(float Sen)
    {
        PlayerPrefs.SetFloat("Sen", Sen);
    }
    public void Volume(float Vol)
    {
        PlayerPrefs.SetFloat("Vol", Vol);
    }
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("startScene");
    }
}
