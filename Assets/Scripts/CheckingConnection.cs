using UnityEngine;

public class CheckingConnection : MonoBehaviour
{
    [SerializeField] GameObject SpawnPoint;
    [SerializeField] int IndexTypeCrossroad;
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //CheckConnect(collision);
    }

    void CheckConnect(Collider2D collision)
    {
        switch (SpawnPoint.name)
        {
            case "SP Top":
                if (IndexTypeCrossroad != 0)
                    Debug.Log($"Trigger.collision => {collision.gameObject.name}");
                break;
            case "SP Right":
                if (IndexTypeCrossroad != 1)
                    Debug.Log($"Trigger.collision => {collision.gameObject.name}");
                break;
            case "SP Bottom":
                if (IndexTypeCrossroad != 2)
                    Debug.Log($"Trigger.collision => {collision.gameObject.name}");
                break;
            case "SP Left":
                if (IndexTypeCrossroad != 3)
                    Debug.Log($"Trigger.collision => {collision.gameObject.name}");
                break;
            default:
                break;
        }
    }
}
