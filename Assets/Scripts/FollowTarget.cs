using UnityEngine;

public class FollowTarget : MonoBehaviour {
	public Transform target;
	public float hBound = 5.0f, vBound = 3.0f;
	Vector3 tempPosition;
	
	// Update is called once per frame
	void Update () {
		if(target.position.x > transform.position.x + hBound){
			
			tempPosition = transform.position;
			tempPosition.x += target.position.x - (transform.position.x + hBound);
			transform.position = tempPosition;
			
		}else if(target.position.x < transform.position.x - hBound){
			
			tempPosition = transform.position;
			tempPosition.x -= (transform.position.x - hBound) - target.position.x;
			transform.position = tempPosition;
		}
		
		if(target.position.y > transform.position.y + vBound){
			
			tempPosition = transform.position;
			tempPosition.y += target.position.y - (transform.position.y + vBound);
			transform.position = tempPosition;
		}else if(target.position.y < transform.position.y - vBound){
			
			tempPosition = transform.position;
			tempPosition.y -= (transform.position.y - vBound) - target.position.y;
			transform.position = tempPosition;
			
		}
	}
}