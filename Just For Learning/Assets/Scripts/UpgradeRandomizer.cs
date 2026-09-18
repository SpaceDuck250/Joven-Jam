using UnityEngine;
using System;
using System.Collections.Generic;

public class UpgradeRandomizer : MonoBehaviour
{
    public GeneralUpgradeManager upgradeManager;

    public delegate void RandomUpgradesHandler(List<UpgradeSO> listOfUpgrades);
    public event RandomUpgradesHandler OnUpgradesRandomized;

    private List<UpgradeSO> outputUpgradesList = new List<UpgradeSO>(3);

    // so same numbers arent picked
    private List<int> pickedNumbers = new List<int>(3);

    private void Start()
    {
        YellowLuckyBlockScript.OnClickYellowLuckyBlock += OnClickYellowLuckyBlock;
    }

    private void OnDestroy()
    {
        YellowLuckyBlockScript.OnClickYellowLuckyBlock -= OnClickYellowLuckyBlock;

    }

    private void OnClickYellowLuckyBlock()
    {
        RandomizeUpgradesOnPanel();
    }

    public void RandomizeUpgradesOnPanel()
    {
        outputUpgradesList.Clear();

        if (upgradeManager.randomizedUpgradesList.Count < 3)
        {
            return;
        }

        pickedNumbers.Clear();
        for (int i = 0; i < 3; i++)
        {
            int randomInt = UnityEngine.Random.Range(0, upgradeManager.randomizedUpgradesList.Count);
            while (pickedNumbers.Contains(randomInt))
            {
                randomInt = UnityEngine.Random.Range(0, upgradeManager.randomizedUpgradesList.Count);
            }

            UpgradeSO randomUpgrade = upgradeManager.randomizedUpgradesList[randomInt];

            outputUpgradesList.Add(randomUpgrade);
            pickedNumbers.Add(randomInt);
        }

        OnUpgradesRandomized?.Invoke(outputUpgradesList);
    }
}
