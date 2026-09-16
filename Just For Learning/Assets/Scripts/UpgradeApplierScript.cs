using UnityEngine;
using System.Collections.Generic;

public class UpgradeApplierScript : MonoBehaviour
{
    public PlaceableStats objLinkPrefab;
    public GameObject parent;

    public List<UpgradeModule> possibleUpgrades = new List<UpgradeModule>();

    public void PassUpgradeModules(List<UpgradeData> upgradeList)
    {

        foreach (UpgradeData upgradeData in upgradeList)
        {
            if (upgradeData.objLink != objLinkPrefab)
            {
                continue;
            }

            ApplyUpgrade(upgradeData);
        }
    }

    private void ApplyUpgrade(UpgradeData upgradeData)
    {
        UpgradeModule newModule = Instantiate(upgradeData.upgradeStored, transform);
        newModule.Setup(parent);
        newModule.ApplyUpgrade();
    }
}
