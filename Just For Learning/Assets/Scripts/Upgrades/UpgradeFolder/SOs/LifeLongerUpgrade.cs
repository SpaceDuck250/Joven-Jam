using UnityEngine;

public class LifeLonger : UpgradeModule
{
    private LifeTimerScript lifeTimer;

    [SerializeField]
    private float timesAmount;

    public override void Setup(GameObject parent)
    {
        lifeTimer = parent.GetComponent<LifeTimerScript>();
    }

    public override void ApplyUpgrade()
    {
        lifeTimer.dieTime = lifeTimer.dieTime * timesAmount;
        applied = true;
    }
}
