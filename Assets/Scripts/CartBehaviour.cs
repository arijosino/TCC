using UnityEngine;
using System.Collections;

public class CartBehaviour : MonoBehaviour {
    public GameObject player;
    private Animator anim;
    private bool vertical = true;
    private Vector2 lastKnownPosition, vel;

    void Start() {
        anim = (Animator)GetComponent("Animator");
        lastKnownPosition = new Vector2(transform.position.x, transform.position.y);
        vel = new Vector2(0, 0);
    }

    void Update() {

        vel.x = Mathf.Abs(transform.position.x - lastKnownPosition.x);
        vel.y = Mathf.Abs(transform.position.y - lastKnownPosition.y);

        if (vel.y > vel.x) {
            vertical = true;
        }
        else {
            vertical = false;
        }
        if (vel.x > 0 || vel.y > 0) {
            vel.x = 1;
        }
        anim.SetFloat("speed", vel.x);
        anim.SetBool("vertical", vertical);
        lastKnownPosition.x = transform.position.x;
        lastKnownPosition.y = transform.position.y;

        sortOrderWithPlayer();
    }

    private void sortOrderWithPlayer() {
        if (player.GetComponent<SpriteRenderer>()) {
            int myPosition = this.GetComponent<SpriteRenderer>().sortingOrder,
                otherPosition = player.GetComponent<SpriteRenderer>().sortingOrder;

            if ((player.transform.position.y > this.transform.position.y && otherPosition > myPosition) ||
               (player.transform.position.y < this.transform.position.y && otherPosition < myPosition)) {

                this.GetComponent<SpriteRenderer>().sortingOrder = otherPosition;
                player.GetComponent<SpriteRenderer>().sortingOrder = myPosition;
            }
        }
    }
}
