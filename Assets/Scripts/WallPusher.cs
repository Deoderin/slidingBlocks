using DG.Tweening;
using UnityEngine;

public class WallPusher : MonoBehaviour
{
    [SerializeField]
    private ShapePunchConfig _shapePunchConfig; 
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wall") || other.CompareTag("Glass"))
        {
            PunchWallBlock(other);
        }        
    }

    private void PunchWallBlock(Collider wallCollider)
    {
        wallCollider.attachedRigidbody.isKinematic = wallCollider.CompareTag("Glass");
        wallCollider.attachedRigidbody.AddForce(Vector3.forward * _shapePunchConfig.PunchForce);
        wallCollider.transform.DOScale(Vector3.zero, _shapePunchConfig.TimePunchAnimation)
             .SetEase(_shapePunchConfig.EaseForDestroyPunchingWall)
             .OnComplete(() => wallCollider.gameObject.SetActive(false));
    }
}