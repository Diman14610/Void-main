using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    // ��� ����� ������ ���� �� ������� ������� � ������� �������.
    // �������� ������ Crossroads (������ ����������):
    // Element 0 -> SP Top;
    // Element 1 -> SP Right;
    // Element 2 -> SP Bottom;
    // Element 3 -> SP Left;

    // � ����� �� ���� � � ������ �����������
    // �������� ������ TBL �����:
    // Element 0 -> SP Top;
    // Element 1 -> SP Bottom;
    // Element 2 -> SP Left;

    // ������������ ��� ���������� (��� �� �����)
    Dictionary<int, string> rndTop = new Dictionary<int, string>()
    {
        {0, "Crossroad"},
        {2, "TRB"},
        {3, "RBL"},
        {4, "TBL"}
    };
    Dictionary<int, string> rndRight = new Dictionary<int, string>()
    {
        {0, "Crossroad"},
        {1, "TRL"},
        {3, "RBL"},
        {4, "TBL"}
    };
    Dictionary<int, string> rndBottom = new Dictionary<int, string>()
    {
        {0, "Crossroad"},
        {1, "TRL"},
        {2, "TRB"},
        {4, "TBL"}
    };
    Dictionary<int, string> rndLeft = new Dictionary<int, string>()
    {
        {0, "Crossroad"},
        {1, "TRL"},
        {2, "TRB"},
        {3, "RBL"}
    };

    // ��������� �������� � ���������
    private CollectionRooms CollectionRoom;

    // ����������� ���������� ��� �� ��������� ������ � ����������� � Debug.Log();
    private Room CurrentRoom;
    private int IndexSP = 0;

    // ���������� �������
    //[SerializeField] float waitTime = 5f;
    //[SerializeField] int CurrentIndexSP;

    private void Start()
    {
        // ����� � ����� ���������� � ���������� ����������
        CollectionRoom = GameObject.FindGameObjectWithTag("Rooms").GetComponent<CollectionRooms>();

        //Invoke("Spawn", 1f);
        if (CollectionRoom.AllRooms.Count < CollectionRoom.MaxCountRoom)
        {
            Invoke("Spawn", .5f);
        }
        //Debug.Log($"this.object.name => {this.gameObject.name}");
    }
    private void Update()
    {
        CancelInvoke();
    }

    void Spawn()
    {
        // ���� ������� �������
        //var room = CollectionRoom.AllRooms[CollectionRoom.CurrentIndexRoom];
        //CurrentRoom = CollectionRoom.AllRooms[CollectionRoom.CurrentIndexRoom];

        for(int i = 0; i < CurrentRoom.SpawnPoints.Length; i++)
        {
            // ��������� ������� SP
            IndexSP = i;
            // ������ � ����� ���� ���������� ������ ��������
            SpawnCurrentRoom();
            //Invoke("SpawnCurrentRoom", .3f);
        }

        // ���������� �����
        //CollectionRoom.CurrentIndexRoom++;
    }

    void SpawnCurrentRoom()
    {
        if (CurrentRoom.TypeRoom == Room.TypeRooms.Crossroad)
        {
            //Debug.Log($"CurrentRoom.name => {CurrentRoom.FullName}SpawnPoint[{IndexSP}].name => {CurrentRoom.SpawnPoints[IndexSP].name}");

            // � ���, � SpawnPoints, �� ����� ���� ������� ��������, ��� ��� �����, ���� ��������� ��� ��������� �� ����!
            //if (CurrentRoom.SpawnPoints[IndexSP].name != null)

            Instantiate(CollectionRoom.AllTypeCorridors[IndexSP], CurrentRoom.SpawnPoints[IndexSP].transform.position, CollectionRoom.AllTypeCorridors[IndexSP].transform.rotation);
            // ����� �������� ������
            Debug.Log($"{CollectionRoom.AllTypeCorridors[IndexSP].name} Spawn Complete!");
            CancelInvoke();
        }
        else if (CurrentRoom.TypeRoom == Room.TypeRooms.Corridor)
        {
            int rnd = RandomizeCrossroads(CurrentRoom.SpawnPoints[IndexSP].name);
            Instantiate(CollectionRoom.AllTypeCrossroads[rnd], CurrentRoom.SpawnPoints[IndexSP].transform.position, CollectionRoom.AllTypeCrossroads[rnd].transform.rotation);
            // ����� �������� ������
            Debug.Log($"{CollectionRoom.AllTypeCrossroads[rnd].name} Spawn Complete!");
            CancelInvoke();
        }
    }

    int RandomizeCrossroads(string SPName)
    {
        int rndCrossroad = Random.Range(0, 5);

        switch (SPName)
        {
            case "SP Top":
                if (rndCrossroad == 1)
                    while(rndCrossroad == 1)
                        rndCrossroad = Random.Range(0, 5);
                return rndCrossroad;

            case "SP Right":
                if (rndCrossroad == 2)
                    while (rndCrossroad == 2)
                        rndCrossroad = Random.Range(0, 5);
                return rndCrossroad;

            case "SP Bottom":
                if (rndCrossroad == 3)
                    while (rndCrossroad == 3)
                        rndCrossroad = Random.Range(0, 5);
                return rndCrossroad;

            case "SP Left":
                if (rndCrossroad == 4)
                    while (rndCrossroad == 4)
                        rndCrossroad = Random.Range(0, 5);
                return rndCrossroad;
        }

        // ��� ��� ����� ����������� ������ ���-�� ����������, ��� ����������� �� switch, �� ��� ����� ������� "��������� ��� c#" )
        return rndCrossroad;
    }

    // ��������� � �������
    // ����� Spawn(), ��� ������ SP ����� (�������� ����� �� CurrentIndexSp)
    //void Spawn()
    //{
    //    // ���� ������� �������
    //    var room = CollectionRoom.AllRooms[CollectionRoom.AllRooms.Count - 1];

    //    // ��������� ���-�� ������������ ������� �������, ����� ������ �������
    //    if (room.CountExitRoom < room.SpawnPoints.Length)
    //    {
    //        //Debug.Log($"room.CountExitRoom => {room.CountExitRoom}");

    //        // ��������� ��� �������
    //        if (room.TypeRoom == Room.TypeRooms.Crossroad)
    //        {
    //            // ��������� ���������� ���������� �� ���� �������� ���������� �������� � ����� SP Point-��

    //            //Instantiate(CollectionRoom.AllTypeCorridors[CurrentIndexSP], transform);
    //            Instantiate(CollectionRoom.AllTypeCorridors[CurrentIndexSP], room.SpawnPoints[CurrentIndexSP].transform.position, CollectionRoom.AllTypeCorridors[CurrentIndexSP].transform.rotation);
    //            //Debug.Log($"Crossroad T.P => {transform.position}");
    //        }
    //        else if (room.TypeRoom == Room.TypeRooms.Corridor)
    //        {
    //            // ��� ��� � ��� SP ���������� ���� �� ������� �������, �� ��� ���������� � ������ ���������,
    //            // � ���������� SP Index, �������� ����� ���������, ������� �� ����� ��������,
    //            // � room.SpawnPoints[CurrentIndexSP].transform.position ���������� ����� ���������, � �������� �������� Spawn

    //            // �����������
    //            int rnd = Random.Range(0, 5);
    //            if (rnd == CurrentIndexSP)
    //                while (rnd == CurrentIndexSP)
    //                    rnd = Random.Range(0, 5);

    //            // ��������
    //            Debug.Log($"TypeCorridor => {room.FullName}");
    //            Debug.Log($"CurrentIndexSp => {CurrentIndexSP}");
    //            Debug.Log($"rnd => {rnd}");
    //            Debug.Log($"AllTypeCrossroads[rnd] => {CollectionRoom.AllTypeCrossroads[rnd].name}");

    //            // �����
    //            Instantiate(CollectionRoom.AllTypeCrossroads[rnd], room.SpawnPoints[CurrentIndexSP].transform.position, CollectionRoom.AllTypeCrossroads[rnd].transform.rotation);
    //        }

    //        // ��������� �� ��������� SP
    //        room.CountExitRoom++;
    //    }
    //}

    // ���������� ������
    //public int openingDirection;
    //public bool spawned = false;
    //public bool spawnedEntry = false;

    //void Spawn()
    //{
    //    if (spawned == false)
    //    {
    //        Debug.Log($"spawnPos = {transform.position}");
    //        Vector3 spawnPos = transform.position;
    //        switch (openingDirection)
    //        {
    //            case 1:
    //                // ����� ���������� �������� ������.
    //                rand = Random.Range(0, templates.CorridorTop.Length);
    //                Instantiate(templates.CorridorTop[rand], transform.position, templates.CorridorTop[rand].transform.rotation);
    //                break;
    //            case 2:
    //                // ����� ���������� �������� ������.
    //                rand = Random.Range(0, templates.CorridorRight.Length);
    //                Instantiate(templates.CorridorRight[rand], transform.position, templates.CorridorRight[rand].transform.rotation);
    //                break;
    //            case 3:
    //                // ����� ���������� �������� �����.
    //                rand = Random.Range(0, templates.CorridorBottom.Length);
    //                Instantiate(templates.CorridorBottom[rand], transform.position, templates.CorridorBottom[rand].transform.rotation);
    //                break;
    //            case 4:
    //                // ����� ���������� �������� �����.
    //                rand = Random.Range(0, templates.CorridorLeft.Length);
    //                Instantiate(templates.CorridorLeft[rand], transform.position, templates.CorridorLeft[rand].transform.rotation);
    //                break;
    //            case 5:
    //                // ����� ���������� ���������� �����.
    //                rand = Random.Range(0, templates.CrossroadsBottomRooms.Length);
    //                Instantiate(templates.CrossroadsBottomRooms[rand], transform.position, templates.CrossroadsBottomRooms[rand].transform.rotation);
    //                break;
    //            case 6:
    //                // ����� ���������� ���������� ������.
    //                rand = Random.Range(0, templates.CrossroadsTopRooms.Length);
    //                Instantiate(templates.CrossroadsTopRooms[rand], transform.position, templates.CrossroadsTopRooms[rand].transform.rotation);
    //                break;

    //            case 7:
    //                // ����� ���������� ���������� �����.
    //                rand = Random.Range(0, templates.CrossroadsLeftRooms.Length);
    //                Instantiate(templates.CrossroadsLeftRooms[rand], transform.position, templates.CrossroadsLeftRooms[rand].transform.rotation);
    //                break;

    //            case 8:
    //                // ����� ���������� ���������� ������.
    //                rand = Random.Range(0, templates.CrossroadsRightRooms.Length);
    //                Instantiate(templates.CrossroadsRightRooms[rand], transform.position, templates.CrossroadsRightRooms[rand].transform.rotation);
    //                break;
    //        }
    //        spawned = true;
    //    }
    //}

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("SpawnPoint"))
    //    {
    //        if (other.GetComponent<LevelGeneration>().spawned == false && spawned == false)
    //        {
    //            Destroy(gameObject);
    //        }
    //        spawned = true;
    //    }
    //}

    //private float radius = 5f; //Radius of object to spawn

    //private int DetectCollisions(Vector3 pos)
    //{
    //    Collider[] hitColliders = Physics.OverlapSphere(pos, radius);
    //    return hitColliders.Length;
    //}
}
