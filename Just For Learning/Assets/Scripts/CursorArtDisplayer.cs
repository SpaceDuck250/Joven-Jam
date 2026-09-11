using UnityEngine;

public class CursorArtDisplayer : MonoBehaviour
{
    public Sprite placeableSprite;
    public GameObject cursorArtObj;
    public SpriteRenderer cursorArt;

    public bool display = false;

    public Camera cam;

    private void Start()
    {
        PlacerManagerScript.OnSelectPlaceable += ShowArt;
        PlacerManagerScript.OnPlacePlaceable += HideArt;
    }

    private void OnDestroy()
    {
        PlacerManagerScript.OnSelectPlaceable -= ShowArt;
        PlacerManagerScript.OnPlacePlaceable -= HideArt;
    }

    private void Update()
    {
        if (!display)
        {
            return;
        }

        MakeCursorArtFollowActualCursor();
    }

    public void MakeCursorArtFollowActualCursor()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        cursorArtObj.transform.position = mousePos;
    }

    public void ShowArt(GameObject selectObj, PlaceableStats placeable)
    {
        placeableSprite = placeable.selfSelectSprite;
        cursorArtObj.SetActive(true);
        cursorArt.sprite = placeableSprite;

        display = true;
    }

    public void HideArt(PlaceableStats placeable, bool placed)
    {
        cursorArtObj.SetActive(false);

        display = false;
    }
}
