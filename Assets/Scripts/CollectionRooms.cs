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

  public readonly int MaxCountRoom = 80;

  // Задержка спавна
  public float DeltaTime = 0f;

}
