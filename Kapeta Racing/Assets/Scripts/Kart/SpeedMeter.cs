using UnityEngine;
using Photon.Pun;
using TMPro;

public class SpeedMeter : MonoBehaviour
{
    [SerializeField] GameObject _speedMeterOBJ;
    [SerializeField] Rigidbody _KartBody;
    [SerializeField] PhotonView _photonView;
    // MAX VEHICLE SPEED* IN KM/H **
    [SerializeField] float _maxSpeed = 0.0f; 

    [SerializeField] float _lowArrowAngle;
    [SerializeField] float _highArrowAngle;

    [Header("UI")]//SPEED COUNTER TEXT
    [SerializeField] TMP_Text _speedText; 
   //SPEED METER ARROW
    [SerializeField] RectTransform _arrow; 

    float _speed = 0.0f;

    void Start()
    {
        if (!_photonView.IsMine)
        {
            _speedMeterOBJ.SetActive(false);
        }
    }

    private void Update()
    {
        if (_photonView.IsMine)
        {
            // 3.6f for KM 
            _speed = _KartBody.velocity.magnitude * 3.6f;

            if (_speedText != null)
            {
                _speedText.text = ((int)_speed) + " KM/H";
            }
                
            if (_arrow != null)
            {
                _arrow.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(_lowArrowAngle, _highArrowAngle, _speed / _maxSpeed));
            }

            if(_speed >= _maxSpeed)
            {
                Debug.Log("MAX SPEED!!!", gameObject);
                _speedText.gameObject.SetActive(false);
                
            }
            else
            {
                _speedText.gameObject.SetActive(true);
                
            }
        }
    }
}
