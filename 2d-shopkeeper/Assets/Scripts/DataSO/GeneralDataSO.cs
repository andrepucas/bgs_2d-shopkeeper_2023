using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GeneralData", menuName = "Data/General Data")]
public class GeneralDataSO : ScriptableObject
{
    [Header("CAMERA")]
    [SerializeField] private float _zoomInSize;
    [SerializeField] private float _zoomOutSize;
    [SerializeField] private Vector3 _zoomInPos, _zoomOutPos;

    [Header("PLAYER")]
    [SerializeField] private Vector3 _doorPos;
    [SerializeField] private Vector3 _shopPos;
    [SerializeField] private Vector3 _spawnPos;
    [SerializeField] private int _money;

    private Dictionary<CustomizableParts, Sprite[]> _starterParts;

    public float CamZoomInSize => _zoomInSize;
    public float CamZoomOutSize => _zoomOutSize;
    public Vector3 CamZoomInPos => _zoomInPos;
    public Vector3 CamZoomOutPos => _zoomOutPos;

    public Vector3 DoorPos => _doorPos;
    public Vector3 ShopPos => _shopPos;
    public Vector3 SpawnPos => _spawnPos;

    public IReadOnlyDictionary<CustomizableParts, Sprite[]> StarterParts => _starterParts;
    public int Money {get; set;}

    public void Reset()
    {
        _starterParts = new Dictionary<CustomizableParts, Sprite[]>();
        Money = _money;
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
