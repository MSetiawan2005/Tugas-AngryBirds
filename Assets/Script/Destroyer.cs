using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        string tag = col.gameObject.tag;
        if (tag == "Bird" || tag == "Enemy" || tag == "Obstacle")
        {
            Destroy(col.gameObject);
        }
    }
}