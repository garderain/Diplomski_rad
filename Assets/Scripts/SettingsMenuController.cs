using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using System;

public class SettingsMenuController : MonoBehaviour
{
    public Volume globalVolume;
    public Light sunLight;

    public List<Light> normalLights;
    public List<Light> RTXLightsPerformance;
    public List<Light> RTXLightsQuality;

    private void Awake() 
    {
        
    }

    public void SetAOSettings(string AOSettingsLevel) 
    {
        AmbientOcclusion ambientOcclusion = null;

        this.globalVolume.sharedProfile.TryGet<AmbientOcclusion>(out ambientOcclusion);

        switch (AOSettingsLevel)
        {
            case "SSAO":
                ambientOcclusion.rayTracing.overrideState = true;
                ambientOcclusion.rayTracing.value = false;
                ambientOcclusion.quality.overrideState = true;
                ambientOcclusion.quality.value = 2;
                break;
            case "RTX_LOW":
                ambientOcclusion.rayTracing.overrideState = true;
                ambientOcclusion.rayTracing.value = true;
                ambientOcclusion.quality.overrideState = true;
                ambientOcclusion.quality.value = 0;
                break;
            case "RTX_MID":
                ambientOcclusion.rayTracing.overrideState = true;
                ambientOcclusion.rayTracing.value = true;
                ambientOcclusion.quality.overrideState = true;
                ambientOcclusion.quality.value = 1;
                break;
            case "RTX_HIGH":
                ambientOcclusion.rayTracing.overrideState = true;
                ambientOcclusion.rayTracing.value = true;
                ambientOcclusion.quality.overrideState = true;
                ambientOcclusion.quality.value = 3;
                ambientOcclusion.rayLength = 5;
                break;
        }
    }

    public void SetReflectionSettings(string reflectionSettingsLevel)
    {
        ScreenSpaceReflection screenSpaceReflection = null;

        this.globalVolume.sharedProfile.TryGet<ScreenSpaceReflection>(out screenSpaceReflection);

        switch (reflectionSettingsLevel)
        {
            case "SSR":
                screenSpaceReflection.enabled.overrideState = true;
                screenSpaceReflection.enabled.value = true;
                screenSpaceReflection.rayTracing.overrideState = true;
                screenSpaceReflection.rayTracing.value = false;
                break;
            case "RP":
                screenSpaceReflection.enabled.overrideState = true;
                screenSpaceReflection.enabled.value = false;
                break;
            case "RTX_LOW":
                screenSpaceReflection.enabled.overrideState = true;
                screenSpaceReflection.enabled.value = true;
                screenSpaceReflection.rayTracing.overrideState = true;
                screenSpaceReflection.rayTracing.value = true;
                screenSpaceReflection.mode.overrideState = true;
                screenSpaceReflection.mode.value = RayTracingMode.Performance;
                screenSpaceReflection.quality.overrideState = true;
                screenSpaceReflection.quality.value = 1;
                break;
            case "RTX_MID":
                screenSpaceReflection.enabled.overrideState = true;
                screenSpaceReflection.enabled.value = true;
                screenSpaceReflection.rayTracing.overrideState = true;
                screenSpaceReflection.rayTracing.value = true;
                screenSpaceReflection.mode.overrideState = true;
                screenSpaceReflection.mode.value = RayTracingMode.Performance;
                screenSpaceReflection.quality.overrideState = true;
                screenSpaceReflection.quality.value = 2;
                break;
            case "RTX_HIGH":
                screenSpaceReflection.enabled.overrideState = true;
                screenSpaceReflection.enabled.value = true;
                screenSpaceReflection.rayTracing.overrideState = true;
                screenSpaceReflection.rayTracing.value = true;
                screenSpaceReflection.mode.overrideState = true;
                screenSpaceReflection.mode.value = RayTracingMode.Quality;
                screenSpaceReflection.bounceCount.overrideState = true;
                screenSpaceReflection.bounceCount.value = 3;
                screenSpaceReflection.sampleCount.overrideState = true;
                screenSpaceReflection.sampleCount.value = 1;
                break;
        }
    }

    public void SetGlobalIlluminationSettings(string globalIlluminationSettingsLevel)
    {
        GlobalIllumination globalIllumination = null;

        this.globalVolume.sharedProfile.TryGet<GlobalIllumination>(out globalIllumination);

        switch (globalIlluminationSettingsLevel)
        {
            case "SSGI":
                globalIllumination.enable.overrideState = true;
                globalIllumination.enable.value = true;
                globalIllumination.rayTracing.overrideState = true;
                globalIllumination.rayTracing.value = false;
                break;
            case "B":
                globalIllumination.enable.overrideState = true;
                globalIllumination.enable.value = false;
                break;
            case "RTX_LOW":
                globalIllumination.enable.overrideState = true;
                globalIllumination.enable.value = true;
                globalIllumination.rayTracing.overrideState = true;
                globalIllumination.rayTracing.value = true;
                globalIllumination.mode.overrideState = true;
                globalIllumination.mode.value = RayTracingMode.Performance;
                globalIllumination.quality.overrideState = true;
                globalIllumination.quality.value = 1;
                break;
            case "RTX_MID":
                globalIllumination.enable.overrideState = true;
                globalIllumination.enable.value = true;
                globalIllumination.rayTracing.overrideState = true;
                globalIllumination.rayTracing.value = true;
                globalIllumination.mode.overrideState = true;
                globalIllumination.mode.value = RayTracingMode.Performance;
                globalIllumination.quality.overrideState = true;
                globalIllumination.quality.value = 2;
                break;
            case "RTX_HIGH":
                globalIllumination.enable.overrideState = true;
                globalIllumination.enable.value = true;
                globalIllumination.rayTracing.overrideState = true;
                globalIllumination.rayTracing.value = true;
                globalIllumination.mode.overrideState = true;
                globalIllumination.mode.value = RayTracingMode.Quality;
                globalIllumination.bounceCount.overrideState = true;
                globalIllumination.bounceCount.value = 3;
                globalIllumination.sampleCount.overrideState = true;
                globalIllumination.sampleCount.value = 1;
                break;
        }
    }

    public void SetShadowSettings(string shadowsSettingLevel)
    {
        switch (shadowsSettingLevel)
        {
            case "PCSS":
                foreach(Light light in this.normalLights)
                {
                    light.gameObject.SetActive(true);
                }
                foreach (Light light in this.RTXLightsPerformance)
                {
                    light.gameObject.SetActive(false);
                }
                foreach (Light light in this.RTXLightsQuality)
                {
                    light.gameObject.SetActive(false);
                }
                break;
            case "RTX_P":
                foreach (Light light in this.normalLights)
                {
                    light.gameObject.SetActive(false);
                }
                foreach (Light light in this.RTXLightsPerformance)
                {
                    light.gameObject.SetActive(true);
                }
                foreach (Light light in this.RTXLightsQuality)
                {
                    light.gameObject.SetActive(false);
                }
                break;
            case "RTX_Q":
                foreach (Light light in this.normalLights)
                {
                    light.gameObject.SetActive(false);
                }
                foreach (Light light in this.RTXLightsPerformance)
                {
                    light.gameObject.SetActive(false);
                }
                foreach (Light light in this.RTXLightsQuality)
                {
                    light.gameObject.SetActive(true);
                }
                break;
        }
    }

    public void SetPathTracingSettings(bool enable)
    {
        PathTracing pathTracing = null;

        this.globalVolume.sharedProfile.TryGet<PathTracing>(out pathTracing);

        if (enable)
        {
            pathTracing.enable.overrideState = true;
            pathTracing.enable.value = true;
        }
        else
        {
            pathTracing.enable.overrideState = true;
            pathTracing.enable.value = false;
        }
    }
}
