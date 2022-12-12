using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Build ", menuName = "Crate  New Build")]


public class BuildClass : ScriptableObject
{
    [NonReorderable]
    //  public List<BuildResources> buildResources = new List<BuildResources>();

    public int price;

    public GameObject buildPreview;

    public GameObject buildPrefab;

    public int health;
}

[System.Serializable]
public class BuildResources
{
    public Resources.ResourcesType resourcesType;
    
    public int resourcesCount;

}