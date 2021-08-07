using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPSManager : MonoBehaviour {

    public Text txtLast;
    public Text txtCurrent;

    public float latitude;
    public float longitude;

	// Use this for initialization
	void Start () {
        StartCoroutine(StartLocationService());
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Cancel")) Application.Quit();

        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;

        txtCurrent.text = string.Format("Current : {0:0.000000}, Longitude : {1:0.000000}", latitude, longitude);
    }

    // Start Location
    IEnumerator StartLocationService () {
        if (!Input.location.isEnabledByUser) {
            txtLast.text = "GPS를 사용할 수없음...";
            yield break;
        }

        Input.location.Start();
        int maxWait = 20;

        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (Input.location.status == LocationServiceStatus.Failed) {
            txtLast.text = "Location Failed..";
            yield break;
        }

        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;

        txtLast.text = string.Format("Last    : {0:0.000000}, Longitude : {1:0.000000}", latitude, longitude);
    }
}
