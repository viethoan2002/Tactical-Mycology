using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [Button]
    public void Move()
    {
        List<Vector3> path = GameManager.instance.curLevel.pathfinding.FindPath(transform.position,PlayerCtrl.instance.transform.position);

        if (path.Count == 2)
        {
            Debug.Log("Attack");
        }
        else
        {
            transform.DOMove(path[1], 1);
        }
    }
}
