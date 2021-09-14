using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    public Transform snakeHead;
    public GameObject snakeNode;
    public float validDelta;

    public List<Transform> _snakeNodes = new List<Transform>();
    private List<Vector3> _positions = new List<Vector3>();

    private void Awake()
    {
        _positions.Add(snakeHead.position);
        AddNode();
        AddNode();
        AddNode();
        AddNode();
        AddNode();
    }

    private void Start() {
        GameEventsSystem.current.onSnakeGain += AddNode;
        GameEventsSystem.current.onSnakeErose += RemoveNode;
    }

    private void Update()
    {
        float distance = ((Vector3) snakeHead.position - _positions[0]).magnitude;

        if (distance > validDelta)
        {
            // Направление от старого положения головы, к новому
            Vector3 direction = ((Vector3) snakeHead.position - _positions[0]).normalized;

            _positions.Insert(0, _positions[0] + direction * validDelta);
            _positions.RemoveAt(_positions.Count - 1);

            distance -= validDelta;
        }

        for (int i = 0; i < _snakeNodes.Count; i++)
        {
            _snakeNodes[i].position = Vector3.Lerp(_positions[i + 1], _positions[i], distance / validDelta);
        }
    }

    public void AddNode()
    {
        Transform circle = Instantiate(snakeHead, _positions[_positions.Count - 1], Quaternion.identity, transform)
                               ;
        _snakeNodes.Add(circle);
        _positions.Add(circle.position);
    }

    public void RemoveNode()
    {
        if ( _snakeNodes.Count > 0) {
            for (int i = _snakeNodes.Count - 1; i > 0 ; --i)
            {
                _snakeNodes[i].position = Vector3.Lerp(_snakeNodes[i - 1].position, _snakeNodes[i].position, 0.2f);
                _positions[i + 1] = _snakeNodes[i].position;
            }

            Destroy(_snakeNodes[0].gameObject);
            _snakeNodes.RemoveAt(0);
            _positions.RemoveAt(1);
        } else {
            GameEventsSystem.current.SceneReload();
        }
    }
}
