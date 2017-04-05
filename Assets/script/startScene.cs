using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Diagnostics;
using UnityEngine;
using debug = UnityEngine.Debug;

public class startScene : MonoBehaviour {
    public Text quitText;
    private int clickNum = 0;
    Stopwatch st = new Stopwatch();
	// Use this for initialization
	void Start () {
        if (!PlayerPrefs.HasKey("Data"))
        {
            SettingData();    
        }
	}
	void SettingData()
    {
        PlayerPrefs.SetString("Data", "DaLae");
        PlayerPrefs.SetFloat("Sen", 1.0f);
        PlayerPrefs.SetFloat("Vol", 1.0f);
        PlayerPrefs.SetInt("Money", 0);
    }
	// Update is called once per frame
	void Update () {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape) && clickNum++ == 0)
            {
                st.Start();
                quitText.text = "한번 더 클릭시 종료 됩니다";
            }
            else if(Input.GetKey(KeyCode.Escape) && clickNum == 1)
            {
                Application.Quit();
            }
        }
        if(st.ElapsedMilliseconds >= 1000)
        {
            quitText.text = "";
            clickNum = 0;
            st.Reset();
        }
    }
}
