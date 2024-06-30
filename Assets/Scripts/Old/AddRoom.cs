using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour {

	// Я ЕБАЛ этот сраный массив. Просто ПИЗДЕЦ! Отнял у меня дохуя времени и работает БЛЯТЬ, через 5-ую С*ка точку. А-а-а-а-а-а-а-а-а...
	// Кароче, это дерьмо работает через ЖОПУ, большую такую!
	// Если в это дерьмо закинуть SP по часовой стрелки, то эта ПИЗДА, всё сделает Задом на оборот, если все остальные массивы идут от 0,
	// то эта Сраная Пизда, идёт с КОНЦА И У НЕЁ ОТСЧЁТ ИДЁТ БЛЯТЬ С КОНЦА. Я ЕБАЛ ВСЁ ЭТО! С*ка...
	// Так что для правильной работы этой ПИЗДЫ, засунте в неё елементы SP против часовой стрелки с SP Left, до SP Top.
	// Иначе эта ПИЗДА всё С*ка сломает...
	public GameObject[] SpawnPoints;
	private CollectionRooms CollectionRoom;

	void Start()
	{
		// Добавление текущего объекта в List комнат
		//CollectionRoom = GameObject.FindGameObjectWithTag("Rooms").GetComponent<CollectionRooms>();

		// Так как, у нас универсальный класс и он не может быть создан без полученных данных, то нам нудно использовать new, вместо AddComponent()
		//CollectionRoom.AllRooms.Add(new Room(SpawnPoints, this.gameObject.name, CollectionRoom.CurrentIndexRoom));

		//if (CollectionRoom.AllRooms.Count < 5)
		//	CollectionRoom.AllRooms.Add(new Room(SpawnPoints, this.gameObject.name));
		//CollectionRoom.AllRooms.Add(new Room(SpawnPoints, this.gameObject.name));
		//CollectionRoom.AllRooms.Add(gameObject.AddComponent(SpawnPoints, this.gameObject.name));
	}
}
