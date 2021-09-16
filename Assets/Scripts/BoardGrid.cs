using UnityEngine;
using Random = UnityEngine.Random;

public class BoardGrid : MonoBehaviour
{
    public int Width, Height;
    public GameObject TilePrefab;
    public GameObject ObstaclePrefab;
    public Tile[,] allTiles { get; private set; }

    private BoxCollider2D boxCollider2D;
    private void Start()
    {
        this.allTiles = new Tile[Width, Height];
        this.boxCollider2D = this.GetComponent<BoxCollider2D>();
        SetUpGridBoard();
        SetUpBoxCollider();
        SetUpObstacles();
    }

    private void SetUpObstacles()
    {
        int quantity = 2; //Quantity of obstacles
        int size; //Set size of obstacles
        int x, y;

        for (int i = 0; i < quantity; i++)
        {
            x = Random.Range(1, Width / 4);
            y = Random.Range(1, Height - 2);
            size = Random.Range(2, 4);

            //Prevent overtake array range
            while (y < (Height - 2) - size && y < size + 2)
            {
                y = Random.Range(1, Height - 1);
            }

            //Guarantee obstacle instantiate opposite side
            if (i > 0)
            {
                x = Random.Range(Width - (Width / 4), Width - 1);
                y = Random.Range(1, Height - 1);

                while (y < (Height - 2) - size && y < size + 2)
                {
                    y = Random.Range(1, Height - 1);
                }
            }

            //Set the index obstacle
            GameObject obstacle = Instantiate(this.ObstaclePrefab);
            obstacle.transform.position = allTiles[x, y].transform.position;

            //Set the obstacles following the index
            for (int j = 1; j <= size + 1; j++)
            {
                obstacle = Instantiate(this.ObstaclePrefab);
                obstacle.transform.position = allTiles[x, y - j].transform.position;
            }
        }
    }

    private void SetUpBoxCollider()
    {
        this.boxCollider2D.size = new Vector2(Width, Height);
        this.boxCollider2D.offset = new Vector2(((Width / 2) - 0.5f), ((Height / 2) - 0.5f));
    }

    private void SetUpGridBoard()
    {
        for (int i = 0; i < this.Width; i++)
        {
            for (int j = 0; j < this.Height; j++)
            {
                GameObject tile = Instantiate(TilePrefab, new Vector3(i, j, 0), Quaternion.identity) as GameObject;
                tile.name = string.Format("{0},{1}", i, j);
                allTiles[i, j] = tile.GetComponent<Tile>();
                tile.transform.parent = transform;
            }
        }
        SetOnCenterOfScreen();
    }

    private void SetOnCenterOfScreen()
    {
        float dept = this.transform.position.z;
        float adjustX = ((float)(-Width) / 2);
        float adjustY = ((float)(-Height) / 2);
        this.transform.position = new Vector3(adjustX, adjustY, dept);
    }
}
