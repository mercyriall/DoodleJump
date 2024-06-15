using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerMovement>();

        var _leftSpownObject = GameObject.Find("LeftBack").gameObject.transform.childCount;
        var _rightSpownObject = GameObject.Find("RightBack").gameObject.transform.childCount;
        var _headSpownObject = GameObject.Find("Head").gameObject.transform.childCount;

        if (player != null && (_leftSpownObject > 0 || _rightSpownObject > 0 || _headSpownObject > 0))
        {
            Destroy(this.gameObject);
        }
        else if (player != null && (_leftSpownObject == 0 || _rightSpownObject == 0 || _headSpownObject == 0))
        {
            player.Dead();
        }
    }
}
