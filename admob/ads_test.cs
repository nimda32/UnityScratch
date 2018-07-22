using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class ads_test : MonoBehaviour {
    private RewardBasedVideoAd rewardBasedVideo;
    // Use this for initialization
    void Start () {
#if UNITY_ANDROID
        string appId = "ca-app-pub-3940256099942544/5224354917";// "ca -app-pub-3530309309380568~9291176054";
#elif UNITY_IPHONE
            string appId = "ca-app-pub-3940256099942544~1458002511";
#else
        string appId = "unexpected_platform";
#endif

        StartCoroutine(StartLocation());
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);
        this.rewardBasedVideo = RewardBasedVideoAd.Instance;
        this.RequestRewardBasedVideo();

    }

    IEnumerator StartLocation()
    {
        Input.location.Start(1, 0.1f);
        yield return null;
    }

    public void RequestRewardBasedVideo()
    {
#if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3530309309380568/5444867171";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
        string adUnitId = "unexpected_platform";
#endif
        print("YAYS" + adUnitId);
        // Create an empty ad request.
        //AdRequest request = new AdRequest.Builder().Build();
        AdRequest request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("77A21109E9288AB4F4D9F6EEE891AFCE").Build();
        // Load the rewarded video ad with the request.
        this.rewardBasedVideo.LoadAd(request, adUnitId);
    }

    // Update is called once per frame
    void Update ()
    {
        if (this.rewardBasedVideo.IsLoaded())
        {
            print("YAYS!!! The add is loaded");
            this.rewardBasedVideo.Show();
        }
        //this.RequestRewardBasedVideo();
    }
}
