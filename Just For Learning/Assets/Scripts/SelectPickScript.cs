using UnityEngine;

public class SelectPickScript : MonoBehaviour
{
    public PlaceableStats placeable;

    public ZManagerScript zManager;

    public void Pick()
    {
        if (zManager.zAmountLeft < placeable.selfCost)
        {
            return;
        }

        PlacerManagerScript.OnSelectPlaceable?.Invoke(gameObject, placeable);
    }
}
