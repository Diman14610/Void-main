using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    // Все точки спавна идут по часовой стрелки у каждого объекта.
    // Например объект Crossroads (полный перекрёсток):
    // Element 0 -> SP Top;
    // Element 1 -> SP Right;
    // Element 2 -> SP Bottom;
    // Element 3 -> SP Left;

    // В таком же виде и у других перекрёстков
    // Например объект TBL имеет:
    // Element 0 -> SP Top;
    // Element 1 -> SP Bottom;
    // Element 2 -> SP Left;

    // Рандомайзеры для корридоров (Уже не нужно)
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

    // Начальные значения и коллекция
    private CollectionRooms CollectionRoom;

    // Объявляемые переменные для по объектной слежке и отображения в Debug.Log();
    private Room CurrentRoom;
    private int IndexSP = 0;

    // Переменные объекта
    //[SerializeField] float waitTime = 5f;
    //[SerializeField] int CurrentIndexSP;

    private void Start()
    {
        // Здесь я делаю присвоение и объявление переменных
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
        // Берём текущую комнату
        //var room = CollectionRoom.AllRooms[CollectionRoom.CurrentIndexRoom];
        //CurrentRoom = CollectionRoom.AllRooms[CollectionRoom.CurrentIndexRoom];

        for(int i = 0; i < CurrentRoom.SpawnPoints.Length; i++)
        {
            // Сохраняем счётчик SP
            IndexSP = i;
            // Входим в метод длдя поэтапного спавна объектов
            SpawnCurrentRoom();
            //Invoke("SpawnCurrentRoom", .3f);
        }

        // Обновление ключа
        //CollectionRoom.CurrentIndexRoom++;
    }

    void SpawnCurrentRoom()
    {
        if (CurrentRoom.TypeRoom == Room.TypeRooms.Crossroad)
        {
            //Debug.Log($"CurrentRoom.name => {CurrentRoom.FullName}SpawnPoint[{IndexSP}].name => {CurrentRoom.SpawnPoints[IndexSP].name}");

            // И ещё, у SpawnPoints, не может быть пустого элемента, так как иначе, игра сломается при попадание по нему!
            //if (CurrentRoom.SpawnPoints[IndexSP].name != null)

            Instantiate(CollectionRoom.AllTypeCorridors[IndexSP], CurrentRoom.SpawnPoints[IndexSP].transform.position, CollectionRoom.AllTypeCorridors[IndexSP].transform.rotation);
            // Вывод текущего спавна
            Debug.Log($"{CollectionRoom.AllTypeCorridors[IndexSP].name} Spawn Complete!");
            CancelInvoke();
        }
        else if (CurrentRoom.TypeRoom == Room.TypeRooms.Corridor)
        {
            int rnd = RandomizeCrossroads(CurrentRoom.SpawnPoints[IndexSP].name);
            Instantiate(CollectionRoom.AllTypeCrossroads[rnd], CurrentRoom.SpawnPoints[IndexSP].transform.position, CollectionRoom.AllTypeCrossroads[rnd].transform.rotation);
            // Вывод текущего спавна
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

        // Так как метод обязательно должен что-то возвращать, вне зависимости от switch, то тут стоит костыль "Типпичный для c#" )
        return rndCrossroad;
    }

    // Наработки в прошлом
    // Метод Spawn(), для каждой SP точки (Работает криво по CurrentIndexSp)
    //void Spawn()
    //{
    //    // Берём текущую комнату
    //    var room = CollectionRoom.AllRooms[CollectionRoom.AllRooms.Count - 1];

    //    // Проверяем кол-во заспавненных выходов комнаты, чтобы убрать избыток
    //    if (room.CountExitRoom < room.SpawnPoints.Length)
    //    {
    //        //Debug.Log($"room.CountExitRoom => {room.CountExitRoom}");

    //        // Проверяем тип комнаты
    //        if (room.TypeRoom == Room.TypeRooms.Crossroad)
    //        {
    //            // Генерация корридоров происходит за счёт указания правильных индексов у самих SP Point-ов

    //            //Instantiate(CollectionRoom.AllTypeCorridors[CurrentIndexSP], transform);
    //            Instantiate(CollectionRoom.AllTypeCorridors[CurrentIndexSP], room.SpawnPoints[CurrentIndexSP].transform.position, CollectionRoom.AllTypeCorridors[CurrentIndexSP].transform.rotation);
    //            //Debug.Log($"Crossroad T.P => {transform.position}");
    //        }
    //        else if (room.TypeRoom == Room.TypeRooms.Corridor)
    //        {
    //            // Так как у нас SP корридоров идут по часовой стрелке, то для динамичной и удобно генерации,
    //            // у корридоров SP Index, означает номер корридора, который не нужно спавнить,
    //            // а room.SpawnPoints[CurrentIndexSP].transform.position обозначает номер корридора, у которого проходит Spawn

    //            // Рандомайзер
    //            int rnd = Random.Range(0, 5);
    //            if (rnd == CurrentIndexSP)
    //                while (rnd == CurrentIndexSP)
    //                    rnd = Random.Range(0, 5);

    //            // Проверка
    //            Debug.Log($"TypeCorridor => {room.FullName}");
    //            Debug.Log($"CurrentIndexSp => {CurrentIndexSP}");
    //            Debug.Log($"rnd => {rnd}");
    //            Debug.Log($"AllTypeCrossroads[rnd] => {CollectionRoom.AllTypeCrossroads[rnd].name}");

    //            // Спавн
    //            Instantiate(CollectionRoom.AllTypeCrossroads[rnd], room.SpawnPoints[CurrentIndexSP].transform.position, CollectionRoom.AllTypeCrossroads[rnd].transform.rotation);
    //        }

    //        // Переходим на следующий SP
    //        room.CountExitRoom++;
    //    }
    //}

    // Избыточные данные
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
    //                // Нужно заспавнить корридор сверху.
    //                rand = Random.Range(0, templates.CorridorTop.Length);
    //                Instantiate(templates.CorridorTop[rand], transform.position, templates.CorridorTop[rand].transform.rotation);
    //                break;
    //            case 2:
    //                // Нужно заспавнить корридор справа.
    //                rand = Random.Range(0, templates.CorridorRight.Length);
    //                Instantiate(templates.CorridorRight[rand], transform.position, templates.CorridorRight[rand].transform.rotation);
    //                break;
    //            case 3:
    //                // Нужно заспавнить корридор снизу.
    //                rand = Random.Range(0, templates.CorridorBottom.Length);
    //                Instantiate(templates.CorridorBottom[rand], transform.position, templates.CorridorBottom[rand].transform.rotation);
    //                break;
    //            case 4:
    //                // Нужно заспавнить корридор слева.
    //                rand = Random.Range(0, templates.CorridorLeft.Length);
    //                Instantiate(templates.CorridorLeft[rand], transform.position, templates.CorridorLeft[rand].transform.rotation);
    //                break;
    //            case 5:
    //                // Нужно заспавнить перекрёсток снизу.
    //                rand = Random.Range(0, templates.CrossroadsBottomRooms.Length);
    //                Instantiate(templates.CrossroadsBottomRooms[rand], transform.position, templates.CrossroadsBottomRooms[rand].transform.rotation);
    //                break;
    //            case 6:
    //                // Нужно заспавнить перекрёсток сверху.
    //                rand = Random.Range(0, templates.CrossroadsTopRooms.Length);
    //                Instantiate(templates.CrossroadsTopRooms[rand], transform.position, templates.CrossroadsTopRooms[rand].transform.rotation);
    //                break;

    //            case 7:
    //                // Нужно заспавнить перекрёсток слева.
    //                rand = Random.Range(0, templates.CrossroadsLeftRooms.Length);
    //                Instantiate(templates.CrossroadsLeftRooms[rand], transform.position, templates.CrossroadsLeftRooms[rand].transform.rotation);
    //                break;

    //            case 8:
    //                // Нужно заспавнить перекрёсток справа.
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
