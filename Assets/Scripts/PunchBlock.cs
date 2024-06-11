using DG.Tweening;
using UnityEngine;

public class PunchBlock : MonoBehaviour
{
    [SerializeField]
    private ShapePunchConfig _shapePunchConfig;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Shape"))
        {
            PunchShapeBlock(other);
        }
    }
    
    private void PunchShapeBlock(Collider wallCollider)
    {
        wallCollider.transform.DOScale(Vector3.zero, _shapePunchConfig.TimePunchAnimation)
                    .SetEase(_shapePunchConfig.EaseForDestroyPunchingWall)
                    .OnComplete(() => Destroy(wallCollider.gameObject));
    }
}