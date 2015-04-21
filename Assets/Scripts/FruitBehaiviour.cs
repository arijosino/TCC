using UnityEngine;
using System.Collections;

public class FruitBehaiviour : MonoBehaviour {
    private MainCharacter player;
    //making the weight public so it will be editable by unity when applied to other fruit prefabs without the need for inheritance
    public float weight;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnDestroy() {
        //when destroyed, it means that the player got the fruit, so a weight must be added to the cart
        player = (MainCharacter)FindObjectOfType(typeof(MainCharacter));
        player.inventory.currentWeight += this.weight;

        if (player.inventory.currentWeight >= player.inventory.totalCapacity) {
            //trigger gameover/retry event

        }
    }
}
