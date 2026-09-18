using UnityEngine;
using System.Collections.Generic;

public class UpgradeApplierScript : MonoBehaviour
{
    public PlaceableStats objLinkPrefab;
    public GameObject parent;

    public List<UpgradeModule> possibleUpgrades = new List<UpgradeModule>();

    public void PassUpgradeModules(List<UpgradeSO> upgradeList)
    {

        foreach (UpgradeSO upgradeData in upgradeList)
        {
            if (upgradeData.objLink != objLinkPrefab)
            {
                continue;
            }

            ApplyUpgrade(upgradeData);
        }
    }

    private void ApplyUpgrade(UpgradeSO upgradeData)
    {
        UpgradeModule newModule = Instantiate(upgradeData.upgradeStored, transform);
        newModule.Setup(parent);
        newModule.ApplyUpgrade();
    }
}
