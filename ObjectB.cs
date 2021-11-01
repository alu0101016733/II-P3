using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectB : MonoBehaviour
{
    public delegate void playerContact();
    public static event playerContact playerMadeContact;
    private uint force_ = 0;
    // Start is called before the first frame update
    void Start() {
        ObjectA.playerCollided += madeContact;
        ObjectA.nearPlayer += nearPlayer;
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player" && playerMadeContact != null) {
            playerMadeContact();
        }
    }

    void madeContact() {
        Debug.Log("Collided with a so B has increased force to: " + ++force_);
    }

    void nearPlayer(float normDist) {
        Renderer curRenderer = GetComponent<Renderer>();
        curRenderer.material.SetColor("_Color", new Color(1f, normDist ,0f));

    }
}
