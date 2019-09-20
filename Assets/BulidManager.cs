using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulidManager : MonoBehaviour
{
	public static BulidManager instance;

	public GameObject standardTurrentPrefab;
    private GameObject turrentToBuild;
	void Awake(){
		if (instance != null){
			Debug.LogError("More than one BulidManagers in Scene");
			return;
		}
		instance = this;
	}

	

    void Start(){
    	turrentToBuild = standardTurrentPrefab;
    }
    public GameObject GetTurrentToBulid(){
    	return turrentToBuild;
    }
}
