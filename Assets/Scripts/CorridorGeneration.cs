using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorGeneration : MonoBehaviour
{
    // ����� ���������
    CollectionRooms CollectionRoom;
    // SpawnPoint
    [SerializeField] GameObject SpawnPoint;
    // ����� ������� ���������
    [SerializeField] int IndexTypeCorridor;

    // Destroyer �� ��������
    // ���� �� ��� �������� ������������� ������� �� SP Point-�
    [SerializeField] bool IsSpawned = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsSpawned = true;
    }
    bool IsMaxCountRoom()
    {
        // ���� ���������
        CollectionRoom = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<CollectionRooms>();

        // ���� �����������, � Collection.MaxCountRoom + �������� 10 room � �����
        return CollectionRoom.AllRooms.Count <= CollectionRoom.MaxCountRoom ? false : true;
    }
    void Start()
    {
        // ���� ���������
        CollectionRoom = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<CollectionRooms>();

        // ������ �������� ���������, �� ����� ������, ��� ��� � �����������,
        // ��� ������ ����� � ������� Unity � ��� ����������� �������� ������ ����� ��������,
        // ����� ������� ������ ��������� Max ���-�� ������.

        // ����������� ����������� � ������ ������ ������...
        // CollectionRoom.AllRooms.Count
        // CollectionRoom.AllCorridors.Count + CollectionRoom.AllCrossroads.Count

        // � ����� ������� �������� ���������� ����������� �� 10 �� 15 ������,
        // �� ��������, ��� �������� ����� �������������� � n^2 (��������) ��� exp, ������� �� ���-�� ������...

        CollectionRoom.DeltaTime += 0.5f;

        Invoke("Spawn", CollectionRoom.DeltaTime);
    }
    // ����� �������� ��, ��� ���� ���� �� ������ Invoke,
    // �� ��� ������ ������ �������, ������� ����� ��������� (�����������).
    void Spawn()
    {
        // �������� �� ��� ������������ ������, ����� �� ���� ������������ �� ����� �����
        if (!IsSpawned)
        {
            if (!IsMaxCountRoom())
            {
                Instantiate(CollectionRoom.AllTypeCorridors[IndexTypeCorridor], SpawnPoint.transform.position, CollectionRoom.AllTypeCorridors[IndexTypeCorridor].transform.rotation);
            }
            else
            {
                // ����� ������
                Instantiate(CollectionRoom.DeadEnd, SpawnPoint.transform);
                //Instantiate(CollectionRoom.DeadEnd, SpawnPoint.transform.position, CollectionRoom.DeadEnd.transform.rotation);
            }

            // �������� ���������
            if (IndexTypeCorridor >= 1.5f)
                CollectionRoom.DeltaTime = 0f;

            // (�����, �������� ���������, �� ��� ������� �� ����������, ����� ���� ������� ������ ������������� �������, ���� ����� ����� � �������)
            // ���������, ���� ��������� ��������: ����� �� ���� ������� � ���������, ���� ������� �������� � ������ Spawn + �����-�� ��������� �� ���������� (���� List<GameObject> AllCrossroads),
            // ��� ��� ������� �� ������������ ��������� ������� ����� �� �����.
        }
    }

    //void Spawn()
    //{
    //    �������, ��� ��� ������ ���������� ����� �� ������, ������ �� ����������
    //int IndexType;
    //    switch (SpawnPoints[IndexSP].name)
    //    {
    //        case "SP Top":
    //            ////IndexType = 0;
    //            Instantiate(CollectionRoom.AllTypeCorridors[IndexType], SpawnPoints[0].transform.position, CollectionRoom.AllTypeCorridors[IndexType].transform.rotation);
    //            break;
    //        case "SP Right":
    //            //IndexType = 1;
    //            Instantiate(CollectionRoom.AllTypeCorridors[IndexType], SpawnPoints[0].transform.position, CollectionRoom.AllTypeCorridors[IndexType].transform.rotation);
    //            break;
    //        case "SP Bottom":
    //            //IndexType = 2;
    //            Instantiate(CollectionRoom.AllTypeCorridors[IndexType], SpawnPoints[0].transform.position, CollectionRoom.AllTypeCorridors[IndexType].transform.rotation);
    //            break;
    //        case "SP Left":
    //            //IndexType = 3;
    //            Instantiate(CollectionRoom.AllTypeCorridors[IndexType], SpawnPoints[0].transform.position, CollectionRoom.AllTypeCorridors[IndexType].transform.rotation);
    //            break;
    //    }
    //    Debug.Log($"IndexSP => {IndexSP}");
    //    Debug.Log("�������������� ��������*");
    //}
}
