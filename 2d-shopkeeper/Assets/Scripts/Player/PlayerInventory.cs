using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // --- VARIABLES -----------------------------------------------------------

    [Header("BODY PARTS")]
    [SerializeField] private SpriteRenderer _hood;
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

    [Header("DATA")]
    [SerializeField] private StarterBodyPartsSO _starterParts;

    // --- ON OBJECT STARTUP ---------------------------------------------------

    private void Awake()
    {
        _starterParts.Reset();
        
        _starterParts.AddPart(
            CustomizableParts.HOOD, 
            new Sprite[]{_hood.sprite});

        _starterParts.AddPart(
            CustomizableParts.FACE, 
            new Sprite[]{_face.sprite});

        _starterParts.AddPart(
            CustomizableParts.TORSO, 
            new Sprite[]{_torso.sprite});

        _starterParts.AddPart(
            CustomizableParts.SHOULDERS, 
            new Sprite[]{_lShoulder.sprite, _rShoulder.sprite});

        _starterParts.AddPart(
            CustomizableParts.ELBOWS, 
            new Sprite[]{_lElbow.sprite, _rElbow.sprite});

        _starterParts.AddPart(
            CustomizableParts.WRISTS, 
            new Sprite[]{_lWrist.sprite, _rWrist.sprite});

        _starterParts.AddPart(
            CustomizableParts.WEAPONS, 
            new Sprite[]{_lWeapon.sprite, _rWeapon.sprite});

        _starterParts.AddPart(
            CustomizableParts.PELVIS, 
            new Sprite[]{_pelvis.sprite});

        _starterParts.AddPart(
            CustomizableParts.LEGS, 
            new Sprite[]{_lLeg.sprite, _rLeg.sprite});

        _starterParts.AddPart(
            CustomizableParts.BOOTS, 
            new Sprite[]{_lBoot.sprite, _rBoot.sprite});
    }
    
    private void OnEnable()
    {
        ShopItemCard.OnEquip += EquipItem;
    }

    private void OnDisable()
    {
        ShopItemCard.OnEquip -= EquipItem;
    }

    // --- METHODS -------------------------------------------------------------

    private void EquipItem(Sprite[] p_sprites, CustomizableParts p_bodyPart)
    {
        switch (p_bodyPart)
        {
            case CustomizableParts.HOOD:
                _hood.sprite = p_sprites[0];
                break;

            case CustomizableParts.FACE:
                _face.sprite = p_sprites[0];
                break;

            case CustomizableParts.TORSO:
                _torso.sprite = p_sprites[0];
                break;

            case CustomizableParts.SHOULDERS:
                _lShoulder.sprite = p_sprites[0];
                _rShoulder.sprite = p_sprites[1];
                break;

            case CustomizableParts.ELBOWS:
                _lElbow.sprite = p_sprites[0];
                _rElbow.sprite = p_sprites[1];
                break;

            case CustomizableParts.WRISTS:
                _lWrist.sprite = p_sprites[0];
                _rWrist.sprite = p_sprites[1];
                break;

            case CustomizableParts.WEAPONS:
                _lWeapon.sprite = p_sprites[0];
                _rWeapon.sprite = p_sprites[1];
                break;

            case CustomizableParts.PELVIS:
                _pelvis.sprite = p_sprites[0];
                break;

            case CustomizableParts.LEGS:
                _lLeg.sprite = p_sprites[0];
                _rLeg.sprite = p_sprites[1];
                break;

            case CustomizableParts.BOOTS:
                _lBoot.sprite = p_sprites[0];
                _rBoot.sprite = p_sprites[1];
                break;
        }
    }
}
