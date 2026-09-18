using UnityEngine;
using System;

public class YellowLuckyBlockScript : MonoBehaviour
{
    public static event Action OnClickYellowLuckyBlock;

    public void ClickYellowLuckyBlock()
    {
        OnClickYellowLuckyBlock?.Invoke();
        Destroy(gameObject);
    }
}
