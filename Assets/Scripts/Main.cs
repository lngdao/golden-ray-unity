using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public GameObject mainControls;
    public GameObject aboutSection;

    public void HandleOnSettingBack()
    {

    }

    public void HandleOnAboutBack()
    {
        mainControls.SetActive(true);
        aboutSection.SetActive(false);
    }

    public void HandleOnClickStart()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void HandleOnExit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
            Application.Quit();
    }

    public void HandleOnClickAbout()
    {
        mainControls.SetActive(false);
        aboutSection.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        //mainControls = GameObject.Find("MainControls");
        //aboutSection = GameObject.Find("AboutSection");
        //print(aboutSection);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
