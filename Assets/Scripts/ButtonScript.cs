using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    Collider col;
    ParticleSystem press;
    public bool pressed = false;

	// Use this for initialization
	void Start () {
        col = this.GetComponent<Collider>();
        press = this.GetComponentInChildren<ParticleSystem>();
        press.Stop();
        pressed = false;
    }
		
	void OnTriggerEnter()
    {
        transform.localPosition = new Vector3(0, 0.8f, 0);
        pressed = true;
        press.Play();
    }

    void OnTriggerStay() {
        transform.localPosition = new Vector3(0, 0.8f, 0);
        pressed = true;
    }

    void OnTriggerExit()
    {
        transform.localPosition = new Vector3(0, 1.1f, 0);
        pressed = false;
        press.Stop();
    }
}
