using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] bool IsSpawned = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        IsSpawned = true;
        // Такой метод используется для удаления объекта
        //if (collision.CompareTag("Corridor") | collision.CompareTag("Crossroad"))
        //{
        //    Debug.Log($"gameObject.name => {gameObject.name}");
        //    Destroy(gameObject);
        //}

        // Проверка collision.tagameobject.tag или gameobject.tag
        // collision.gameobject.tag - является SP уже существующего объекта
        // gameobject.tag - является SP заспавненного объекта

        // Например при EntryRoom получается:
        // 1) - Crossroad;
        // 2) - Corridor;
        // Если не менять две команды ниже местами, то получится порядок, как чуть выше
        //Debug.Log($"collision.gameobject.tag => {collision.gameObject.tag}");
        //Debug.Log($"gameobject.tag => {gameObject.tag}");

        //#warning Think!
        //Debug.Log($"collision.gameobject.tag => {collision.gameObject.tag}");
        //Debug.Log($"gameobject.tag => {gameObject.tag}");

        //if (collision.CompareTag("Corridor") & gameObject.CompareTag("Corridor"))
        //{
        //    Destroy(collision.gameObject);
        //    Destroy(gameObject);
        //}
        //else if (collision.CompareTag("Crossroad") & gameObject.CompareTag("Crossroad"))
        //{
        //    Destroy(collision.gameObject);
        //    Destroy(gameObject);
        //}

        //if (collision.CompareTag("Corridor") & gameObject.CompareTag("Corridor"))
        //{
        //    Destroy(gameObject);
        //}
        //else if (collision.CompareTag("Crossroad") & gameObject.CompareTag("Crossroad"))
        //{
        //    Destroy(gameObject);
        //}

        // Следовательно
        //if (collision.CompareTag("Corridor") & !gameObject.CompareTag("Crossroad"))
        //{
        //    Destroy(gameObject);
        //}

        //if (collision.CompareTag("Crossroad") | collision.CompareTag("Corridor") | collision.CompareTag("Room"))
        //{
        //    // Для понимания
        //    // collision.gameobject.name - указывает на объект который хотели заспавнить и его tag
        //    Debug.Log($"gameobject.Detected => {collision.gameObject.name}");
        //    Debug.Log($"gameobject.Detected.tag => {collision.gameObject.tag}");
        //    //var collectionRoom = CollectionRooms
        //    //Instantiate(CollectionRoom.DeadEnd, collision.gameObject.transform.position, CollectionRoom.DeadEnd.transform.rotation);
        //    Destroy(collision.gameObject);
        //}
    }
}
