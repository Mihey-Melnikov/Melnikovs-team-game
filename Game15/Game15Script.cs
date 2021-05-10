using System.Collections.Generic;
using Assets.Scripts.Game15;
using UnityEngine;
using UnityEngine.EventSystems;

public class Game15Script : MonoBehaviour
{
    const int size = 3;
    static Game game;

    public List<Sprite> pictures;

    void Start()
    {
        game = new Game(size);
        HideButtons();
    }

    public void OnStart()
    {
        game.Start(0);
        UpdatePosition();
        var pictureGame = GameObject.Find("pictureGame");
        pictureGame.GetComponent<SpriteRenderer>().sortingOrder = 3;
        ShowButtons();
    }

    public void OnClick(string name)
    {
        var nameX = int.Parse(name.Substring(7, 1));
        var nameY = int.Parse(name.Substring(8, 1));
        game.PressAt(nameX, nameY);
        UpdatePosition();
        ShowButtons();
        if (game.Solved())
            FinishGame();
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

    void FinishGame()
    {
        var pictureGame = GameObject.Find("pictureGame");
        foreach (var childr in pictureGame.GetComponentsInChildren<SpriteRenderer>())
            childr.sortingOrder = -1;
    }
    
    void HideButtons()
    {
        var pictureGame = GameObject.Find("pictureGame");
        pictureGame.GetComponent<SpriteRenderer>().sortingOrder = -1;
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
}
