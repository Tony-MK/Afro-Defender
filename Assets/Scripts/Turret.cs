using UnityEngine;

public class Turret : MonoBehaviour
{ 
	public Transform partToRotate;
    protected GameObject target;

	[Header("Attributes")]
	public float fireRate = 1f;
    public float fireCountdown = 0f;

    [Header("Unity Setup Field")]
    public float range = 15f;
    public string enemyTag = "Enemy";
    public float turnSpeed = 10f;

    public GameObject bulletPrerab;
    public Transform firePoint;
    

    // Use this for initialization
    void Start(){
    	InvokeRepeating("UpdateTarget",0f,0.5f);
    }


    void UpdateTarget(){
    	float shortDistance = Mathf.Infinity;
    	GameObject nearestEnemy = null;
    	foreach(GameObject enemy in GameObject.FindGameObjectsWithTag(enemyTag)){
    		float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
    		if (distanceToEnemy < shortDistance){
    			shortDistance = distanceToEnemy;
    			nearestEnemy = enemy;
    		}
    	}

    	if (nearestEnemy != null && shortDistance <= range){
    		target = nearestEnemy;
    	}
    }

    // Update is called once per frame;
    void Update(){
    	if (target== null){
    		return;
    	}

    	Vector3  dir = target.transform.position - transform.position;
    	Quaternion lookRotation = Quaternion.LookRotation(dir);
    	Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation, turnSpeed * Time.deltaTime).eulerAngles;
    	partToRotate.rotation = Quaternion.Euler(0f,rotation.y, 0f);


    	if (fireCountdown <= 0f){
    		Shoot();
    		fireCountdown = 1f / fireRate;
    	}

    	fireCountdown -= Time.deltaTime;

    }

    void Shoot(){
    	GameObject bulletObject  = (GameObject) Instantiate(bulletPrerab, firePoint.position,firePoint.rotation);
        
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        if (bullet != null){
            bullet.LockTarget(target);
        }
    	Debug.Log("SHOOT");

    }
    void OnDrawGizmosSelected(){
    	Gizmos.color = Color.red;
    	Gizmos.DrawWireSphere(transform.position,range);
    }
}
