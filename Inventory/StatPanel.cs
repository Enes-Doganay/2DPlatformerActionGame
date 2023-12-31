﻿using UnityEngine;
using CharacterStats;
public class StatPanel : MonoBehaviour
{
    [SerializeField] StatDisplay[] statDisplays;
    [SerializeField] string[] statNames;
    private CharacterStat[] stats;

    private void OnValidate()
    {
        statDisplays = GetComponentsInChildren<StatDisplay>();
        UpdateStatNames();
    }
    public void SetStats(params CharacterStat[] characterStats)
    {
        stats = characterStats;
        if (stats.Length > statDisplays.Length)
        {
            Debug.Log("Not Enough Stat Displays!");
            return;
        }
        for (int i = 0; i < statDisplays.Length; i++)
        {
            statDisplays[i].gameObject.SetActive(i < stats.Length);
            if (i < stats.Length)
            {
                statDisplays[i].Stat = stats[i];
            }
        }
    }
    public void UpdateStatValues()
    {
        for(int i = 0; i < stats.Length; i++)
        {
            statDisplays[i].Stat= stats[i];
        }
    }
    public void UpdateStatNames()
    {
        for (int i = 0; i < statNames.Length; i++)
        {
            statDisplays[i].Name = statNames[i];
        }
    }
}
