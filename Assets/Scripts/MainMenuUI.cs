using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using TMPro;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] TMP_Dropdown levelSelect;

    List<string> levels = new List<string>();

    private void Start()
    {
        CacheLevels();
    }

    private void CacheLevels()
    {
        DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);
        FileInfo[] info = dir.GetFiles("*.dat");

        foreach (FileInfo f in info)
        {
            string fileName = Path.GetFileNameWithoutExtension(f.ToString());
            levels.Add(fileName);
        }

        RefreshDropdown(levels);
    }

    public void LoadLevel()
    {
        if (levelSelect.value == 0)
        {
            LoadHelper.levelToLoad = null;
            SceneManager.LoadScene("LevelBuilder");
        }
        else
        {
            LoadHelper.levelToLoad = levels[levelSelect.value - 1] + ".dat";
            SceneManager.LoadScene("GameScene");
        }
    }

    public void DeleteLevel()
    {
        if (levelSelect.value == 0)
        {
            Debug.LogError("can't delete at index 0");
        }
        else
        {
            File.Delete(FileHandler.GetPath(levels[levelSelect.value - 1] + ".dat"));
        }

        CacheLevels();
    }

    private void RefreshDropdown(List<string> levels)
    {
        List<string> d = new List<string>();
        d.Add("New level");

        levelSelect.ClearOptions();
        levelSelect.AddOptions(d);
        levelSelect.AddOptions(levels);
    }
}
