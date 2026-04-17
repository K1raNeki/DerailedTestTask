using UnityEngine;

public class BaseItem : MonoBehaviour, IInteractable
{
    [Header("Links")]
    [SerializeField] private ItemData _data;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Collider _coll;


    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _coll = GetComponent<Collider>();
        ItemPhysDisable(false);
    }

    public string GetInteractText() => $"[E] Взять {_data.Name}";

    public void Interact() => PlayerController.Instance.PickUpItem(this);

    public void MoveItemToSlot(bool enablePhys)
    {
        ItemPhysDisable(enablePhys);
        transform.position = PlayerController.Instance.PlayerSlot.transform.position;
        transform.SetParent(PlayerController.Instance.PlayerSlot.transform);

        transform.localScale *= 0.2f;
    }


    private void ItemPhysDisable(bool enable)
    {
        if (_rb) _rb.isKinematic = !enable;
    }

}
