using UnityEngine;

public class AddCorridor : MonoBehaviour
{
    private CollectionRooms CollectionRoom;
    private GameObject CurrentObject;

    void Start()
    {
        CollectionRoom = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<CollectionRooms>();
        CollectionRoom.AllCorridors.Add(gameObject);
        CollectionRoom.AllRooms.Add(gameObject);
    }
}
