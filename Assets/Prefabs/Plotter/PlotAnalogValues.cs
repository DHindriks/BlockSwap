using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlotAnalogValues : MonoBehaviour {

    [SerializeField] GameObject objectWithSerialConnect;        // the object to which the SerialConnect script is attached

    private List<int> actValues;
	private SerialConnect myScript;

	// Use this for initialization
	void Start () {
        myScript = objectWithSerialConnect.GetComponent<SerialConnect>();
		actValues = myScript.values;

        //  Create a new graph named "Analog0", with a range of 0 to 1024, colour green at position 100,100
        PlotManager.Instance.PlotCreate("Analog0", -1024, 1024, Color.green, new Vector2(100,100));

        // Create a new child "Analog1" graph.  Colour is red and parent is "Analog0"
        PlotManager.Instance.PlotCreate("Analog1", Color.red, "Analog0");
	}
	
	// Update is called once per frame
	void Update () {

		// get values 
		actValues = myScript.values;
		if (actValues.Count > 0) {
			// Add data to graphs
			PlotManager.Instance.PlotAdd("Analog0", actValues[0]);
			PlotManager.Instance.PlotAdd("Analog1", actValues[1]/10);   // Gidi: divide by 10 to make the microseconds more easily visible in the plot

		}
	}


}
