using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Camera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform _player;

    private float _initialY;
    void Start()
    {
        // Get the player's transform component
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _initialY = _player.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_player.position.x, _initialY + 2.7f, transform.position.z);
    }
}
