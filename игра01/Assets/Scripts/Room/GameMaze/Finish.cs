using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private MazeSpawner maze;
    [SerializeField] private Item item;
    [SerializeField] private Pause pause;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Bird")) return;
        maze.FinishGame();
        var key = GameObject.Find("KeyDoor");
        key.AddComponent<TakingCollectableItem>().item = item;
        key.GetComponent<TakingCollectableItem>().pause = pause;
        key.GetComponent<SpriteRenderer>().sortingOrder = 2;
            
        Destroy(GameObject.Find("Window2").GetComponent<StartMazeGame>());
    }
}
