using UnityEngine;

public class AddCrossroad : MonoBehaviour
{
    private CollectionRooms CollectionRoom;
    private GameObject CurrentObject;

    void Start()
    {
        CollectionRoom = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<CollectionRooms>();
        CollectionRoom.AllCrossroads.Add(gameObject);
        CollectionRoom.AllRooms.Add(gameObject);
    }
}
