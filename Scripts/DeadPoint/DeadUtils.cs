using UnityEngine;

public class DeadPlatform : MonoBehaviour
{
    private GameObject deadPoint;

    private void Start()
    {
        deadPoint = GameObject.FindWithTag("Finish");
    }

    private void Update()
    {
        if (deadPoint.transform.position.y >= transform.position.y)
        {
            Destroy(this.gameObject);
        }
    }
}
