using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class FruitBehaiviour : MonoBehaviour {
    private MainCharacter player;
    //making the weight public so it will be editable by unity when applied to other fruit prefabs without the need for inheritance
    public float weight;
    void Start() {
        player = GameObject.Find("MainCharacter").GetComponent<MainCharacter>();
    }

    // Update is called once per frame
    void Update() {

    }

    void OnDestroy() {
        //the player got the fruit, so a weight must be added to the cart
        player.inventory.currentWeight += this.weight;
    }
}
