using System.Collections.Generic;
using Assets.Scripts.Game15;
using UnityEngine;
using UnityEngine.EventSystems;

public class Game15Script : MonoBehaviour
{
    const int size = 3;
    static Game game;
    public Pause pause;
    public Item item;

    public List<Sprite> pictures;

    public void Start()
    {
        game = new Game(size);
        HideButtons();
    }

    public void OnStart()
    {
        game.Start();
        UpdatePosition();
        GameObject.Find("back").GetComponent<BoxCollider2D>().enabled = true;
        var pictureGame = GameObject.Find("pictureGame");
        pictureGame.GetComponent<SpriteRenderer>().sortingOrder = 3;
        var back = GameObject.Find("back");
        back.GetComponent<SpriteRenderer>().sortingOrder = 4;
        foreach (var childr in pictureGame.GetComponentsInChildren<BoxCollider2D>())
            childr.enabled = true;
        ShowButtons();
    }

    public void OnClick(string name)
    {
        if (name.Substring(0, 7) != "picture") return;
        if (StartPosition())
        {
            var picture1 = GameObject.Find("picture1");
            Destroy(picture1.GetComponent<PictureScript>());
            FinishGame();
            pause.isplayer = false;
            Bring();
            
            return;
        }
        var nameX = int.Parse(name.Substring(7, 1));
        var nameY = int.Parse(name.Substring(8, 1));
        game.PressAt(nameX, nameY);
        UpdatePosition();
        ShowButtons();
        if (StartPosition())
        {
            var picture1 = GameObject.Find("picture1");
            Destroy(picture1.GetComponent<PictureScript>());
            FinishGame();
            Bring();
            pause.isplayer = false;
        }
    }

    void Bring()
    {
        var inventory = GameObject.Find("player").GetComponent<Inventory>();
        if (inventory && inventory.AddItems(item)) ;
    }

    void ShowButtons()
    {
        for (var x = 0; x < size; x++)
        for (var y = 0; y < size; y++)
            ShowDigitAt(game.GetDigitAt(x, y), x, y);
    }

    void ShowDigitAt(int digit, int x, int y)
    {
        var name = "picture" + x + "" + y;
        var button = GameObject.Find(name);
        button.GetComponent<SpriteRenderer>().sortingOrder = digit > 0 ? 4 : -1;
    }

    public void FinishGame()
    {
        var pictureGame = GameObject.Find("pictureGame");
        foreach (var childr in pictureGame.GetComponentsInChildren<SpriteRenderer>())
            childr.sortingOrder = -1;
        var back = GameObject.Find("back");
        back.GetComponent<SpriteRenderer>().sortingOrder = -1;
        back.GetComponent<BoxCollider2D>().enabled = false;
        foreach (var childr in pictureGame.GetComponentsInChildren<BoxCollider2D>())
            childr.enabled = false;
        
    }
    
    void HideButtons()
    {
        var pictureGame = GameObject.Find("pictureGame");
        pictureGame.GetComponent<SpriteRenderer>().sortingOrder = -1;
        var back = GameObject.Find("back");
        back.GetComponent<SpriteRenderer>().sortingOrder = -1;
        for (var x = 0; x < size; x++)
        for (var y = 0; y < size; y++)
            ShowDigitAt(0, x, y);
    }
    
    void UpdatePosition()
    {
        var pictureGame = GameObject.Find("pictureGame");
        foreach (var picture in pictureGame.GetComponentsInChildren<SpriteRenderer>())
        {
            if (picture.gameObject.Equals(pictureGame)) continue;
            var name = picture.name;
            var nameX = int.Parse(name.Substring(7, 1));
            var nameY = int.Parse(name.Substring(8, 1));
            var digital = game.GetDigitAt(nameX, nameY);
            picture.sprite = pictures[digital];
        }
    }
    
    bool StartPosition()
    {
        var pictureGame = GameObject.Find("pictureGame");
        foreach (var picture in pictureGame.GetComponentsInChildren<SpriteRenderer>())
        {
            if (picture.gameObject.Equals(pictureGame)) continue;
            var name = picture.name;
            var nameSprit = picture.sprite.name;
            if (name != nameSprit) return false;
        }
        return true;
    }
}
