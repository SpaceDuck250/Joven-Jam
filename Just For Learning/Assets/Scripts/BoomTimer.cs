using UnityEngine;

public class BoomTimer : MonoBehaviour
{
    public float waitTime;
    public float timer;

    public BoomScript boomScript;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            boomScript.SpawnBoom();
        }
    }
}
