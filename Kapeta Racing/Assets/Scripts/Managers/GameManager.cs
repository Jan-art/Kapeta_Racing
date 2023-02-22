using System.Collections;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _playerPrefab;
    

    void Start()
    {
        //TODO: Spawn Player
        SpawnPlayer();

    
    }

    void SpawnPlayer()
    {
        GameObject _player = PhotonNetwork.Instantiate(_playerPrefab.name, _playerPrefab.transform.position, _playerPrefab.transform.rotation);
        Debug.Log("Spawned Player", _player);
    }
}
