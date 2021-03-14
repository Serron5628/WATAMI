using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class LockOnSystem : MonoBehaviour
{
	public GameObject enemyUnit;
	public GameObject Weapon;
	private GameObject target;
	private int elapsedTime = 0;
	private const int MAX_LOCK_ON_TIME = 3600;
	private bool isLockOn = false;
	public float lockOnCircle = 150;

	void Start()
	{

	}


	void Update()
	{

		lockOnProc();

		//ロックオン完了までの時間を越えた場合ロックオン！！
		//if (Weapon.GetComponent<Weapon>().getLockOnTime() <= elapsedTime)
		//{
		//	isLockOn = true;
		//}
		//else
		//{
		//	isLockOn = false;
		//}

		Debug.DrawLine(this.transform.position, enemyUnit.transform.position, Color.red);
	}


	/*ロックオン処理*/
	private void lockOnProc()
	{

		//敵がゲーム画面内にいる場合
		if (enemyUnit.GetComponent<UnitManagement>().getIsRendered())
		{

			//敵との間に障害物無い場合
			if (Physics.Linecast(this.transform.position, enemyUnit.transform.position, LayerMask.GetMask("Field")) == false)
			{
				Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, enemyUnit.transform.position);
				screenPoint.x = screenPoint.x - (Screen.width / 2);
				screenPoint.y = screenPoint.y - (Screen.height / 2);

				//ロックオンサークル内の場合
				if (screenPoint.magnitude <= lockOnCircle)
				{

					if (elapsedTime < MAX_LOCK_ON_TIME)
					{
						elapsedTime++;
					}
					target = enemyUnit;
					return;     //処理終了

				}
			}

		}
		//敵がロックオンできない状態の場合
		elapsedTime = 0;
		return;
	}


	public int getElapsedTime()
	{
		return elapsedTime;
	}

	public GameObject getTarget()
	{
		return target;
	}

	public bool getIsLockOn()
	{
		return isLockOn;
	}
}