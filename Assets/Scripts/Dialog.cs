using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog
{
    [SerializeField]
    int id;
    [SerializeField]
    string character;
    [SerializeField]
    string content;
    [SerializeField]
    int next;

    public Dialog(int id, string character, string content, int next)
    {
        this.id = id;
        this.character = character;
        this.content = content;
        this.next = next;
    }

    public int GetId()
    {
        return id;
    }

    public string GetCharacter()
    {
        return character;
    }

    public string GetContent()
    {
        return content;
    }

    public int GetNext()
    {
        return next;
    }
}

public class DialogManager
{
    public List<Dialog> dialogs = new List<Dialog>();

    public Dictionary<int, Dialog> ToDictionary()
    {
        int count = dialogs.Count;
        Dictionary<int, Dialog> target = new Dictionary<int, Dialog>(count);
        for (var i = 0; i < count; ++i)
        {
            target.Add(dialogs[i].GetId(), dialogs[i]);
        }
        return target;
    }
}
