using UnityEngine;
using System.Collections.Generic;

public class SelectionDisplayer : MonoBehaviour
{
    public List<PlaceableStats> displayItems = new List<PlaceableStats>();
    public List<GameObject> createdDisplayItems = new List<GameObject>();

    public GameObject selectDisplayPrefab;

    public Transform displayContainer;

    public ZManagerScript zManager;

    private void Start()
    {
        CreateAllDisplayItems();
    }

    public void CreateAllDisplayItems()
    {
        foreach (Transform child in displayContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (PlaceableStats placeable in displayItems)
        {
            CreateNewDisplayItem(placeable);
        }
    }

    public void CreateNewDisplayItem(PlaceableStats placeableStats)
    {
        GameObject newSelectDisplay = Instantiate(selectDisplayPrefab, displayContainer);

        newSelectDisplay.GetComponent<SelectSetup>().Setup(placeableStats, zManager);

        createdDisplayItems.Add(newSelectDisplay);
    }
}
