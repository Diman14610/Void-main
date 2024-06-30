using UnityEngine;

public class CorridorGeneration : MonoBehaviour
{
  CollectionRooms CollectionRoom;
  [SerializeField] GameObject SpawnPoint;
  [SerializeField] int IndexTypeCorridor;
  [SerializeField] bool IsSpawned = false;

  private void OnTriggerEnter2D(Collider2D collision)
  {
    IsSpawned = true;
  }

  bool IsMaxCountRoom()
  {
    CollectionRoom = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<CollectionRooms>();
    return CollectionRoom.AllRooms.Count <= CollectionRoom.MaxCountRoom ? false : true;
  }

  void Start()
  {
    CollectionRoom = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<CollectionRooms>();
    CollectionRoom.DeltaTime += 0.5f;
    Invoke("Spawn", CollectionRoom.DeltaTime);
  }

  void Spawn()
  {
    if (!IsSpawned)
    {
      if (!IsMaxCountRoom())
      {
        Instantiate(CollectionRoom.AllTypeCorridors[IndexTypeCorridor], SpawnPoint.transform.position, CollectionRoom.AllTypeCorridors[IndexTypeCorridor].transform.rotation);
      }
      else
      {
        Instantiate(CollectionRoom.DeadEnd, SpawnPoint.transform);
      }

      if (IndexTypeCorridor >= 1.5f)
      {
        CollectionRoom.DeltaTime = 0f;
      }
    }
  }
}
