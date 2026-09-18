using UnityEngine;
using System.Collections.Generic;
using System;

public class GeneralUpgradeManager : MonoBehaviour
{
    public List<UpgradeSO> lowTierUpgrades = new List<UpgradeSO>();
    public List<UpgradeSO> midTierUpgrades = new List<UpgradeSO>();
    public List<UpgradeSO> highTierUpgrades = new List<UpgradeSO>();

    // When you pick certain upgrades, a new one can appear
    public List<UpgradeSO> randomizedUpgradesList = new List<UpgradeSO>();


    public List<UpgradeSO> ownedUpgrades = new List<UpgradeSO>();

    public delegate void UpgradeHandler(List<UpgradeSO> upgradesToApply);
    public static event UpgradeHandler OnApplyUpgrade;

    private void Start()
    {
        foreach (UpgradeSO upgradeData in lowTierUpgrades)
        {
            randomizedUpgradesList.Add(upgradeData);
        }

        UpgradeOptionSetup.OnPickNewUpgrade += OnPickNewUpgrade;
    }

    private void OnDestroy()
    {
        UpgradeOptionSetup.OnPickNewUpgrade -= OnPickNewUpgrade;

    }

    private void OnPickNewUpgrade(UpgradeSO heldUpgradeData)
    {
        AddNewUpgrade(heldUpgradeData);
    }

    public void AddNewUpgrade(UpgradeSO newUpgradeData)
    {
        ownedUpgrades.Add(newUpgradeData);

        randomizedUpgradesList.Remove(newUpgradeData);

        if (newUpgradeData.nextTierUpgrade != null)
        {
            randomizedUpgradesList.Add(newUpgradeData.nextTierUpgrade);
        }

        if (newUpgradeData.previousTierUpgrade != null)
        {
            ownedUpgrades.Remove(newUpgradeData.previousTierUpgrade);
        }
    }

    // Called by placer so called when placing
    public void AddUpgradesToSpawnable(GameObject spawnable)
    {
        spawnable.transform.Find("UpgradeApplier").GetComponent<UpgradeApplierScript>().PassUpgradeModules(ownedUpgrades);
    }
}

//[Serializable]
//public class UpgradeData
//{
//    public UpgradeModule upgradeStored;
//    public PlaceableStats objLink;

//    public string upgradeName;
//    public string upgradeDescription;
//    public Sprite upgradeSprite;


//}