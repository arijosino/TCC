using UnityEngine;
using System.Collections;

public class ZIndexSorter : MonoBehaviour {

    void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.GetComponent<SpriteRenderer>()) {
            int myPosition = this.GetComponent<SpriteRenderer>().sortingOrder,
                otherPosition = other.gameObject.GetComponent<SpriteRenderer>().sortingOrder;

            if ((other.transform.position.y > this.transform.position.y && otherPosition > myPosition) ||
               (other.transform.position.y < this.transform.position.y && otherPosition < myPosition)) {

                this.GetComponent<SpriteRenderer>().sortingOrder = otherPosition;
                other.gameObject.GetComponent<SpriteRenderer>().sortingOrder = myPosition;
            }
        }
    }
}
