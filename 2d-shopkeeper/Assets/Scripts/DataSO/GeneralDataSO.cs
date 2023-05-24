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

    public float CamZoomInSize => _zoomInSize;
    public float CamZoomOutSize => _zoomOutSize;
    public Vector3 CamZoomInPos => _zoomInPos;
    public Vector3 CamZoomOutPos => _zoomOutPos;

    public Vector3 DoorPos => _doorPos;
    public Vector3 ShopPos => _shopPos;
}
