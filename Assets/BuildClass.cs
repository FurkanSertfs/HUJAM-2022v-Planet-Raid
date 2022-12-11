using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Build ", menuName = "Crate  New Build")]


public class BuildClass : ScriptableObject
{
    [NonReorderable]
    public List<BuildResources> buildResources = new List<BuildResources>();

    public GameObject buildPreview;

    public GameObject buildPrefab;

   
}

[System.Serializable]
public class BuildResources
{
    public Resources.ResourcesType resourcesType;
    
    public int resourcesCount;

}