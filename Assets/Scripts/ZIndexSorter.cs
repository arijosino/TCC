using UnityEngine;
using System.Collections;

public class ZIndexSorter : MonoBehaviour {

	void OnTriggerStay2D(Collider2D other){
		Vector3 tempPosition, tempOtherPosition;
		if((other.transform.position.y > this.transform.position.y && other.transform.position.z < this.transform.position.z)|| 
		   (other.transform.position.y < this.transform.position.y && other.transform.position.z > this.transform.position.z)){

			tempPosition = this.transform.position;
			tempOtherPosition = other.transform.position;

			tempPosition.z = other.transform.position.z;
			tempOtherPosition.z = this.transform.position.z;

			this.transform.position = tempPosition;
			other.transform.position = tempOtherPosition;
		}
	}
}
