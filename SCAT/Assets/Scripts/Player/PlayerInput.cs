using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerData player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerData>();        
    }

    // Update is called once per frame
    void Update() 
    {
        if (Input.GetButtonDown("Locked"))
        {
            player.isExtraGunLocked = !player.isExtraGunLocked;
        }

        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");
        player.moveDirection = new Vector2(x, y);
    }
}
