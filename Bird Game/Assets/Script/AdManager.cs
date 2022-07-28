using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    public static AdManager instance;
    
    public void Awake()
    {
        Advertisement.Initialize("", true);
    }
    public void Start()
    {
        instance = this;
    }
    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {

            Advertisement.Show("Interstitial_Android");
        }
    }

    // 보상형 광고 보여주기
    public void ShowReward()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            ShowOptions options = new ShowOptions { resultCallback = ResultAds };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    // 광고 실행 후 결과
    public void ResultAds(ShowResult result)
    {
        switch(result)
        {
            case ShowResult.Failed : Debug.Log("실패");
                break;
            case ShowResult.Skipped : Debug.Log("넘기다");
                break;
            case ShowResult.Finished :  Debug.Log("성공");
                break;
        }

    }

}
