using UnityEngine;

public class BaseItem : MonoBehaviour, IInteractable
{
    [Header("Links")]
    [SerializeField] private ItemData _data;
    [SerializeField] private Rigidbody _rb;

    public Soket MySoket;


    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        ItemPhysDisable(false);
    }

    public string GetInteractText() => $"[E] Взять {_data.Name}";

    public void Interact()
    {
        if (MySoket != null)
        {
            MySoket.CurretItem = null;
            MySoket = null;
        }
        PlayerController.Instance.PickUpItem(this);
    }

    public void MoveItemToSlot(bool enablePhys)
    {
        ItemPhysDisable(enablePhys);
                transform.SetParent(PlayerController.Instance.PlayerSlot.transform);

        transform.position = PlayerController.Instance.PlayerSlot.transform.position;
        transform.localRotation = Quaternion.identity;

        transform.localScale = Vector3.one * 0.4f;
    }


    private void ItemPhysDisable(bool enable)
    {
        if (_rb) _rb.isKinematic = !enable;
    }

}
