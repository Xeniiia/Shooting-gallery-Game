using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class BonusSystemUI : MonoBehaviour
    {
        [SerializeField] private float maxBonus = 5;
        [SerializeField] private Image bonusFill;
        private IBonusController controller;


        private void Start()
        {
            controller = Controllers.Controller.Instance;
            controller.SetBonusChangeHandler(BonusChange);
        }

        private void BonusChange(int bonus)
        {
            AddBonusPart(ToProcent(bonus));
        }

        private float ToProcent(int bonus)
        {
            float oneProcent = maxBonus / 100f;
            float procent = bonus / oneProcent;
            return procent / 100;
        }

        private void AddBonusPart(float bonus)
        {
            StartCoroutine(FillAmountBonus(bonus));
        }

        private IEnumerator FillAmountBonus(float bonus)
        {
            float delta = bonus - bonusFill.fillAmount;
            while (delta < -0.05 || delta > 0.05)
            {
                float speed = Time.deltaTime;
                bonusFill.fillAmount += speed * (delta > 0 ? 1 : -1);       //TODO: сделать плавно красиво
                delta = bonus - bonusFill.fillAmount;
                yield return new WaitForEndOfFrame();
            }

            yield break;
        }

    }
}