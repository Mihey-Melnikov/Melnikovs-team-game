using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Papper : MonoBehaviour
{
    [SerializeField] private GameObject papper;
    [SerializeField] private Inventory inventory;
    [SerializeField]private Pause pause;
    private bool[] collected = new bool[4];

    public void Start()
    {
        var back = GameObject.Find("BackPapper");
        back.GetComponent<SpriteRenderer>().sortingOrder = -1;
        back.GetComponent<BoxCollider2D>().enabled = false;
        
        foreach (var item in papper.GetComponentsInChildren<SpriteRenderer>())
        {
            item.sortingOrder = -1;
        }
        papper.GetComponent<Canvas>().sortingOrder = -1;
        
    }
    
    void Update()
    {
        var children = papper.GetComponentsInChildren<SpriteRenderer>();
        for (var i = 0; i < children.Length; i++)
        {
            foreach (var item in inventory.items.Where(item => item.name == children[i].tag))
            {
                collected[i] = true;
            }
        }
    }

    public void OnMouseDown()
    {
        var children = papper.GetComponentsInChildren<SpriteRenderer>();
        pause.isplayer = true;
        for (var i=0; i< children.Length; i++)
        {
            if (collected[i]) children[i].sortingOrder = 5;
        }
        papper.GetComponent<Canvas>().sortingOrder = 4;
        var back = GameObject.Find("BackPapper");
        back.GetComponent<SpriteRenderer>().sortingOrder = 5;
        back.GetComponent<BoxCollider2D>().enabled = true;
    }
}
