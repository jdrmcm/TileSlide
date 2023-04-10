using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilderUI : MonoBehaviour
{
    [SerializeField] GameObject saveMenu;

    public void ToggleSaveMenu()
    {
        saveMenu.SetActive(!saveMenu.activeInHierarchy); 
    }
}
