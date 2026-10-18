# 🦇 Rainbow Bat Banner v1.2.0

A Halloween-themed room decoration mod for **My Dystopian Robot Girlfriend (MDRG)**.  
*(Хэллоуинский декоративный мод для комнаты в My Dystopian Robot Girlfriend (MDRG))*

Replaces the static in-game bat banner with a smoothly swaying, rainbow-cycling cyber-banner powered by the game's own native HSV pipeline.  
*(Заменяет статичный баннер в игре на плавно покачивающийся кибер-баннер с радужной анимацией, использующий нативный HSV-пайплайн игры)*

## 🎬 Video Showcase / Видео-демонстрация
[![Rainbow Bat Banner Showcase](https://img.youtube.com/vi/29CJjzQAkn4/maxresdefault.jpg)](https://youtu.be/29CJjzQAkn4)  
*(Click the image above to watch the full showcase / Нажмите на изображение, чтобы посмотреть полное видео)*

---

## ⚙️ Architecture & Features / Архитектура и возможности
- **Optimized C# Rendering / Оптимизированный C# рендеринг:** Uses `SpriteRenderer` caching and native `Color.HSVToRGB()` cycling, perfectly replicating the native HSV pipeline.  
  *(Использует кэширование `SpriteRenderer` и нативную конвертацию `Color.HSVToRGB()`, в точности повторяющую нативный HSV-пайплайн)*
- **Zero Harmony Patches / Ноль Harmony-патчей:** Pure Unity API implementation. No memory hacking, no method hooking. This guarantees **no conflicts** with other mods and **no crashes** after game updates.  
  *(Реализация на чистом Unity API. Без взлома памяти и перехвата методов. Гарантирует **отсутствие конфликтов** с другими модами и **отсутствие вылетов** после обновлений игры)*
- **Scene Isolation / Изоляция сцен:** Auto-hides during intimacy scenes to prevent runtime errors.  
  *(Автоматически скрывается во время интимных сцен для предотвращения ошибок выполнения)*
- **0% FPS Impact / 0% влияния на FPS:** Intelligent caching and a 0.5s scan interval ensure maximum performance.  
  *(Интеллектуальное кэширование и интервал сканирования 0.5 секунды обеспечивают максимальную производительность)*

## 🛡️ Safety & Transparency / Безопасность и прозрачность
- ✅ **100% Open Source (MIT License):** Full C# code is available for review.  
  *(Полный исходный код C# доступен для проверки)*
- ✅ **No Malware:** No memory injection, no stealers, no hidden telemetry.  
  *(Без инъекций в память, стилеров или скрытой телеметрии)*
- ✅ **Free Forever:** No Patreon, no subscriptions, no paywalls.  
  *(Навсегда бесплатно: без Patreon, подписок и платных стен)*

## 📦 Installation / Установка
1. Ensure you have [MelonLoader](https://github.com/LavaGang/MelonLoader) installed for MDRG.  
   *(Убедитесь, что для MDRG установлен MelonLoader)*
2. Download the latest release archive from the [Releases](https://github.com/Paul-Epifancev/MDRG-Rainbow-Bat-Banner/releases) tab.  
   *(Скачайте архив последнего релиза из вкладки Releases)*
3. Extract the mod files directly into your game's `Mods/` folder.  
   *(Извлеките файлы мода напрямую в папку `Mods/` вашей игры)*
4. Launch the game. The item will be available for **free** in the **Clothier** shop.  
   *(Запустите игру. Предмет будет доступен **бесплатно** в магазине Clothier)*

---

## 🛠️ Extended Modding Toolkit / Расширенный набор инструментов
For more open-source tools, utilities, and mods for MDRG, check out the main toolkit repository:  
*(Для получения дополнительных инструментов, утилит и модов с открытым исходным кодом для MDRG, посетите основной репозиторий)*  
🔗 **[MDRG Modding Toolkit](https://github.com/Paul-Epifancev/MDRG-Modding-Toolkit)**

---

## 💬 Contact & Support / Контакты и поддержка
Have questions or suggestions? Reach out directly:  
*(Есть вопросы или предложения? Свяжитесь напрямую:)*  
🔗 **Discord Server:** [Join here](https://discord.gg/ed4C8ywUn)

---
*Made with ❤️ and 🐑 by **Paul.Epifancev** (`#warlockforbugs`)*
