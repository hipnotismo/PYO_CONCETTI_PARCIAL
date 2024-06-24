using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAds : AdsManager
{
    [Header("Unit IDs")]
    [SerializeField] private string bannerAndroidAdUnitId = "Banner_Android";
    [SerializeField] private string bannerIOSAdUnitId = "Banner_iOS";

    private void OnEnable()
    {
        OnUnityAdsInitialized += InitializeBanner;
    }

    private void OnDisable()
    {
        OnUnityAdsInitialized -= InitializeBanner;
    }

    protected override void SetIDs()
    {
#if UNITY_IOS
        adUnitId = bannerIOSAdUnitId;
#elif UNITY_ANDROID
        adUnitId = bannerAndroidAdUnitId;
#endif
    }

    private void InitializeBanner()
    {
        BannerLoadOptions loadOptions = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Load(adUnitId, loadOptions);
    }

    private void OnBannerLoaded()
    {
        Advertisement.Banner.Show(adUnitId);
        adLoaded = true;
    }

    private void OnBannerError(string message)
    {
        adLoaded = false;
    }

    private void OnApplicationPause(bool pause)
    {
        if (!adLoaded) return;

        Debug.Log($"OnApplicationPause: {pause}");

        if (pause) Advertisement.Banner.Hide();

        else Advertisement.Banner.Show(adUnitId);
    }
}
