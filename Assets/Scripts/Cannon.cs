using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {
    public int CannonSpeed = 100;
    public float timeCannon = 3.0f;
    public float MassIncreaseAt = 2.8f;
    private float timeDef;
    public bool timerCannon = true;
    public float MassShot = 10;
    public GameObject CannonObject;
    private bool CannonOnOf = false;
    public bool cannonGame = false;
    ButtonScript scriptButton;
    public GameObject goldblock;
    public ParticleSystem activated;

    // Use this for initialization
    void Start () {
        timeDef = timeCannon;
        if (cannonGame == true) {
           scriptButton = GameObject.Find("Top").GetComponent<ButtonScript>();
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (scriptButton.pressed == true)
        {
            activated.Play();
        } else
        {
            activated.Stop();
        }


        if (timerCannon == false) {
            Cannons();
            //goldblock.GetComponent<Rigidbody>().freezeRotation = true;
        }
        else {
            //goldblock.GetComponent<Rigidbody>().freezeRotation = false;
            timeCannon = timeDef;
            MassShot = 1;
            goldblock.GetComponent<Rigidbody>().mass = MassShot;
        }

        if (cannonGame == true) {
            if (scriptButton.pressed) {
                CannonOnOf = true;
            }
            else if (CannonOnOf == false) {
                
                MassShot = 1;
                goldblock.GetComponent<Rigidbody>().mass = MassShot;

            }
        }

    }

    void Cannons() {
        if (CannonOnOf == true) {
            timeCannon -= Time.deltaTime;
            if (timeCannon >= 0) {
                goldblock.GetComponent<Rigidbody>().AddForce(CannonObject.transform.forward * CannonSpeed);
                if (timeCannon <= MassIncreaseAt) {
                    goldblock.GetComponent<Rigidbody>().mass = MassShot;
                    MassShot++;
                    if (timeCannon <= MassIncreaseAt) {
                        MassShot++;
                    }
                }
            }
            else {
                timerCannon = true;
                timeCannon = timeDef;
                MassShot = 1;
                goldblock.GetComponent<Rigidbody>().mass = MassShot;
            }
        }
    }

    public void resetTime() {
        timerCannon = true;
        timeCannon = timeDef;
        MassShot = 1;
        goldblock.GetComponent<Rigidbody>().mass = MassShot;
    }
}
