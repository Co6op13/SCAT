using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerData _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<PlayerData>();        
    }

    // Update is called once per frame
    void Update() 
    {
        if (Input.GetButtonDown("Locked"))
        {
            _player.isExtraGunLocked = !_player.isExtraGunLocked;
        }

        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");
        _player._moveDirection = new Vector2(x, y);
    }
}
