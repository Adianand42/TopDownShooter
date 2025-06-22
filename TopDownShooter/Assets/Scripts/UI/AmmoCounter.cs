using TMPro;
using UnityEngine;
using UniRx;
using TopDown.Shooting;
using DG.Tweening;

namespace Topdown.UnityEngine
{
    public class AmmoCounter : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI ammoCounterText;
        [SerializeField] private GunController gunController;
        private int ammoInClip;
        private int totalAmmo;

        [Header("Popup Effect")]
        [SerializeField] private Vector2 popupIntensity;
        [SerializeField] private float popupDuration;

        private CompositeDisposable subscriptions = new CompositeDisposable();
        private void OnEnable()
        {
            gunController.CurrentAmmoInClip.ObserveEveryValueChanged(property => property.Value).Subscribe(value =>
            {
                ammoInClip = value;
                UpdateAmmoCounter(ammoInClip, totalAmmo);
            }).AddTo(subscriptions);
            gunController.TotalAmmo.ObserveEveryValueChanged(property => property.Value).Subscribe(value =>
            {
                totalAmmo = value;
                UpdateAmmoCounter(ammoInClip, totalAmmo);
            }).AddTo(subscriptions);
        }
        private void OnDisable()
        {
            subscriptions.Clear();
        }

        private void UpdateAmmoCounter(int currentAmmo, int clipSize)
        {
            ammoCounterText.text = $"{currentAmmo}/{clipSize}";
            transform.DOPunchScale(popupIntensity, popupDuration)
                     .OnComplete(()=>transform.DORewind());
        }
    }

}
