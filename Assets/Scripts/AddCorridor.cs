using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCorridor : MonoBehaviour
{
    private CollectionRooms CollectionRoom;
    private GameObject CurrentObject;
    void Start()
    {
        // ��������� ������ ���� CollectionRooms
        CollectionRoom = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<CollectionRooms>();
        // ��������� � List ����������
        //CurrentObject = GameObject.
        CollectionRoom.AllCorridors.Add(gameObject);
        // ��������� � ����� List ���� ������
        CollectionRoom.AllRooms.Add(gameObject);
    }
}
