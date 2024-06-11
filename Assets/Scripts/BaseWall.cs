using UnityEngine;

public class BaseWall : MonoBehaviour
{
    private const int _wallScore = 1000;

    [SerializeField]
    private Collider _collider;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Shape"))
        {
            ScoreSystem.AddScore(_wallScore);
            ScoreSystem.AddMultiplier();

            _collider.enabled = false;
        }
    }
}