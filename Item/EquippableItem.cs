using UnityEngine;
using CharacterStats;
using DG.Tweening;

public enum EquipmentType{
    Helmet,
    Chest,
    Gloves,
    Boots,
    Sword,
    Bow,
    Accessory1,
    Accessory2
}
[CreateAssetMenu]
public class EquippableItem : Item
{
    public int StrengthBonus;
    public int DexterityBonus;
    public int IntelligenceBonus;
    public int VitalityBonus;
    [Space]
    public int StrengthPercentBonus;
    public int DexterityPercentBonus;
    public int IntelligencePercentBonus;
    public int VitalityPercentBonus;
    [Space]
    public EquipmentType EquipmentType;

    public float scale = 1f;

    public void Equip(InventoryManager characterStat)
    {
        if (StrengthBonus != 0)
            characterStat.Strength.AddModifier(new StatModifier(StrengthBonus,StatModType.Flat,this));
        if (DexterityBonus != 0)
            characterStat.Dexterity.AddModifier(new StatModifier(DexterityBonus, StatModType.Flat, this));
        if (IntelligenceBonus != 0)
            characterStat.Intelligence.AddModifier(new StatModifier(IntelligenceBonus, StatModType.Flat, this));
        if (VitalityBonus != 0)
            characterStat.Vitality.AddModifier(new StatModifier(VitalityBonus, StatModType.Flat, this));

        if (StrengthPercentBonus != 0)
            characterStat.Strength.AddModifier(new StatModifier(StrengthBonus, StatModType.PercentMultiplier, this));
        if (DexterityPercentBonus != 0)
            characterStat.Dexterity.AddModifier(new StatModifier(DexterityBonus, StatModType.PercentMultiplier, this));
        if (IntelligencePercentBonus != 0)
            characterStat.Intelligence.AddModifier(new StatModifier(IntelligenceBonus, StatModType.PercentMultiplier, this));
        if (VitalityPercentBonus != 0)
            characterStat.Vitality.AddModifier(new StatModifier(VitalityBonus, StatModType.PercentMultiplier, this));

        if (EquipmentType == EquipmentType.Sword)
        {
            Object.FindObjectOfType<Player>().playerSwordSlot.sprite = icon;
            SetScale(scale);
        }
    }

    public void Unequip(InventoryManager characterStat)
    {
        characterStat.Strength.RemoveAllModifiersFromSource(this);
        characterStat.Dexterity.RemoveAllModifiersFromSource(this);
        characterStat.Intelligence.RemoveAllModifiersFromSource(this);
        characterStat.Vitality.RemoveAllModifiersFromSource(this);
    }
    public void SetScale(float scale)
    {
        Object.FindObjectOfType<Player>().playerSwordSlot.GetComponentInParent<Transform>().transform.DOScale(scale, 0);
    }
}
