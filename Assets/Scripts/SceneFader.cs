using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour {
    public float initialAlpha, finalAlpha;
    private float direction;
    public bool startFade = false;
    public int sceneToLoad = -1;
    private Image fader;
    private Color c;

    // Use this for initialization
    void Start() {
        fader = GetComponent<Image>();

        c = fader.color;
        c.a = initialAlpha;
        fader.color = c;

        direction = finalAlpha - initialAlpha / Mathf.Abs(finalAlpha - initialAlpha); //either 1 or -1
    }

    // Update is called once per frame
    void Update() {
        if (startFade) {
            if (Mathf.Abs(fader.color.a - finalAlpha) > 0.1f) {
                c = fader.color;
                c.a += direction * Time.deltaTime;
                fader.color = c;
                Debug.Log(fader.color.a);
            }
            else {
                if(sceneToLoad > -1){
                    Application.LoadLevel("GameOver" + sceneToLoad);
                }
            }
        }
    }

}
