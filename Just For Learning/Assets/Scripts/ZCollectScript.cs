using UnityEngine;

public class ZCollectScript : MonoBehaviour
{
    public void CollectSelf()
    {
        ZManagerScript.OnCollectZ?.Invoke();
        Destroy(gameObject);
    }
}
