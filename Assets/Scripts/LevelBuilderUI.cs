using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBuilderUI : MonoBehaviour
{
    [SerializeField] GameObject saveMenu;

    public void ToggleSaveMenu()
    {
        saveMenu.SetActive(!saveMenu.activeInHierarchy); 
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
