using UnityEngine;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] private Image _point;

    private RaycastHit _hit;

    //in a config
    private float _alphaStrange = 0.5f;
    private Color _unselectColor;
    private Color _selectColor;
    private float _rayDistance = 4;


    void Awake()
    {
        _unselectColor.a = _alphaStrange;
        _selectColor.a = 1;
        _point.color = _unselectColor;

    }

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out _hit, _rayDistance))
        {
            IInteractable interactable = _hit.collider.GetComponentInParent<IInteractable>();

            if (interactable != null)
            {
                _point.color = _selectColor;

                if (PlayerController.Instance.IsInteractPressed() && !PlayerController.Instance.HaveItem)
                {
                    interactable.Interact();
                }

                Debug.DrawRay(transform.position, transform.forward * _rayDistance, Color.green);
            }
        }
        else
        {
            _point.color = _unselectColor;

            Debug.DrawRay(transform.position, transform.forward * _rayDistance, Color.red);
        }

    }

}
