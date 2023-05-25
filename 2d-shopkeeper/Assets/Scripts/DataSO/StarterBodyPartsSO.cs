using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StarterPartsData", menuName = "Data/Starter Parts")]
public class StarterBodyPartsSO : ScriptableObject
{
    private Dictionary<CustomizableParts, Sprite[]> _starterParts;
    
    public IReadOnlyDictionary<CustomizableParts, Sprite[]> StarterParts => _starterParts;

    public void Reset()
    {
        _starterParts = new Dictionary<CustomizableParts, Sprite[]>();
    }
    
    public void AddPart(CustomizableParts p_bodyPart, Sprite[] p_sprites)
    {
        _starterParts.Add(p_bodyPart, p_sprites);
    }

    public bool Contains(CustomizableParts p_bodyPart, Sprite p_sprite)
    {
        foreach(Sprite f_sprite in _starterParts[p_bodyPart])
            if(f_sprite == p_sprite)
                return true;

        return false;
    }
}