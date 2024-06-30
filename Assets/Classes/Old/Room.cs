using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public enum TypeRooms
    {
        Crossroad,
        Corridor
    }
    public int UidRoom { get; private set; }
    public int CountExit { get; private set; }
    public string FullName { get; private set; }
    public GameObject[] SpawnPoints { get; private set; }
    public TypeRooms TypeRoom { get; private set; }

    // Счётчик заспавненных выходов
    //public int CountExitRoom = 0;

    /// <summary>
    /// Класс описания типа комнаты с хранением конкретных значений комнаты (служит универсальным объектом)
    /// </summary>
    /// <param name="spawnPoints"> Массив SP </param>
    /// <param name="nameObject"> FullName object </param>
    public Room(GameObject[] spawnPoints, string nameObject, int uidRoom)
    {
        UidRoom = uidRoom;
        CountExit = spawnPoints.Length;
        SpawnPoints = spawnPoints;
        TypeRoom = GetTypeRooms();
        FullName = nameObject;
    }

    private TypeRooms GetTypeRooms()
    {
        // Позже, надо будет сделать спавн тупиков и остальных комнат, переделав конструктор
        return CountExit > 1 ? TypeRooms.Crossroad : TypeRooms.Corridor;
    }
}
