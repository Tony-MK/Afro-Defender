using UnityEngine;
public class Waypoints : MonoBehaviour{

    public static Transform[] points;

    void Awake(){
    	points = new Transform[transform.childCount];
    	for (int i = points.Length-1; i >= 0 ; i--){
    		points[i] = transform.GetChild(i);

    	}
    }
}
