using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;

public class ShapeFinisher : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _blocks;
    [SerializeField]
    private GameObject _score;
    
    public IEnumerator Finish()
    {
        yield return new WaitForSeconds(1f);
        
        foreach (var block in _blocks)
        {
            yield return new WaitForSeconds(0.4f);
            block.transform.DOScale(Vector3.zero, 0.5f);
            ShowScore();
            ScoreSystem.AddScore(100);
        }
    }

    private void ShowScore()
    {
        var score = Instantiate(_score, transform.position, quaternion.identity);
        score.transform.DOMoveY(100, 10);
    }
}
