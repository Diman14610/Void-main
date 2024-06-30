using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
  private readonly List<Crossroad> _crossroads = new List<Crossroad>();

  private CollectionRooms _collectionRoom;

  void Start()
  {
    Debug.Log("Хуета");
    _collectionRoom = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<CollectionRooms>();
    Vector3 s = new Vector3(5, 5, 0);

    Instantiate(
        _collectionRoom.AllTypeCrossroads[4],
         s,
          _collectionRoom.AllTypeCrossroads[4].transform.rotation
          );
    // var rooms = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<CollectionRooms>();
  }
}
