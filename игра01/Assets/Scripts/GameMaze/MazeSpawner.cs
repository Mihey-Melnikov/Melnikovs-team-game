using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    public Cell CellPrefab;
    public Vector3 CellSize = new Vector3(1, 1, 0);
    public Pause pause;
    public Maze maze;

    public void Start()
    {
        var generator = new MazeGenerator();
        var Window = GameObject.Find("Sky").transform;
        CellSize = new Vector3(Window.lossyScale.x / (generator.Width - 1),
            Window.lossyScale.y / (generator.Height - 1), 0);
        maze = generator.GenerateMaze();
    }

    public void OnStart()
    {
        var mazeGame = GameObject.Find("MazeGame");
        foreach (var childr in mazeGame.GetComponentsInChildren<SpriteRenderer>())
            childr.sortingOrder += 6;
        GameObject.Find("backMaze").GetComponent<BoxCollider2D>().enabled = true;
        
        var Window = GameObject.Find("Sky").transform;
        var finish = new Vector3();
        var startMaze = Window.position - new Vector3(Window.lossyScale.x / 2, Window.lossyScale.y / 2, 0);
        for (var x = 0; x < maze.cells.GetLength(0); x++)
        {
            for (var y = 0; y < maze.cells.GetLength(1); y++)
            {
                var c = Instantiate(CellPrefab, (new Vector3(x * CellSize.x, y * CellSize.y, 0) + startMaze), 
                    Quaternion.identity, GameObject.Find("Cell").transform);

                c.WallBottom.SetActive(maze.cells[x, y].WallBottom);
                c.WallLeft.SetActive(maze.cells[x, y].WallLeft);
            }
        }
        GameObject.Find("FinishMaze").transform.position = startMaze 
                                                           + new Vector3(maze.finishPosition.x * CellSize.x, maze.finishPosition.y * CellSize.y,0) 
                                                           + new Vector3(CellSize.x / 2, CellSize.y / 2, 0);
        GameObject.Find("bird401").transform.position = startMaze + new Vector3(CellSize.x / 2, CellSize.y / 2, 0);
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
    }
    
    
}