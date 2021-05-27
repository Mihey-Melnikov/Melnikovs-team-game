using UnityEngine;
using UnityEngine.Serialization;

public class MazeSpawner : MonoBehaviour
{
    [FormerlySerializedAs("CellPrefab")] public Cell cellPrefab;
    [FormerlySerializedAs("CellSize")] public Vector3 cellSize = new Vector3(1, 1, 0);
    [SerializeField]private Pause pause;
    private Maze maze;

    public void Start()
    {
        var generator = new MazeGenerator();
        var window = GameObject.Find("Sky").transform;
        var lossyScale = window.lossyScale;
        cellSize = new Vector3(lossyScale.x / (MazeGenerator.Width - 1),
            lossyScale.y / (MazeGenerator.Height - 1), 0);
        maze = generator.GenerateMaze();
    }

    public void OnStart()
    {
        var mazeGame = GameObject.Find("MazeGame");
        foreach (var childr in mazeGame.GetComponentsInChildren<SpriteRenderer>())
            childr.sortingOrder += 6;
        GameObject.Find("RuleMaze").GetComponent<Canvas>().sortingOrder += 6;
        GameObject.Find("backMaze").GetComponent<BoxCollider2D>().enabled = true;
        
        var window = GameObject.Find("Sky").transform;
        var lossyScale = window.lossyScale;
        var startMaze = window.position - new Vector3(lossyScale.x / 2, lossyScale.y / 2, 0);
        for (var x = 0; x < maze.Cells.GetLength(0); x++)
        {
            for (var y = 0; y < maze.Cells.GetLength(1); y++)
            {
                var c = Instantiate(cellPrefab, (new Vector3(x * cellSize.x, y * cellSize.y, 0) + startMaze), 
                    Quaternion.identity, GameObject.Find("Cell").transform);

                c.wallBottom.SetActive(maze.Cells[x, y].WallBottom);
                c.wallLeft.SetActive(maze.Cells[x, y].WallLeft);
            }
        }
        GameObject.Find("FinishMaze").transform.position = startMaze 
                                                           + new Vector3(maze.FinishPosition.x * cellSize.x, maze.FinishPosition.y * cellSize.y,0) 
                                                           + new Vector3(cellSize.x / 2, cellSize.y / 2, 0);
        GameObject.Find("bird401").transform.position = startMaze + new Vector3(cellSize.x / 2, cellSize.y / 2, 0);
    }
    
    public void FinishGame()
    {
        var cell = GameObject.Find("Cell");
        foreach (var childr in cell.GetComponentsInChildren<Transform>())
            if (childr.name != "Cell") Destroy(childr.gameObject);
        var pictureGame = GameObject.Find("MazeGame");
        foreach (var childr in pictureGame.GetComponentsInChildren<SpriteRenderer>())
            childr.sortingOrder -= 6;
        foreach (var childr in pictureGame.GetComponentsInChildren<BoxCollider2D>())
            childr.enabled = false;
        GameObject.Find("backMaze").GetComponent<BoxCollider2D>().enabled = false;
        pause.isplayer = false;
        GameObject.Find("RuleMaze").GetComponent<Canvas>().sortingOrder -= 6;

    }
    
    
}