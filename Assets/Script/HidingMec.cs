using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingMec : MonoBehaviour
{
    [SerializeField] private Transform _hidingPos;
    
    [SerializeField]private GameObject _player;
    [SerializeField] private bool _canHide = false;
    [SerializeField] private bool _isHiding = false;


    void Start()
    {
        
    }

    void Update()
    {
        if (_player != null) {
            if (_canHide == true)
            {
                if (Input.GetKeyDown(KeyCode.E) && !_isHiding)
                {
                    Debug.Log("E");
                    _isHiding = true;
                }
            }
        }

        if (_isHiding == true) {
            Debug.Log("Hiding");

            _player.transform.position = _hidingPos.transform.position;
            _player.transform.rotation = _hidingPos.transform.rotation;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("1");
        if (other.gameObject.tag == "GameController") {
            Debug.Log("2");
            _player = other.gameObject;

            _canHide = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("3");
        _canHide = false;
    }
}
