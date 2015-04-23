using UnityEngine;
using System.Collections;

public class CaveEntranceBehaviour : MonoBehaviour {
    public MainCharacter player;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            player.GetComponent<Movement>().enabled = false;
            if (player.inventory.currentWeight < player.inventory.totalCapacity) {
                //retry STARVE
                player.sceneFader.sceneToLoad = MainCharacter.STARVE;
                player.Invoke("endGame", 2f);
            }
            else {
                //end game
                player.sceneFader.sceneToLoad = MainCharacter.WIN;
                player.Invoke("endGame", 2f);
            }
        }
    }
}
