using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool Free;
    private void Awake()
    {
        this.Free = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.Player) || collision.CompareTag(Tags.Body) || collision.CompareTag(Tags.Obstacle))
        {
            this.Free = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.Player) || collision.CompareTag(Tags.Body))
        {
            this.Free = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.Player) || collision.CompareTag(Tags.Body))
        {
            this.Free = false;
        }
    }
}
