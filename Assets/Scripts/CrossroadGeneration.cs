using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossroadGeneration : MonoBehaviour
{
    // ����� ���������
    CollectionRooms CollectionRoom;
    // SpawnPoint � IndexTypeCrossroad
    [SerializeField] GameObject SpawnPoint;
    public int IndexTypeCrossroad;

    // Collider2D ��� ������ OnTriggerEnter2D
    Collider2D CurrentCollision;

    // ���� �� ��� �������� ������������� ������� �� SP Point-�
    [SerializeField] bool IsSpawned = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Объект коллизии, c которым столкнулся уже с созданным объектом/коллизией
        var collObjectName = collision.gameObject.name;
        bool IsSpawnedCrossroad = false;

        // Перебираем типы возможных перекрёстков
        foreach (var typeCrossroad in CollectionRoom.AllTypeCrossroads)
        {
            string triggerObjectName = typeCrossroad.gameObject.name + "(Clone)";
            if (collObjectName == triggerObjectName)
            {
                IsSpawnedCrossroad = true;
                break;
            }
        }

        // Не спавним, если есть перекрёсток, а если нет, то спавним перекрёсток
        if (IsSpawnedCrossroad)
            IsSpawned = true;
        else
            IsSpawned = false;

        Debug.Log($"colObjectName = {collObjectName}, gameObjectName = {gameObject.name}, IsSpawned = {IsSpawned}");
    }
    // ������� �����
    //private int IndexSP = 0;
    void Start()
    {
        // ���� ���������
        CollectionRoom = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<CollectionRooms>();

        // ����������� ��������
        // Скорость спавна
        CollectionRoom.DeltaTime += 0.01f;

        Invoke("Spawn", CollectionRoom.DeltaTime);
    }
    // ����� �������� ��, ��� ���� ���� �� ������ Invoke,
    // �� ��� ������ ������ �������, ������� ����� ��������� (�����������).
    void Spawn()
    {
        //Debug.Log($"void Spawn() = x:{gameObject.transform.position.x} y:{gameObject.transform.position.y} name:{gameObject.name}!");
        // �������� �� ��� ������������ ������, ����� �� ���� ������������ �� ����� �����
        if (!IsSpawned)
        {
            //Debug.Log($"!IsSpawned");
            if (!IsMaxCountRoom())
            {
                // ����� ��������� � �������������
                int rndTypeCrossroad = Random.Range(0, 5);

                // ��� ������� ������ �������������, ����� �������� ��� ����������, ��� ��������� ������ � ������� ������� ������ ���� ���������
                //int DisconnectedTypeCrossroad = IndexTypeCrossroad;

                switch (SpawnPoint.name)
                {
                    case "SP Top":
                        //Debug.Log($"void Spawn() => SP Top");
                        if (rndTypeCrossroad == IndexTypeCrossroad)
                            while (rndTypeCrossroad == IndexTypeCrossroad)
                                rndTypeCrossroad = Random.Range(0, 5);
                        Instantiate(CollectionRoom.AllTypeCrossroads[rndTypeCrossroad], SpawnPoint.transform.position, CollectionRoom.AllTypeCrossroads[rndTypeCrossroad].transform.rotation);
                        break;
                    case "SP Right":
                        //Debug.Log($"void Spawn() => SP Right");
                        if (rndTypeCrossroad == IndexTypeCrossroad)
                            while (rndTypeCrossroad == IndexTypeCrossroad)
                                rndTypeCrossroad = Random.Range(0, 5);
                        Instantiate(CollectionRoom.AllTypeCrossroads[rndTypeCrossroad], SpawnPoint.transform.position, CollectionRoom.AllTypeCrossroads[rndTypeCrossroad].transform.rotation);
                        break;
                    case "SP Bottom":
                        //Debug.Log($"void Spawn() => SP Bottom");
                        if (rndTypeCrossroad == IndexTypeCrossroad)
                            while (rndTypeCrossroad == IndexTypeCrossroad)
                                rndTypeCrossroad = Random.Range(0, 5);
                        Instantiate(CollectionRoom.AllTypeCrossroads[rndTypeCrossroad], SpawnPoint.transform.position, CollectionRoom.AllTypeCrossroads[rndTypeCrossroad].transform.rotation);
                        break;
                    case "SP Left":
                        //Debug.Log($"void Spawn() => SP Left");
                        if (rndTypeCrossroad == IndexTypeCrossroad)
                            while (rndTypeCrossroad == IndexTypeCrossroad)
                                rndTypeCrossroad = Random.Range(0, 5);
                        Instantiate(CollectionRoom.AllTypeCrossroads[rndTypeCrossroad], SpawnPoint.transform.position, CollectionRoom.AllTypeCrossroads[rndTypeCrossroad].transform.rotation);
                        break;
                    default:
                        //Debug.Log($"void Spawn() => default");
                        Instantiate(CollectionRoom.DeadEnd, SpawnPoint.transform.position, CollectionRoom.DeadEnd.transform.rotation);
                        break;
                }
            }
            else
            {
                //Debug.Log($"if (MaxCountRoom)");
                // ����� ������
                Instantiate(CollectionRoom.DeadEnd, SpawnPoint.transform);
                //Instantiate(CollectionRoom.DeadEnd, SpawnPoint.transform.position, CollectionRoom.DeadEnd.transform.rotation);
            }

        }
        else if (IsSpawned && CurrentCollision != null)
        {
            //Debug.Log($"if (IsSpawned && CurrentCollision != null)");
            // �����, ��� �������� ������ ���������
            HybridSP();

            // ��������, ����� �� ���� ����������
            CurrentCollision = null;
        }

        // �������� ��������
        CollectionRoom.DeltaTime = 0f;

        // Example spawn
        //Instantiate(CollectionRoom.AllTypeCrossroads[IndexTypeCrossroad], SpawnPoint.transform.position, CollectionRoom.AllTypeCrossroads[IndexTypeCrossroad].transform.rotation);
    }
    bool IsMaxCountRoom()
    {
        // ���� ���������
        CollectionRoom = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<CollectionRooms>();

        // ���� �����������, � Collection.MaxCountRoom + �������� 10 room � �����
        return CollectionRoom.AllRooms.Count <= CollectionRoom.MaxCountRoom ? false : true;
    }

    #warning ��� ��������� � ��������� ������� � ��� ������������� ������������, ��� ����-����� �����������
    /// <summary>
    /// ����� ��� ���������� ������ ���������, ��� ������� 2-�� SP Point-��
    /// </summary>
    private void HybridSP()
    {
        // gameObject - IndexTypeCrossroad
        var temp = CurrentCollision.gameObject.GetComponent<CrossroadGeneration>();

        int rndTypeCrossroad = Random.Range(0, 5);

        if (rndTypeCrossroad == IndexTypeCrossroad || rndTypeCrossroad == temp.IndexTypeCrossroad)
            while (rndTypeCrossroad == IndexTypeCrossroad || rndTypeCrossroad == temp.IndexTypeCrossroad)
                rndTypeCrossroad = Random.Range(0, 5);

        Debug.Log($"gameObject => {CollectionRoom.AllTypeCrossroads[rndTypeCrossroad]}. gameObject.name => {gameObject.name}");
        Instantiate(CollectionRoom.AllTypeCrossroads[rndTypeCrossroad], SpawnPoint.transform.position, CollectionRoom.AllTypeCrossroads[rndTypeCrossroad].transform.rotation);

        // � �����:
        // 1) ���� ����� Index Sp � gameObject � collision.gameObject;
        // 2) ������� ����������� � ��������, ����� �� ��������� ��������� ���������� �� ��������� ���� Index SP;
        // 3) ������;
    }
    // ������ ��� ������� ������ ������������ ���� SP ���������
    private bool IsTriggerSP(string gameObjectName)
    {
        var arrSP = new ArrayList() { "SP Top", "SP Right", "SP Bottom", "SP Left" };
        return arrSP.Contains(gameObjectName);
    }
}
