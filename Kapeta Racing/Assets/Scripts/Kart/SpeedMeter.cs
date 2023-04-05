using UnityEngine;
using Photon.Pun;
using TMPro;

public class SpeedMeter : MonoBehaviour
{
    [SerializeField] GameObject _speedMeterOBJ;
    [SerializeField] Rigidbody _KartBody;
    // PhotonView component of the player
    [SerializeField] PhotonView _photonView;
   
    [SerializeField] float _maxSpeed = 0.0f; 

    public float baseAcceleration;
    private float currentSpeed;
    private AudioSource EngineAudioSource;
    public float minPitch;
    public float maxPitch;
    private float EngineAudio;

    [SerializeField] float _lowArrowAngle;
    [SerializeField] float _highArrowAngle;

    [Header("UI")]//SPEED COUNTER TEXT
    [SerializeField] TMP_Text _speedText; 
   //SPEED METER ARROW
    [SerializeField] RectTransform _arrow; 

    float _ConstSpeed = 0.0f;

    void Start()
    {
        if (!_photonView.IsMine)
        {
            _speedMeterOBJ.SetActive(false);
        }

        EngineAudioSource = GetComponent<AudioSource>();
        
    }

    private void Update()
    {
        if (_photonView.IsMine)
        {
            // 3.6f for KM 
            _ConstSpeed = _KartBody.velocity.magnitude * 3.6f;

            if (_speedText != null)
            {
                _speedText.text = ((int)_ConstSpeed) + " KM/H";
            }
                
            if (_arrow != null)
            {
                _arrow.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(_lowArrowAngle, _highArrowAngle, _ConstSpeed / _maxSpeed));
            }

            if(_ConstSpeed >= _maxSpeed)
            {
                Debug.Log("MAX SPEED!!!", gameObject);
                _speedText.gameObject.SetActive(false);
                
            }
            else
            {
                _speedText.gameObject.SetActive(true);
                
            }
        }

        EngineSound();
    }

     void EngineSound()
    {
        currentSpeed = _KartBody.velocity.magnitude;
        EngineAudio = _KartBody.velocity.magnitude / 60f;

        if(currentSpeed < baseAcceleration)
        {
            EngineAudioSource.pitch = minPitch;
        }

        if(currentSpeed > baseAcceleration && currentSpeed < _maxSpeed)
        {
            EngineAudioSource.pitch = minPitch + EngineAudio;
        }

        if(currentSpeed > _maxSpeed)
        {
            EngineAudioSource.pitch = maxPitch;
        }
    }
}
