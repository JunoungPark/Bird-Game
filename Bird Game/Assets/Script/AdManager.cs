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

    // ������ ���� �����ֱ�
    public void ShowReward()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            ShowOptions options = new ShowOptions { resultCallback = ResultAds };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    // ���� ���� �� ���
    public void ResultAds(ShowResult result)
    {
        switch(result)
        {
            case ShowResult.Failed : Debug.Log("����");
                break;
            case ShowResult.Skipped : Debug.Log("�ѱ��");
                break;
            case ShowResult.Finished :  Debug.Log("����");
                break;
        }

    }

}
