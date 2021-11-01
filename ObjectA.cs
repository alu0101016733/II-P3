using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectA : MonoBehaviour
{   
    public delegate void playerCollision();
    public static event playerCollision playerCollided;
    public delegate void playerIsNear(float normDist);
    public static event playerIsNear nearPlayer;

    private GameObject player_;
    private uint counter_ = 0;
    public float distanceForActivation_ = 4.5f;
    // Start is called before the first frame update
    void Start() {
        player_ = GameObject.FindGameObjectWithTag("Player");
        ObjectB.playerMadeContact += madeContact;
    }

    // Update is called once per frame
    void Update() {
         if (Vector3.Distance(player_.transform.position, transform.position) < distanceForActivation_) {
            nearPlayer(Vector3.Distance(player_.transform.position, transform.position) / distanceForActivation_);
        }
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player" && playerCollided != null) {
            playerCollided();
        }
    }

    void madeContact() {
        Debug.Log("Inside A but collided con B");
        Text textElement = GameObject.FindGameObjectWithTag("ObjectAUIText").GetComponent<Text>();
        textElement.text = "Contact with B for " + ++counter_ + " times";
    }
}
