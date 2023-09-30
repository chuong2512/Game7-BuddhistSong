using BabySound.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Buddha.Scripts.UI
{
    public class SettingPopup : AppPopup
    {
        [SerializeField] private Slider slider;
        
        public override ScreenType GetID() => ScreenType.Setting;

        protected override void Start()
        {
            base.Start();
            slider.value = GameDataManager.Instance.playerData.volume;
            slider.onValueChanged.AddListener(AudioManager.Instance.SetVolume);
        }
    }
}