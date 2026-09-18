using UnityEngine;
using System.Collections.Generic;

public class UpgradeOptionsUIScript : MonoBehaviour
{
    public UpgradeOptionSetup upgradeOptionPrefab;

    public Transform container;

    public UpgradeRandomizer randomizer;

    public GameObject optionsPanel;

    private void Start()
    {
        randomizer.OnUpgradesRandomized += OnUpgradesRandomized;
        UpgradeOptionSetup.OnPickNewUpgrade += OnPickNewUpgrade;
    }



    private void OnDestroy()
    {
        randomizer.OnUpgradesRandomized -= OnUpgradesRandomized;
        UpgradeOptionSetup.OnPickNewUpgrade -= OnPickNewUpgrade;

    }

    private void OnPickNewUpgrade(UpgradeSO heldUpgradeData)
    {
        optionsPanel.SetActive(false);
    }

    private void OnUpgradesRandomized(List<UpgradeSO> listOfUpgrades)
    {
        CreateAllOptionUI(listOfUpgrades);
        optionsPanel.SetActive(true);
    }

    public void CreateAllOptionUI(List<UpgradeSO> upgradeDataList)
    {
        ClearContainer();

        foreach (UpgradeSO upgradeData in upgradeDataList)
        {
            CreateOptionUI(upgradeData);
        }
    }

    public void CreateOptionUI(UpgradeSO upgradeData)
    {
        UpgradeOptionSetup newOptionUI = Instantiate(upgradeOptionPrefab, container);

        newOptionUI.SetupSelf(upgradeData);
    }

    public void ClearContainer()
    {
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }
    }

}
