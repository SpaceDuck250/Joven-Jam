using UnityEngine;

public class SpinScript : MonoBehaviour
{
    public float rotateAmount;

    private void Update()
    {
        transform.Rotate(0, 0, rotateAmount * Time.deltaTime);
    }
}
