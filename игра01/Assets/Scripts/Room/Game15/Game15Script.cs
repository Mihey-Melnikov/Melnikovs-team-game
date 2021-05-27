using System.Collections.Generic;
using UnityEngine;

public class Game15Script : MonoBehaviour
{
    private const int Size = 3;
    private static Game game;
    [SerializeField] private Pause pause;
    [SerializeField] private Item item;

    [SerializeField]private List<Sprite> pictures;

    public void Start()
    {
        game = new Game(Size);
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
        GameObject.Find("RulePicture").GetComponent<Canvas>().sortingOrder = 4;
        foreach (var childr in pictureGame.GetComponentsInChildren<BoxCollider2D>())
            childr.enabled = true;
        ShowButtons();
    }

    public void OnClick(string name)
    {
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

    private void Bring()
    {
        var inventory = GameObject.Find("player").GetComponent<Inventory>();
        inventory.AddItems(item);
    }

    private void ShowButtons()
    {
        for (var x = 0; x < Size; x++)
        for (var y = 0; y < Size; y++)
            ShowDigitAt(game.GetDigitAt(x, y), x, y);
    }

    private void ShowDigitAt(int digit, int x, int y)
    {
        var name = "picture" + x + "" + y;
        var button = GameObject.Find(name);
        button.GetComponent<SpriteRenderer>().sortingOrder = digit > 0 ? 4 : -1;
    }

    private void FinishGame()
    {
        var pictureGame = GameObject.Find("pictureGame");
        foreach (var childr in pictureGame.GetComponentsInChildren<SpriteRenderer>())
            childr.sortingOrder = -1;
        var back = GameObject.Find("back");
        back.GetComponent<SpriteRenderer>().sortingOrder = -1;
        back.GetComponent<BoxCollider2D>().enabled = false;
        GameObject.Find("RulePicture").GetComponent<Canvas>().sortingOrder = -1;
        foreach (var childr in pictureGame.GetComponentsInChildren<BoxCollider2D>())
            childr.enabled = false;
        
    }

    private void HideButtons()
    {
        var pictureGame = GameObject.Find("pictureGame");
        pictureGame.GetComponent<SpriteRenderer>().sortingOrder = -1;
        var back = GameObject.Find("back");
        back.GetComponent<SpriteRenderer>().sortingOrder = -1;
        GameObject.Find("RulePicture").GetComponent<Canvas>().sortingOrder = -1;
        for (var x = 0; x < Size; x++)
        for (var y = 0; y < Size; y++)
            ShowDigitAt(0, x, y);
    }

    private void UpdatePosition()
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

    private bool StartPosition()
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
