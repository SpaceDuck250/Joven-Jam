using UnityEngine;

public class SimpleEnemyMove : MonoBehaviour
{
    public float moveDirectionAmount;

    private void Update()
    {
        //rb.linearVelocity = Vector3.right * moveDirectionAmount;
        transform.position += Time.deltaTime * moveDirectionAmount * Vector3.right;
    }
}
