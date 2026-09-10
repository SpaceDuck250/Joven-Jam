using UnityEngine;

public class SimpleEnemyMove : MonoBehaviour
{
    public float moveDirectionAmount;
    public bool canMove = true;

    private void Update()
    {
        if (!canMove)
        {
            return;
        }

        transform.position += Time.deltaTime * moveDirectionAmount * Vector3.right;
    }


}
