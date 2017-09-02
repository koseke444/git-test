using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour {
	//重力加速度
	const float Gravity = 9.81f;
	//重力の適応具合
	public float gravityScal = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vector = new Vector3 ();
		//Unityエディターと実機で処理を分ける
		if (Application.isEditor) {
			
			//キーの入力を検知しベクトルを設定
			vector.x = Input.GetAxis ("Horizontal");
			vector.y = Input.GetAxis ("Vertical");
	
			//高さ方向キーの判定はキーのzとする
			if (Input.GetKey ("z")) {
				vector.y = 1.0f;
			} else {
				vector.y = -1.0f;
			}
		} else {
			//重力センサーの入力をUnity空間の軸にマッピングする
			vector.x = Input.acceleration.x;
			vector.z = Input.acceleration.y;
			vector.y = Input.acceleration.z;
		}
			//シーンの重力を入力vector.x = Input.acceleration.x;ベクトルの方向に合わせて変化させる
			Physics.gravity = Gravity*vector.normalized *gravityScal;
			
		
	}
}
