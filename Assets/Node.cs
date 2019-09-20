using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Node : MonoBehaviour
{
   public Color hoverColor;
   public Vector3 turrentOffset;
   protected GameObject turrent;
   protected Color normalColor;
   protected Renderer rend;

   void Start(){
   		rend = GetComponent<Renderer>();
   		normalColor = rend.material.color;
   }

   void OnMouseDown(){
   	if (turrent != null){
   		Debug.Log("Can't build there! TODO: Display can not build on node");
   		return;
   	}

   	//Build a turrent 
   	GameObject turrentToBulid = BulidManager.instance.GetTurrentToBulid();
   	turrent = (GameObject) Instantiate(turrentToBulid,transform.position+turrentOffset,transform.rotation);
   
   }
   void OnMouseEnter(){
   		rend.material.color = hoverColor;
   }

   void OnMouseExit(){
   		rend.material.color = normalColor;
   }
}
