using UnityEngine;

public class Apple : MonoBehaviour
{
    private BoardGrid boardGrid;

    private void Start()
    {
        this.boardGrid = FindObjectOfType<BoardGrid>();
        SetAppleInRandomPosition();
    }
   
    private void SetAppleInRandomPosition()
    {
        int x = Random.Range(0, boardGrid.Width - 1);
        int y = Random.Range(0, boardGrid.Height - 1);
        bool checkPosition = this.boardGrid.allTiles[x, y].GetComponent<Tile>().Free;

        while (!checkPosition)
        {
            x = Random.Range(0, boardGrid.Width - 1);
            y = Random.Range(0, boardGrid.Height - 1);
            checkPosition = this.boardGrid.allTiles[x, y].GetComponent<Tile>().Free;

            return;
        }

        this.transform.position = this.boardGrid.allTiles[x, y].transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Tags.Player || collision.tag == Tags.Body)
        {
            SetAppleInRandomPosition();
        }
    }
}
