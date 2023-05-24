using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AllCustomizableParts", menuName = "Data/All Parts")]
public class AllCustomizablePartsSO : ScriptableObject
{
    [Header("HAIR")]
    [SerializeField] private Sprite[] _hairParts;

    [Header("FACE")]
    [SerializeField] private Sprite[] _faceParts;

    [Header("TORSO")]
    [SerializeField] private Sprite[] _torsoParts;

    [Header("LEFT SHOULDER")]
    [SerializeField] private Sprite[] _lShoulderParts;

    [Header("RIGHT SHOULDER")]
    [SerializeField] private Sprite[] _rShoulderParts;

    [Header("LEFT ELBOW")]
    [SerializeField] private Sprite[] _lElbowParts;

    [Header("RIGHT ELBOW")]
    [SerializeField] private Sprite[] _rElbowParts;

    [Header("LEFT WRIST")]
    [SerializeField] private Sprite[] _lWristParts;

    [Header("RIGHT WRIST")]
    [SerializeField] private Sprite[] _rWristParts;

    [Header("WEAPONS")]
    [SerializeField] private Sprite[] _weaponParts;

    [Header("PELVIS")]
    [SerializeField] private Sprite[] _pelvisParts;

    [Header("LEFT LEG")]
    [SerializeField] private Sprite[] _lLegParts;

    [Header("RIGHT LEG")]
    [SerializeField] private Sprite[] _rLegParts;

    [Header("LEFT BOOT")]
    [SerializeField] private Sprite[] _lBootParts;

    [Header("RIGHT BOOT")]
    [SerializeField] private Sprite[] _rBootParts;

    public Sprite[] Hair => _hairParts;
    public Sprite[] Face => _faceParts;
    public Sprite[] Torso => _torsoParts;
    public Sprite[] LeftShoulder => _lShoulderParts;
    public Sprite[] RightShoulder => _rShoulderParts;
    public Sprite[] LeftElbow => _lElbowParts;
    public Sprite[] RightElbow => _rElbowParts;
    public Sprite[] LeftWrist => _lWristParts;
    public Sprite[] RightWrist => _rWristParts;
    public Sprite[] Weapon => _weaponParts;
    public Sprite[] Pelvis => _pelvisParts;
    public Sprite[] LeftLeg => _lLegParts;
    public Sprite[] RightLeg => _rLegParts;
    public Sprite[] LeftBoot => _lBootParts;
    public Sprite[] RightBoot => _rBootParts;
}


