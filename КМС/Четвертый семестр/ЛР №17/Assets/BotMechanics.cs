using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMechanics : MonoBehaviour
{
	float moveSpeed = 0.5f;   // скорость передвижения танка-бота
	float rotationSpeedTank = 0.8f;  // скорость поворота танка-бота
	float rotationSpeedMuzzle = 0.5f;  // скорость поворота башни танка-бота
	float BulletSpeed = 5f;       // скорость снаряда танка-бота
	public Transform tower;  // для управления башней
	public Transform muzzle; // для управления стволом
	public GameObject bullet; // для ссылки на префаб снаряда

	public AudioClip fire;
	bool canShoot = true;   // для определения, может ли танк-бот произвести выстрел
	int life = 3;           // для определения максимального количества попаданий в танк-бот
	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "player")
		{
			//ОПРЕДЕЛЯЕМ КВАТЕРНИОН ДЛЯ ПОВОРОТА БОТА В СТОРОНУ ИГРОКА
			// определяем вектор направления между игроком и ботом
			Vector3 relativePos = other.transform.position - transform.position;
			// по найденному вектору определяем кватернион для поворота
			//LookRotation() вычисляет кватернион
			Quaternion newrot = Quaternion.LookRotation(relativePos) * Quaternion.AngleAxis(0, Vector3.down);

			// ПОВОРАЧИВАЕМ БАШНЮ ТАНКА-БОТА В СТОРОНУ ТАНКА - ИГРОКА
			//Slerp() задает плавный поворот объекта
			tower.rotation = Quaternion.Slerp(tower.rotation, newrot, Time.deltaTime * rotationSpeedMuzzle);
            //переменная для определения объекта попадания «луча»
            RaycastHit hit;

			//МЕТОД «БРОСАНИЯ ЛУЧЕЙ» для определения момента, повернута ли башня на игрока
			//Physics.Raycast создает «луч» в заданном направлении.
			if (Physics.Raycast(muzzle.position, muzzle.TransformDirection(new Vector3(0,0,1)), out hit))
			{	//если луч попал в коллайдер игрока и можно выстрелить
				if ((hit.transform.tag == "player") && canShoot)
					//запускаем короутину для выстрела танка-бота
					StartCoroutine(BotShoot());
				
			}
			//ПЛАВНЫЕ ДВИЖЕНИЕ И ПОВОРОТ ТАНКА-БОТА В НАПРАВЛЕНИИ К ТАНКУ-ИГРОКУ
			//дистанцию от бота до игрока
			float distance = Vector3.Distance(other.transform.position, transform.position);

			// вычисляем дистанцию бота до игрока
			if (distance > 10 && distance < 20)
			{	//плавно поворачиваем танк-бот в сторону танка-игрока с заданной скоростью
				transform.rotation = Quaternion.Slerp(transform.rotation, newrot, Time.deltaTime * rotationSpeedTank);
				// плавно двигаем танк-бота в сторону игрока, меняя значения по осям X и Z 
				//Lerp() задает плавный переход от одной позиции в 3D-пространстве к другой с заданной скоростью
				transform.position = Vector3.Lerp(transform.position, other.transform.position, Time.deltaTime * moveSpeed);
            }
        }
	}
	//КОРОУТИНА ДЛЯ ЗАПУСКА ВЫСТРЕЛА ТАНКА-БОТА
	IEnumerator BotShoot()
	{
		//указываем, что танк-бот стрелять пока не может 
		canShoot = false;
		//определяем координату для положения снаряда танка-бота
		Vector3 MuzzleForward = muzzle.transform.position + muzzle.transform.TransformDirection(Vector3.zero);
		Vector3 muzzleRot = muzzle.rotation.eulerAngles;
		muzzleRot = new Vector3(muzzleRot.x + 90, muzzleRot.y, muzzleRot.z);
		//создаем снаряд из префаба снаряда в требуемой координате относительно ствола
		Instantiate(bullet, MuzzleForward, Quaternion.Euler(muzzleRot));
		//3 секи перзарядка
		yield return new WaitForSeconds(3f);
		//указываем, что танк может сделать выстрел
		canShoot = true;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "core")
		{
			life--;
			if (life < 1) Destroy(gameObject);
		}
	}

}
