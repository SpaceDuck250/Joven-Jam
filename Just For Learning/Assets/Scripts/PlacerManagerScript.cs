using UnityEngine;
using System;

public class PlacerManagerScript : MonoBehaviour
{
    public static Action<GameObject, PlaceableStats> OnSelectPlaceable;

    public static Action<PlaceableStats, bool> OnPlacePlaceable;

    public GameObject selectedSelector;
    public PlaceableStats selectedPlaceable;
    public bool havePlaceableOnHand;

    public LayerMask placeableLayer;

    public Camera cam;

    private void Start()
    {
        OnSelectPlaceable += SelectPlaceable;
    }

    private void OnDestroy()
    {
        OnSelectPlaceable -= SelectPlaceable;

    }

    public void SelectPlaceable(GameObject selectedSelector, PlaceableStats placeable)
    {
        this.selectedSelector = selectedSelector;
        this.selectedPlaceable = placeable;

        havePlaceableOnHand = true;
    }

    private void Update()
    {
        if (!havePlaceableOnHand)
        {
            return;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            havePlaceableOnHand = false;
            TryPlace();

        }
    }

    public void TryPlace()
    {

        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Collider2D collider = Physics2D.OverlapPoint(mousePos, placeableLayer);
        if (collider != null)
        {
            Instantiate(selectedPlaceable.selfPrefab, mousePos, Quaternion.identity);
            OnPlacePlaceable?.Invoke(selectedPlaceable, true);
            return;
        }

        OnPlacePlaceable?.Invoke(selectedPlaceable, false);


    }

}
