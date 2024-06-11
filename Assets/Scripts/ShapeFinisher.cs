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
        int scoreWithBlock = 100;
        float delay = 0.15f;
        float duration = 0.3f;
        
        yield return new WaitForSeconds(1f);
        
        foreach (var block in _blocks)
        {
            yield return new WaitForSeconds(delay);
            block.transform.DOScale(Vector3.zero, duration);
            ShowScore(scoreWithBlock);
            ScoreSystem.AddScore(scoreWithBlock);
        }
    }

    private void ShowScore(int score)
    {
        var scoreObject = Instantiate(_score, transform.position, quaternion.identity);
        scoreObject.transform.DOMoveY(score, 10);
    }
}
