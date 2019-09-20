using UnityEngine;

public class CameraController : MonoBehaviour
{
    protected float panSpeed = 30f;
    protected float panBorderThickness = 10f;
    protected bool panEnabled = true;

    protected float minY = 1f;
    protected float maxY = 20f;
    protected float scrollSpeed = 3099f;
    protected bool scrollEnabled = true;

	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)){
			panEnabled = !panEnabled;
			scrollEnabled = !scrollEnabled;
		}

		if (scrollEnabled == true){
			Pan();
		}

		if (scrollEnabled == true){
			Scroll();
		}
		

	}

	protected void Scroll(){
		float scroll = Input.GetAxis("Mouse ScrollWheel");
		Vector3 newPos = transform.position;
		newPos.y -= Mathf.Clamp(scroll * scrollSpeed * Time.deltaTime,minY,maxY);
		transform.position = newPos;
	}

	protected void Pan (){
		if (Input.GetKey("w") ||  Input.mousePosition.y > Screen.height - panBorderThickness ){
			transform.Translate(Vector3.forward * panSpeed *Time.deltaTime,Space.World);
		}

		if (Input.GetKey("s") ||  Input.mousePosition.y < panBorderThickness) {
			transform.Translate(Vector3.back * panSpeed *Time.deltaTime,Space.World);
	
		}

		if (Input.GetKey("a") ||  Input.mousePosition.x > Screen.width - panBorderThickness ){
			transform.Translate(Vector3.left * panSpeed *Time.deltaTime,Space.World);
		}

		if (Input.GetKey("d") ||  Input.mousePosition.x < panBorderThickness) {
			transform.Translate(Vector3.right * panSpeed *Time.deltaTime,Space.World);
	
		}
		
		

		
	} 
}
