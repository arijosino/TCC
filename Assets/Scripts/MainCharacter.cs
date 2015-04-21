using UnityEngine;
using System.Collections;

public class MainCharacter : MonoBehaviour {
    public RectTransform dialogPanel;
    public UnityEngine.UI.Text dialogText;
    public Inventory inventory = new Inventory();
    public SceneFader sceneFader;
    bool touching = false;
    Movement movementScript;
    Interactable interactable;
    public const int CART=1,STARVE=0;

    void Start() {
        movementScript = GetComponent <Movement>();
        dialogPanel.gameObject.SetActive(false);
    }

    void Update() {
        if (Input.GetButtonDown("Submit") && touching) {
            if (movementScript.enabled) {
                if (interactable.HasSomethingToSay) {
                    startDialog(null);
                }
                else {
                    if (interactable.destroyWhenFinished) {
                        Destroy(interactable.gameObject);
                    }
                }
            }
            else {
                if (interactable.finishedTalking()) {
                    Debug.Log("Done Talking");
                    interactable.resetText();
                    dialogText.text = "";
                    dialogPanel.gameObject.SetActive(false);
                    movementScript.enabled = true;
                    if (interactable.destroyWhenFinished) {
                        Destroy(interactable.gameObject);
                    }
                }
                else {
                    dialogText.text = interactable.printNextLine();
                }
            }
        }
        if (inventory.currentWeight >= inventory.totalCapacity) {
            //trigger gameover/retry event
            loseGame(MainCharacter.CART);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Interactable") {
            touching = true;
            interactable = other.gameObject.GetComponent<Interactable>();
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        touching = false;
    }
    public void startDialog(Interactable externalSource) {
        if (interactable == null) {
            interactable = externalSource;
        }
        movementScript.enabled = false; //disabling movement until message ends
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Animator>().SetFloat("speed", 0);//stopping movement animation
        dialogPanel.gameObject.SetActive(true);
        Debug.Log("Started Talking");
        dialogText.text = interactable.printNextLine();
    }

    public void loseGame(int reason) {
        Destroy(inventory.cart);
        sceneFader.startFade = true;
        sceneFader.sceneToLoad = reason;
    }
}
