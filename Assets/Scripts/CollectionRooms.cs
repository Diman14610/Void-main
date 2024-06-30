using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionRooms : MonoBehaviour
{
	// Все типы перекрёстков
	public GameObject[] AllTypeCrossroads;

	// Все типы коридоров
	public GameObject[] AllTypeCorridors;

	// Все типы уникальных комнат
	public GameObject[] AllTypeUniqueRooms;

	// Все перекрёстки
	public List<GameObject> AllCrossroads;

	// Все корридоры
	public List<GameObject> AllCorridors;

	// Все комнаты
	public List<GameObject> AllRooms;

	// Тупик
	public GameObject DeadEnd;

	public readonly int MaxCountRoom = 400;

	// Задержка спавна
	public float DeltaTime = 0f;

}
/*

// Коллекция всех заспавненных комнат (К сожалению, эта идея не имеет точного контроля разных видов комнат)
public List<Room> AllRooms;
// Так же отлетает
public int CurrentIndexRoom = 0;

public GameObject[] CorridorTop;
public GameObject[] CorridorRight;
public GameObject[] CorridorBottom;
public GameObject[] CorridorLeft;

public GameObject[] CrossroadsTopRooms;
public GameObject[] CrossroadsRightRooms;
public GameObject[] CrossroadsBottomRooms;
public GameObject[] CrossroadsLeftRooms;

public GameObject[] EntryRooms;

public GameObject[] UniqueTopRooms;
public GameObject[] UniqueRightRooms;
public GameObject[] UniqueBottomRooms;
public GameObject[] UniqueLeftRooms;

public GameObject closedRoom;

public List<GameObject> rooms;
*/
