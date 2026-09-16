using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "GOLibrary", menuName = "Scriptable Objects/GOLibrary")]
public class GOLibrary : ScriptableObject
{
    public string libraryName;
    public List<GameObject> objList = new List<GameObject>();
}
