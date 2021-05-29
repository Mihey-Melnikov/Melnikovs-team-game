using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public bool ispuse;
    public bool isplayer;
    [SerializeField]private GameObject player;
    public List<GameObject> boxcollider;

    private void Update()
    {
        ispuse = Input.GetKeyDown(KeyCode.Escape) && !ispuse || ispuse;
        var pause = GameObject.Find("Pause");
        
        if (ispuse)
        {
            foreach (var childr in pause.GetComponentsInChildren<SpriteRenderer>())
                childr.sortingOrder = 11;
            pause.GetComponent<SpriteRenderer>().sortingOrder = 10;
            foreach (var childr in pause.GetComponentsInChildren<Button>())
                childr.enabled = true; 
        }
        else 
        {
            foreach (var childr in pause.GetComponentsInChildren<SpriteRenderer>())
                childr.sortingOrder = -1;
            foreach (var childr in pause.GetComponentsInChildren<Button>())
                childr.enabled = false;
        }
        if (isplayer || ispuse)
        {
            RemoveBC();
            player.GetComponent<BoxCollider2D>().enabled = false;

        }
        else
        {
            AddBC();
            player.GetComponent<BoxCollider2D>().enabled = true;
        }
        
    }

    private void RemoveBC()
    {
        foreach (var childr in boxcollider)
        {
            childr.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void AddBC()
    {
        foreach (var childr in boxcollider)
        {
            childr.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

}
