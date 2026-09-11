using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectSetup : MonoBehaviour
{
    public PlaceableStats placeableHeld;
    public SelectPickScript selectPickScript;

    public Image image;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI costText;

    public GameObject redBuyBlocker;

    public void Setup(PlaceableStats placeable, ZManagerScript zManager)
    {
        placeableHeld = placeable;
        selectPickScript.placeable = placeableHeld; 
        selectPickScript.zManager = zManager;

        image.sprite = placeableHeld.selfSelectSprite;
        nameText.SetText(placeableHeld.selfName);
        costText.SetText(placeableHeld.selfCost.ToString() + "Z");

        if (zManager.zAmountLeft < placeable.selfCost)
        {
            redBuyBlocker.SetActive(true);
        }

        ZManagerScript.OnAmountZChanged += OnAmountZChanged;
    }

    private void OnDestroy()
    {
        ZManagerScript.OnAmountZChanged -= OnAmountZChanged;
    }

    public void OnAmountZChanged(int newZAmount)
    {
        bool setActive = (newZAmount < placeableHeld.selfCost) ? true : false;

        redBuyBlocker.SetActive(setActive);
    }
}
