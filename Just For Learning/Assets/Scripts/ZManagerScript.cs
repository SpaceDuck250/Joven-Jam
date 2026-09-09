using UnityEngine;
using System;

public class ZManagerScript : MonoBehaviour
{
    public static Action OnCollectZ;
    public static Action<int> OnAmountZChanged;

    public int zAmountLeft;

    private void Start()
    {
        zAmountLeft = 0;

        OnCollectZ += CollectZ;
    }

    private void OnDestroy()
    {
        OnCollectZ -= CollectZ;
    }

    public void CollectZ()
    {
        int addAmount = 10;
        ChangeZ(addAmount);
    }

    public void ChangeZ(int addAmount)
    {
        zAmountLeft += addAmount;
        OnAmountZChanged?.Invoke(zAmountLeft);
    }

    public void SetZ(int newValue)
    {
        zAmountLeft = newValue;
        OnAmountZChanged?.Invoke(zAmountLeft);

    }
}
