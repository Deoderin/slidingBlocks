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
    [SerializeField]
    private GameObject _shadow;

    public IEnumerator Finish()
    {
        int scoreWithBlock = 100;
        float delay = 0.15f;
        float duration = 0.3f;
        
        yield return new WaitForSeconds(1f);
        
        foreach (var block in _blocks)
        {
            yield return new WaitForSeconds(delay);

            if(block != null)
            {
                block.transform.DOScale(Vector3.zero, duration);
                ShowScore(scoreWithBlock);
                ScoreSystem.AddScore(scoreWithBlock);
            }
        }
        
        _shadow.SetActive(false);
    }

    private void ShowScore(int score)
    {
        var scoreObject = Instantiate(_score, transform.position, quaternion.identity);
        scoreObject.transform.DOMoveY(score, 10);
    }
}
