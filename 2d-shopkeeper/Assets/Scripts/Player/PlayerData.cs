using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [Header("BODY PARTS")]
    [SerializeField] private SpriteRenderer _hair;
    [SerializeField] private SpriteRenderer _face;
    [SerializeField] private SpriteRenderer _torso;
    [SerializeField] private SpriteRenderer _lShoulder;
    [SerializeField] private SpriteRenderer _rShoulder;
    [SerializeField] private SpriteRenderer _lElbow;
    [SerializeField] private SpriteRenderer _rElbow;
    [SerializeField] private SpriteRenderer _lWrist;
    [SerializeField] private SpriteRenderer _rWrist;
    [SerializeField] private SpriteRenderer _lWeapon;
    [SerializeField] private SpriteRenderer _rWeapon;
    [SerializeField] private SpriteRenderer _pelvis;
    [SerializeField] private SpriteRenderer _lLeg;
    [SerializeField] private SpriteRenderer _rLeg;
    [SerializeField] private SpriteRenderer _lBoot;
    [SerializeField] private SpriteRenderer _rBoot;

    [Header("SPRITES")]
    [SerializeField] private AllCustomizablePartsSO _allParts;

    private Sprite _equippedHair;

    private HashSet<Sprite> _ownedHair;

    private void Awake()
    {
        _ownedHair = new HashSet<Sprite>();
        _ownedHair.Add(_hair.sprite);
        _equippedHair = _hair.sprite;
    }
}
