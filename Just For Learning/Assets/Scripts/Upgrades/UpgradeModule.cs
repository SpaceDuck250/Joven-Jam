using System;
using UnityEngine;

[Serializable]
public abstract class UpgradeModule : MonoBehaviour
{
    public bool applied = false;

    public abstract void Setup(GameObject parent);

    

    public abstract void ApplyUpgrade();
}
