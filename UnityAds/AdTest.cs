using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(ShowAd());
    }

    public IEnumerator ShowAd()
    {
        while (!Advertisement.IsReady()) {
            print("Waiting for Ads...");
            yield return null;
        }
        Advertisement.Show();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
