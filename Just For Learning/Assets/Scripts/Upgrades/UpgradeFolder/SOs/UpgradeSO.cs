using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeSO", menuName = "Scriptable Objects/UpgradeSO")]
public class UpgradeSO : ScriptableObject
{
    public UpgradeModule upgradeStored;
    public PlaceableStats objLink;

    public string upgradeName;
    public string upgradeDescription;
    public Sprite upgradeSprite;

    public UpgradeSO nextTierUpgrade;
    public UpgradeSO previousTierUpgrade;


}
