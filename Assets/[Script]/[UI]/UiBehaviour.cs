using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiBehaviour : MonoBehaviour
{
    private int nextSceneIndex;
    private int previousSceneIndex;

    void Start()
    {
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
    }

    //Next Button
    public void OnNextButtonPressed()
    {
        SceneManager.LoadScene(nextSceneIndex);
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
    }

    //Back Button
    public void OnBackButtonPressed()
    {

        SceneManager.LoadScene(previousSceneIndex);
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
    }



}
