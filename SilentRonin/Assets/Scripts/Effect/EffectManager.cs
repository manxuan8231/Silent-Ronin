using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance;

    [Header("Effect Prefabs")]
    public GameObject jumpEffectPrefab;
    public GameObject landEffectPrefab;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // Hiệu ứng nhảy
    public void PlayJumpEffect(Vector3 pos)
    {
        if (jumpEffectPrefab != null)
            Instantiate(jumpEffectPrefab, pos, Quaternion.identity);
        
    }

    // Hiệu ứng đáp đất
    public void PlayLandEffect(Vector3 pos)
    {
        if (landEffectPrefab != null)
            Instantiate(landEffectPrefab, pos, Quaternion.identity);
        
    }
}
