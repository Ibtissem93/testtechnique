using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneManagerScript : MonoBehaviour
{
    public Text LevelNumber;
    int indexnbr;

     void Start()
    {
        indexnbr = PlayerPrefs.GetInt("nbr scene") + 1;
        LevelNumber.text = indexnbr.ToString();
    }

    public void GoToScene(int sceneANumber)
    {
       
        PlayerPrefs.SetInt("nbr scene", indexnbr);
       
        SceneManager.LoadScene(sceneANumber);
    }
}
