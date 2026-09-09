using UnityEngine;
using System.Collections;

public class ZAnimatorScript : MonoBehaviour
{
    public float timeTilStopMin;
    public float timeTilStopMax;

    public Rigidbody2D rb;

    public float upForce;

    //public float directionOffsetRange;
    public float leftOffset;
    public float rightOffset;

    public void DoJumpAnim()
    {
        StartCoroutine(JumpThenStop());
    }

    public IEnumerator JumpThenStop()
    {
        rb.AddForce(Vector3.up * upForce, ForceMode2D.Impulse);

        float randomDirectionAmount = Random.Range(leftOffset, rightOffset);
        rb.AddForce(Vector3.right * randomDirectionAmount, ForceMode2D.Impulse);


        float timeTilStop = Random.Range(timeTilStopMin, timeTilStopMax);
        yield return new WaitForSeconds(timeTilStop);

        rb.gravityScale = 0;
        rb.linearVelocity = Vector3.zero;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    
}
