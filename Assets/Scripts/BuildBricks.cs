using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBricks : MonoBehaviour {
public Transform brick;
	// Use this for initialization
	void Start () {
		for (float y = 0f; y < 5f; y++) {
        	for (float x = -98; x < 100; x++) {
				for (float z = -75; z < 99; z += 50) {
            		Instantiate(brick, new Vector3(y%2==0 ? x : x+0.5f, y+0.5f, z), Quaternion.identity);
    	    	}
			}
    	}
 
		for (float y = 0f; y < 5; y++) {
        	for (float x = -75; x < 100; x+=50) {
				for (float z = -98; z < 100; z ++) {
					if (y % 2 == 0) {
						if ((z+25) % 50 != 0) {
        	    	  		Instantiate(brick, new Vector3(x, y+0.5f, z), Quaternion.identity);
        				}
					} else {
						if (((z+25) % 50 != 49) && ((z+25) % 50 != 0)) {
							Instantiate(brick, new Vector3(x, y+0.5f, z+0.5f), Quaternion.identity);
						}
					}
				}
			}
    	}
	}
	
}
