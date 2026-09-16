using UnityEngine;
using System.Collections.Generic;
using System;

public class GeneralUpgradeManager : MonoBehaviour
{
    // use a scriptable objects to store a list of objects


    //public List<GameObject> allUpgradeModuleObjects = new List<GameObject>();
    public List<GameObject> allSpawnablesList = new List<GameObject>();

    public List<UpgradeData> allUpgradeData = new List<UpgradeData>();

    public List<UpgradeData> ownedUpgrades = new List<UpgradeData>();

    public delegate void UpgradeHandler(List<UpgradeData> upgradesToApply);
    public static event UpgradeHandler OnApplyUpgrade;

    // At start it will pass all objects and bring related upgrades (sort)

    private void Start()
    {
        //OwnEverything();
    }

    public void OwnEverything()
    {
        foreach (UpgradeData upgradeData in allUpgradeData)
        {
            ownedUpgrades.Add(upgradeData);
        }
    }

    public void AddUpgradesToSpawnable(GameObject spawnable)
    {
        spawnable.transform.Find("UpgradeApplier").GetComponent<UpgradeApplierScript>().PassUpgradeModules(ownedUpgrades);
    }
}

[Serializable]
public struct UpgradeData
{
    public UpgradeModule upgradeStored;
    public PlaceableStats objLink;

    public string upgradeName;
    public string upgradeDescription;
    public Sprite upgradeSprite;
}