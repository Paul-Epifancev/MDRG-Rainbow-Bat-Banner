using System;
using MelonLoader;
using UnityEngine;
using UnityEngine.Rendering;

[assembly: MelonInfo(typeof(BatBannerAnimationMod.BannerAnim), "Rainbow Bat Banner", "1.2.0", "Paul.Epifancev #warlockforbugs (Discord: anon.jun)")]
[assembly: MelonGame(null, null)]

namespace BatBannerAnimationMod
{
    public class BannerAnim : MelonMod
    {
        private GameObject bannerObj;
        private Material bannerMat;
        private SpriteRenderer bannerRenderer; // [НОВОЕ] Кэш рендерера
        private Vector3 startLocalPos;
        private bool hasLogged;

        private float _searchTimer = 0f;
        private const float _scanInterval = 0.5f;

        // =========================================================================================
        //  [НОВОЕ] ПАРАМЕТРЫ НАТИВНОЙ РАДУГИ Fungus.dll (RainbowEffect.CycleColor)
        //  [NEW] NATIVE FUNGUS RAINBOW PARAMETERS (RainbowEffect.CycleColor)
        //  
        //  [RU] Эти параметры воспроизводят нативный метод CycleColor(int index, float speed, 
        //       float indexStep, float s, float v) из Fungus.dll (RVA: 0x4373B0)
        //  [EN] These parameters replicate the native CycleColor method from Fungus.dll
        // =========================================================================================
        
        // [RU] Скорость цикла радуги (аналог параметра 'speed' в RainbowEffect)
        // [EN] Rainbow cycle speed (equivalent to 'speed' in RainbowEffect)
        public float rainbowSpeed = 2.0f;
        
        // [RU] Фазовый сдвиг (аналог 'indexStep' — используется для каскадных эффектов)
        // [RU] Значение 0.0 = нет сдвига, 0.1 = лёгкий каскад, 0.5 = максимальный сдвиг
        // [EN] Phase step (equivalent to 'indexStep' — used for cascade effects)
        // [EN] 0.0 = no shift, 0.1 = light cascade, 0.5 = max shift
        public float rainbowIndexStep = 0.0f;
        
        // [RU] Насыщенность (аналог параметра 's' в RainbowEffect)
        // [RU] 1.0 = чистый яркий цвет, 0.7 = приглушённый пастельный
        // [EN] Saturation (equivalent to 's' in RainbowEffect)
        // [EN] 1.0 = pure bright color, 0.7 = muted pastel
        public float rainbowSaturation = 1.0f;
        
        // [RU] Яркость (аналог параметра 'v' в RainbowEffect)
        // [RU] 1.0 = максимальная яркость, 0.8 = мягкое свечение
        // [EN] Value/Brightness (equivalent to 'v' in RainbowEffect)
        // [EN] 1.0 = max brightness, 0.8 = soft glow
        public float rainbowValue = 1.0f;

        // =========================================================================================
        //  ПАРАМЕТРЫ ПОКАЧИВАНИЯ (без изменений)
        //  SWAY PARAMETERS (unchanged)
        // =========================================================================================
        public float animSpeed = 1.5f;
        public float animAmplitude = 0.05f;

        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("[Rainbow Bat Banner v1.2.0] Native Fungus RainbowEffect engine initialized.");
            LoggerInstance.Msg($"[CONFIG] Speed={rainbowSpeed}, IndexStep={rainbowIndexStep}, S={rainbowSaturation}, V={rainbowValue}");
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            this._searchTimer = 0f;
            this.bannerObj = null;
            this.bannerRenderer = null;
            CleanUpMaterial();
            this.hasLogged = false;
        }

        public override void OnUpdate()
        {
            // =========================================================================================
            //  ЭТАП 1: ПОИСК БАННЕРА (с кэшированием SpriteRenderer)
            //  STAGE 1: BANNER SEARCH (with SpriteRenderer caching)
            // =========================================================================================
            if (this.bannerObj == null)
            {
                this._searchTimer += Time.deltaTime;
                if (this._searchTimer >= _scanInterval)
                {
                    this._searchTimer = 0f;
                    this.bannerObj = GameObject.Find("BatBanner") ?? GameObject.Find("BatBanner(Clone)");

                    if (this.bannerObj != null && this.bannerObj.transform != null)
                    {
                        this.startLocalPos = this.bannerObj.transform.localPosition;
                        this.bannerRenderer = this.bannerObj.GetComponent<SpriteRenderer>();

                        if (this.bannerRenderer != null && this.bannerMat == null)
                        {
                            Shader spriteShader = Shader.Find("Sprites/Default");
                            if (spriteShader != null)
                            {
                                this.bannerMat = new Material(spriteShader);
                                this.bannerRenderer.material = this.bannerMat;
                                this.bannerRenderer.shadowCastingMode = ShadowCastingMode.Off;
                                this.bannerRenderer.receiveShadows = false;
                            }
                        }

                        if (!this.hasLogged)
                        {
                            LoggerInstance.Msg(">>> Rainbow Bat Banner v1.2.0: Cyber BatBanner secured with native Fungus rainbow! <<<");
                            this.hasLogged = true;
                        }
                    }
                }
                return;
            }

            // =========================================================================================
            //  ЭТАП 2: АНИМАЦИЯ ПОКАЧИВАНИЯ (без изменений)
            //  STAGE 2: SWAY ANIMATION (unchanged)
            // =========================================================================================
            float num = Mathf.Sin(Time.time * this.animSpeed) * this.animAmplitude;
            this.bannerObj.transform.localPosition = new Vector3(
                this.startLocalPos.x,
                this.startLocalPos.y + num,
                this.startLocalPos.z
            );

            // =========================================================================================
            //  ЭТАП 3: НАТИВНАЯ РАДУГА FUNGUS (RainbowEffect.CycleColor формула)
            //  STAGE 3: NATIVE FUNGUS RAINBOW (RainbowEffect.CycleColor formula)
            //  
            //  [RU] Воспроизводим точную математику из Fungus.dll:
            //  1. Базовый Hue = (Time.time * speed * 0.1) % 1.0
            //  2. Применяем indexStep для фазового сдвига: hue = (hue + indexStep) % 1.0
            //  3. Конвертируем HSV(hue, s, v) в RGB через нативный Color.HSVToRGB
            //  
            //  [EN] Replicating exact Fungus.dll math:
            //  1. Base Hue = (Time.time * speed * 0.1) % 1.0
            //  2. Apply indexStep for phase shift: hue = (hue + indexStep) % 1.0
            //  3. Convert HSV(hue, s, v) to RGB via native Color.HSVToRGB
            // =========================================================================================
            if (this.bannerMat != null)
            {
                // [RU] Шаг 1: Базовый Hue по нативной формуле Fungus
                // [RU] Масштабирующий коэффициент 0.1f — это константа из RainbowEffect.CycleColor
                // [EN] Step 1: Base Hue via native Fungus formula
                // [EN] Scaling factor 0.1f is a constant from RainbowEffect.CycleColor
                float baseHue = (Time.time * (this.rainbowSpeed * 0.1f)) % 1.0f;
                
                // [RU] Шаг 2: Применяем фазовый сдвиг (indexStep)
                // [RU] Это позволяет синхронизировать или рассинхронизировать радугу с персонажем
                // [EN] Step 2: Apply phase shift (indexStep)
                // [EN] Allows to sync or desync rainbow with character
                float finalHue = (baseHue + this.rainbowIndexStep) % 1.0f;
                
                // [RU] Шаг 3: Конвертация HSV → RGB с нативными параметрами s и v
                // [EN] Step 3: HSV → RGB conversion with native s and v parameters
                Color rainbowColor = Color.HSVToRGB(finalHue, this.rainbowSaturation, this.rainbowValue);
                
                this.bannerMat.SetColor("_Color", rainbowColor);
            }
        }

        private void CleanUpMaterial()
        {
            try
            {
                if (this.bannerMat != null)
                {
                    UnityEngine.Object.Destroy(this.bannerMat);
                }
            }
            catch (Exception) { }
            this.bannerMat = null;
        }

        public override void OnApplicationQuit()
        {
            CleanUpMaterial();
        }
    }
}
