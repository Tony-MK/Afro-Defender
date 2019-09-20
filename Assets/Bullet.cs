
using UnityEngine;

public class Bullet : MonoBehaviour{
	
	private GameObject target;
	public GameObject impactEffect;
	private float impactEffectLifeSpan = 3f;
	public float speed = 70f; 


	public void LockTarget(GameObject _target){
		target = _target;
	}

	private void TargetHit(){
		Destroy(Instantiate(impactEffect,transform.position,transform.rotation),impactEffectLifeSpan);
		Debug.Log("Target "+target.name+" >> Hit: POSTIVE Kill Confirmed: "+KilledConfirmed());
		Destroy(gameObject);
	}

	private string KilledConfirmed(){
		Destroy(target);
		return " POSTIVE";
		
	}

	private void SeekTarget(){
    	Vector3 dir = target.transform.position - transform.position ;
    	float distanceThisFrame = speed * Time.deltaTime;

    	if (dir.magnitude <= distanceThisFrame){
    		TargetHit();
    		return;
    	}
    	transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void Update(){
    	if (target == null){
    		Destroy(gameObject);
    		return;
    	}
    	SeekTarget();
    }

    

}
