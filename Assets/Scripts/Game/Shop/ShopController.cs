using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class ShopController<T, U>: Controller<T, U> where T : ShopView where U : ShopModel
{
    public ShopController(T view, U model) : base(view, model){}
    bool canBuy = true;
    protected override void Init()
    {
        base.Init();
        FillAllSlots();
    }

    public void FillAllSlots()
    {
        var firstSlot = _view.grid.transform.GetChild(0);
        var keySlotView = firstSlot.GetComponent<ShopSlotView>();
        FillSlot(keySlotView);
        keySlotView.buyButton.onClick.RemoveAllListeners();
        keySlotView.buyButton.onClick.AddListener(delegate { BuyKey(keySlotView.chest); });
    }

    private void FillSlot(ShopSlotView view)
    {
        view.textPrice.text = view.chest.price.ToString();
        view.preview.sprite = view.chest.chestSprite;
    }

    private void BuyKey(ChestInfo itemInfo)
    {
        _view.buttonSound.Play();
        if(canBuy)
        {
            if (itemInfo.price <= _model.data.Data.Token)
            {
                _model.data.Statistic.KeyCollectedNumber++;
                Debug.Log("Buyed");
                _model.data.DebitingToken(itemInfo.price);
                _model.data.DepositKey(1);
                DestroyEffect();
            }
        }
        
    }

    private async UniTask DestroyEffect()
    {
        canBuy = false;
        while(_view.effect.alpha < 1)
        {
            _view.effect.alpha += 0.05f ;
            await UniTask.Delay(10);
        }
        while (_view.effect.alpha > 0)
        {
            _view.effect.alpha -= 0.05f;
            await UniTask.Delay(10);
        }
        canBuy = true;
    }
}
