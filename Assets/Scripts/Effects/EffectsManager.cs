using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Ebac.Core.Singleton;
using Cinemachine;
using System.Collections.Generic;

public class EffectsManager : Singleton<EffectsManager> {
    public PostProcessVolume postProcessVolume;
    public List<CinemachineVirtualCamera> virtualCameras;
    public float duration = 1f; 

    private float shakeTime; 
    private Vignette vignetteEffect;

    private void Update() {
        if (shakeTime > 0) {
            shakeTime -= Time.deltaTime;
        } else {
            if (virtualCameras.Count > 0) {
                virtualCameras.ForEach(vc => {
                    CinemachineBasicMultiChannelPerlin perlin = vc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                    if (perlin != null) {
                        perlin.m_AmplitudeGain = 0f;
                        perlin.m_FrequencyGain = 0f;
                    }
                });
            }
        }
    }

    public void TakeDamageEffect() {
        StartCoroutine(DamageEffect());
    }

    IEnumerator DamageEffect() {
        Vignette temp;

        if (postProcessVolume.profile.TryGetSettings<Vignette>(out temp)) {
            vignetteEffect = temp;
        }

        ColorParameter color = new ColorParameter();

        float time = 0;
        while (time < duration) {
            color.value = Color.Lerp(Color.black, Color.red, time / duration);
            time += Time.deltaTime;
            vignetteEffect.color.Override(color);
            yield return new WaitForEndOfFrame();
        }
        time = 0;
        while (time < duration) {
            color.value = Color.Lerp(Color.red, Color.black, time / duration);
            time += Time.deltaTime;
            vignetteEffect.color.Override(color);
            yield return new WaitForEndOfFrame();
        }
    }

    public void CameraShake(float amplitude, float frequency, float time) {
        if (virtualCameras.Count > 0) {
            virtualCameras.ForEach(vc => {
                CinemachineBasicMultiChannelPerlin perlin = vc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                if (perlin != null) {
                    perlin.m_AmplitudeGain = amplitude;
                    perlin.m_FrequencyGain = frequency;
                }
            });
            shakeTime = time;
        }
    }
}
