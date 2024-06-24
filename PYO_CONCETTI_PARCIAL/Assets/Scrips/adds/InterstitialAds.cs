using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAds : AdsManager, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [Header("Unit IDs")]
    [SerializeField] private string interstitialAndroidAdUnitId = "Interstitial_Android";
    [SerializeField] private string interstitialIOSAdUnitId = "Interstitial_iOS";

    private void OnEnable()
    {
        OnUnityAdsInitialized += InitializeInterstitial;
        gameManager.OnShowAd += ShowInterstitial;
    }

    private void OnDisable()
    {
        OnUnityAdsInitialized -= InitializeInterstitial;
        gameManager.OnShowAd -= ShowInterstitial;
    }

    protected override void SetIDs()
    {
#if UNITY_IOS
        adUnitId = interstitialIOSAdUnitId;
#elif UNITY_ANDROID
        adUnitId = interstitialAndroidAdUnitId;
#endif
    }

    private void InitializeInterstitial()
    {
        Advertisement.Load(adUnitId, this);
    }

    public void ShowInterstitial()
    {
        if (adLoaded)
            Advertisement.Show(adUnitId, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        adLoaded = true;
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        if (debugMode) Debug.Log($"Interstitial: Error loading Ad Unit: {adUnitId} - {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        if (debugMode) Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        if (debugMode) Debug.Log("Interstitial showing successfully");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        if (debugMode) Debug.Log("Interstitial clicked successfully");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (debugMode) Debug.Log("Interstitial fully watched");
        Advertisement.Load(adUnitId, this);
    }
}
