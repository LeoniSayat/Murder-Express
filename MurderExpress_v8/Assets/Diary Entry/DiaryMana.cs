using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DiaryMana : MonoBehaviour
{
    public List<string> entries = new List<string>();
    public GameObject Diary;
    public GameObject content;
    public Text DiaryContent;
    public RectTransform rT;
    public int EntryIndex = 0;
    string currentEntry;

    
    public void OpenDiary()
    {
        Diary.SetActive(true);
    }
    public void CloseDiary()
    {
        Diary.SetActive(false);
    }
    public void AddEntry(string[] EntriesInObj)
    {
        
        if (EntryIndex >= EntriesInObj.Length)
        {
            return;
        }
        currentEntry = EntriesInObj[EntryIndex];
        if (!entries.Contains(currentEntry))
        {
            EntryIndex++;
            if (!string.IsNullOrWhiteSpace(currentEntry))
            {

                AudioManager.instance.Play("Writing");
                DiaryContent.text = DiaryContent.text + currentEntry + "\n\n";
                //Debug.Log("Added the text");
                entries.Add(currentEntry);
                //47 characters in a diary line
                int lines = Mathf.RoundToInt(currentEntry.Length / 47) + 2;
                rT.sizeDelta = new Vector2(rT.sizeDelta.x, rT.sizeDelta.y + (11*lines));
            }
        }
    }

    public void RetrieveEntries()
    {
        Debug.Log(PlayerData.DiaryEntries);
        DiaryContent.text = PlayerData.DiaryEntries;
        rT.sizeDelta = PlayerData.DiarySize;
    }
}
