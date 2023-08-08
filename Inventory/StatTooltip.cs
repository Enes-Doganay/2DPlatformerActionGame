using System.Text;
using UnityEngine;
using UnityEngine.UI;
using CharacterStats;
public class StatTooltip : MonoBehaviour
{
    [SerializeField] Text statNameText;
    [SerializeField] Text statModifiersLabelText;
    [SerializeField] Text statModifiersText;

    private StringBuilder sb = new StringBuilder();
    public void ShowTooltip(CharacterStat stat,string statName)
    {
        statNameText.text = GetStatTopText(stat, statName);
        statModifiersText.text = GetStatModifierText(stat);
        gameObject.SetActive(true);
    }
    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }
    private string GetStatTopText(CharacterStat stat,string statName)
    {
        sb.Length = 0;
        sb.Append(statName);
        sb.Append(" ");
        sb.Append(stat.Value);
        
        if(stat.Value != stat.BaseValue)
        {
            sb.Append(" (");
            sb.Append(stat.BaseValue);

            if (stat.Value > stat.BaseValue)
                sb.Append("+");

            sb.Append(System.Math.Round(stat.Value - stat.BaseValue, 4));
            sb.Append(")");
        }

        return sb.ToString();
    }

    private string GetStatModifierText(CharacterStat stat)
    {
        sb.Length = 0;
        foreach(StatModifier mod in stat.StatModifiers)
        {
            if (sb.Length > 0)
                sb.AppendLine();
            
            if (mod.Value > 0)
                sb.Append("+");
            if (mod.Type == StatModType.Flat)
            {
                sb.Append(mod.Value);
            }
            else
            {
                sb.Append(mod.Value * 100);
                sb.Append("%");
            }

            EquippableItem item = mod.Source as EquippableItem;
            if(item != null)
            {
                sb.Append(" ");
                sb.Append(item.name);
            }
            else
            {
                Debug.LogError("Modifier is not an EquippableItem!");
            }
        }
        return sb.ToString();
    }
}
