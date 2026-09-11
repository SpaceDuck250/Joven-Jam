using UnityEngine;

[CreateAssetMenu(fileName = "PlaceableStats", menuName = "Scriptable Objects/PlaceableStats")]
public class PlaceableStats : ScriptableObject
{
    public Sprite selfSelectSprite;
    public GameObject selfPrefab;
    public string selfName;
    public int selfCost;
}
