using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public void CacheLevels()
    {
        DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);
        FileInfo[] info = dir.GetFiles("*.dat");

        foreach (FileInfo f in info)
        {
            string fileName = Path.GetFileNameWithoutExtension(f.ToString());
            levels.Add(fileName);
        }

        levelSelect.AddOptions(levels);
    }
}
