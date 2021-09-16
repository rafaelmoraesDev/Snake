using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 direction = Vector2.right;
    private List<Transform> bodyParts;
    public Transform bodyPartPrefab;
    private GamePlay gamePlay;
    private bool dirUp, dirDown, dirLeft, dirRight = false;

    private void Start()
    {
        this.gamePlay = FindObjectOfType<GamePlay>();
        this.bodyParts = new List<Transform>();
        this.bodyParts.Add(this.transform);
        for (int i = 0; i < 2; i++)
        {
            IncreaseSnake();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.dirUp = true;
            if (this.dirUp)
            {
                direction = Vector2.up;
                PreventDirection(this.dirUp, this.dirDown, this.dirRight, this.dirLeft);
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.dirDown = true;
            if (this.dirDown)
            {
                direction = Vector2.down;
                PreventDirection(dirDown, dirUp, dirRight, dirLeft);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.dirRight = true;
            if (this.dirRight)
            {
                direction = Vector2.right;
                PreventDirection(dirRight, dirLeft, dirUp, dirDown);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.dirLeft = true;
            if (this.dirLeft)
            {
                direction = Vector2.left;
                PreventDirection(dirLeft, dirRight, dirUp, dirDown);
            }
        }
    }

    private void FixedUpdate()
    {
        for (int i = bodyParts.Count - 1; i > 0; i--)
        {
            bodyParts[i].position = bodyParts[i - 1].position;
        }
        this.transform.position = new Vector3(Mathf.Round(this.transform.position.x) + direction.x,
            Mathf.Round(this.transform.position.y) + direction.y, 0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Tags.Apple)
        {
            IncreaseSnake();
        }

        if (collision.tag == Tags.Body || collision.tag == Tags.Obstacle)
        {
            gamePlay.GameOver();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == Tags.Bound)
        {
            gamePlay.GameOver();
        }
    }

    private void IncreaseSnake()
    {
        Transform part = Instantiate(this.bodyPartPrefab);
        part.position = bodyParts[bodyParts.Count - 1].position;
        bodyParts.Add(part);
    }

    private void PreventDirection(bool pressed, bool opposite, bool left1, bool left2)
    {
        pressed = true;
        opposite =false;
        left1 = true;
        left2 = true;
    }
}
