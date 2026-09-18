using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UpgradeOptionSetup : MonoBehaviour
{
    public UpgradeSO heldUpgradeData;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descText;

    public Image upgradeImage;

    public delegate void UpgradeHandler(UpgradeSO heldUpgradeData);
    public static event UpgradeHandler OnPickNewUpgrade;

    public void SetupSelf(UpgradeSO upgradeData)
    {
        nameText.text = upgradeData.upgradeName;
        descText.text = upgradeData.upgradeDescription;

        upgradeImage.sprite = upgradeData.upgradeSprite;

        heldUpgradeData = upgradeData;
    }

    public void PickThis()
    {
        OnPickNewUpgrade?.Invoke(heldUpgradeData);
    }
}
