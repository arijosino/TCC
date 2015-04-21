using UnityEngine;
using System.Collections;

public class Inventory {
    public float currentWeight = 0.0f, totalCapacity = 21.0f;
    public GameObject Cart {
        get { 
            return cart;
        }
    }
    private GameObject cart;

    public Inventory(GameObject cart) {
        this.cart = cart;
    }
}
