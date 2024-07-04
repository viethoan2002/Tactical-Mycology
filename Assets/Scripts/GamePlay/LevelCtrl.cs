using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCtrl : MonoBehaviour
{
    public Pathfinding pathfinding;
    [SerializeField] private List<Vector3> obstacle = new List<Vector3>();

    private void Start()
    {
        pathfinding = new Pathfinding(9, 9);
        foreach(var ob in obstacle)
        {
            pathfinding.GetGrid().GetXY(ob, out int x, out int y);
            pathfinding.GetNode(x, y).SetIsWalkable(!pathfinding.GetNode(x, y).isWalkable);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int x, y;
            pathfinding.GetGrid().GetXY(mouseWorldPosition, out x, out y);
            foreach (var i in pathfinding.FindPath(transform.position, mouseWorldPosition))
                Debug.Log((Vector2)i);
        }
    }
}
