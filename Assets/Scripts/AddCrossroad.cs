using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCrossroad : MonoBehaviour
{
    private CollectionRooms CollectionRoom;
    private GameObject CurrentObject;
    void Start()
    {
        // ��������� ������ ���� CollectionRooms
        CollectionRoom = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<CollectionRooms>();

        // ��������� � ���� List �����������
        CollectionRoom.AllCrossroads.Add(gameObject);

        // ��������� � ����� List ���� ������
        CollectionRoom.AllRooms.Add(gameObject);
    }
}
