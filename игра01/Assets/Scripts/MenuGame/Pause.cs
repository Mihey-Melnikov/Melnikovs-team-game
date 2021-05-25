using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public bool ispuse;
    public bool isplayer;
    public GameObject player;
    public List<GameObject> boxcollider;

    void Update()
    {
        ispuse = Input.GetKeyDown(KeyCode.Escape) && !ispuse || ispuse;
        var pause = GameObject.Find("Pause");
        
        if (ispuse)
        {
            player.GetComponent<PlayerController>().enabled = false;
            foreach (var childr in pause.GetComponentsInChildren<SpriteRenderer>())
                childr.sortingOrder = 11;
            pause.GetComponent<SpriteRenderer>().sortingOrder = 10;
            foreach (var childr in pause.GetComponentsInChildren<Button>())
                childr.enabled = true; 
        }
        else 
        {
            player.GetComponent<PlayerController>().enabled = true;
            foreach (var childr in pause.GetComponentsInChildren<SpriteRenderer>())
                childr.sortingOrder = -1;
            foreach (var childr in pause.GetComponentsInChildren<Button>())
                childr.enabled = false;
        }
        if (isplayer || ispuse)
        {
            player.GetComponent<PlayerController>().enabled = false;
            RemoveBC();
            player.GetComponent<BoxCollider2D>().enabled = false;
            player.GetComponent<PlayerController>().enabled = false;

        }
        else
        {
            player.GetComponent<PlayerController>().enabled = true;
            AddBC();
            player.GetComponent<BoxCollider2D>().enabled = true;
            player.GetComponent<PlayerController>().enabled = true;
        }
        
    }

    public void RemoveBC()
    {
        foreach (var childr in boxcollider)
            childr.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void AddBC()
    {
        foreach (var childr in boxcollider)
        {
            childr.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

}
