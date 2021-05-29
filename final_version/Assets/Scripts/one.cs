using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;

public class one : MonoBehaviour
{
    private float x = 0;
    private float a = 0;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Application.LoadLevel("LevelOne"); 
        var wall = GameObject.Find("Wall");
        var door = GameObject.Find("Door");
        var black = GameObject.Find("Black");
        if (wall.transform.localScale.x < 24)
        {
            foreach (var child in wall.GetComponentsInChildren(typeof(Transform)))
            {
                child.transform.localScale *= ( 1 + Time.deltaTime / 20);
            }
        }
        else if (x < 100)
        {
            x += 0.12f;
            door.transform.rotation = Quaternion.Euler(door.transform.rotation.x, door.transform.rotation.y + x , 
                door.transform.rotation.z);
        }
        else if (a < 255)
        {
            a += 1f;
            black.GetComponent<SpriteRenderer>().color = new Vector4(0, 0, 0, a);
        }
        else Application.LoadLevel("LevelOne");
    }
}
