using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSet", menuName = "Match3/Item")] 
public class ItemSet : ScriptableObject
{
    public List<Sprite> Items;
}