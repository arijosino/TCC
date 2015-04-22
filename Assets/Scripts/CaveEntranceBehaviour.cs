using UnityEngine;
using System.Collections;

public class CaveEntranceBehaviour : MonoBehaviour {
    public MainCharacter player;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            if (player.inventory.currentWeight < player.inventory.totalCapacity) {
                //retry STARVE
            }
            else {
                //game over
            }
        }
    }
}
