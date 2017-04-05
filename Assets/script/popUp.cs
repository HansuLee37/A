using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class popUp : MonoBehaviour {
    public Slider Sen;
    public Slider Vol;
    public GameObject obj;
	public void Hide()
    {
        PlayerPrefs.SetFloat("Sen", Sen.value);
        PlayerPrefs.SetFloat("Vol", Vol.value);
        obj.active = false;
    }
    public void UnHide()
    {
        Sen.value = PlayerPrefs.GetFloat("Sen");
        Vol.value = PlayerPrefs.GetFloat("Vol");
        obj.active = true;
    }
}
