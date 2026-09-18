using System;
using UnityEngine;

[Serializable]
public abstract class UpgradeModule : MonoBehaviour
{
    //public UpgradeMod nextTierUpgradeModule;

    public bool applied = false;

    public abstract void Setup(GameObject parent);

    

    public abstract void ApplyUpgrade();
}
