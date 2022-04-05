using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Collectible"))
        {
            other.gameObject.SetActive(false);
            QuestController.Instance.PlayerCollectedItem();
        }
    }
}