using UnityEngine;

public class Soket : MonoBehaviour
{
    private BaseItem _currentItem;
    private Transform _attachPoint;


    public string GetInteractText()
    {
        if (PlayerController.Instance.HaveItem)
        {
            if(_currentItem = null) return "[E] Положить предмет";
            else return "Гнездо занято";
        }

        // if (_currentItem != null || !PlayerController.Instance.HaveItem) return _currentItem();

        else return null;
    }

}
