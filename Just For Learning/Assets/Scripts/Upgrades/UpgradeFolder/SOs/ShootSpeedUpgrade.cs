using UnityEngine;

public class ShootSpeedUpgrade : UpgradeModule
{
    public float newAmount;
    public TurretScript turretScript;
    public override void Setup(GameObject parent)
    {
        turretScript = parent.GetComponent<TurretScript>();
    }


    public override void ApplyUpgrade()
    {
        if (applied)
        {
            return; 
        }

        turretScript.fireRate = newAmount;
        applied = true;
    }
}
