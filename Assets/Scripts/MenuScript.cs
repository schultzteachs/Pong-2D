using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{

   
    
    
    public void Play2PGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    public void Exit()
    {
        Debug.Log("Quit Button pressed!");
        Application.Quit();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
