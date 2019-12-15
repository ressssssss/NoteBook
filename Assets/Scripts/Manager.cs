using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class Manager : MonoBehaviour
{
    private string progress_name = "GameProgress";
    private string dialog_name = "Dialogs";

    private static Manager _instance = null;

    public static Manager getInstance()
    {
        if (_instance == null)
        {
            _instance = new Manager();
        }
        return _instance;
    }

    public void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
        LoadDialogs(dialog_name);
    }

    private Dictionary<string, bool> progress = new Dictionary<string, bool>();
    private Dictionary<int, Dialog> dialogs = new Dictionary<int, Dialog>();

    public Dialog GetDialog(int id)
    {
        if (dialogs.ContainsKey(id))
        {
            return dialogs[id];
        }
        else
        {
            return null;
        }
    }

    public void LoadDialogs(string filename)
    {
        TextAsset json = Resources.Load <TextAsset>(filename);
        Debug.Log(json);
        if (json == null)
        {
            return;
        }

        DialogManager dialogs = JsonUtility.FromJson<DialogManager>(json.text);
        this.dialogs = dialogs.ToDictionary();
    }

    public void SetProgress(string name)
    {
        if (progress.ContainsKey(name))
        {
            progress[name] = true;
        }
        else
        {
            progress.Add(name, true);
        }
        SaveProgress(progress_name);
    }

    public bool GetProgress(string name)
    {
        if (progress.ContainsKey(name))
        {
            return progress[name];
        }
        else
        {
            return false;
        }
    }

    public void SaveProgress(string filename)
    {
        string filepath = Application.dataPath + "/" + filename;
        FileInfo file = new FileInfo(filepath);
        StreamWriter sw = file.CreateText();

        string json = JsonUtility.ToJson(new SerializableDic<string, bool>(progress));
        Debug.Log(json);

        sw.WriteLine(json);
        sw.Close();
        sw.Dispose();
    }

    public void LoadProgress(string filename)
    {
        TextAsset json = Resources.Load(filename) as TextAsset;
        if (json == null)
        {
            return;
        }
        SerializableDic<string, bool> prog = JsonUtility.FromJson<SerializableDic<string, bool>>(json.text);
        progress = prog.ToDictionary();
    }

}
