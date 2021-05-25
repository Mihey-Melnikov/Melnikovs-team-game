using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public MazeSpawner maze;
    public Item item;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bird"))
        {
            maze.FinishGame();
            var key = GameObject.Find("KeyDoor");
            key.AddComponent<CollectableItem>().item = item;
            key.GetComponent<SpriteRenderer>().sortingOrder = 2;
            
            Destroy(GameObject.Find("Window2").GetComponent<StartMazeGame>());
        }
    }
}
