using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour{

	public float speed = 10f;
	private Transform target;
	private int wavepointIndex = 0;

	void Start(){
		target = Waypoints.points[wavepointIndex];
	}

	void Move(){
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime,Space.World);
	}
	void Update(){
		if (Vector3.Distance(transform.position,target.position) <= 0.2f){
			Debug.Log("Enemy has reached Waypoint.\nName: "+target.name+"\nLocation: "+target.position);
			GetNextWayPoint();
		}
		Move();
	}

	void GetNextWayPoint(){

		wavepointIndex++;
		if (wavepointIndex < Waypoints.points.Length){
			target = Waypoints.points[wavepointIndex];

		}
		else if (wavepointIndex == Waypoints.points.Length){
			Debug.Log("Enemy has peneterated Defence");
		} 
	}
 
}
