using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(InteractableHoverEvents))]
public class PopulateInteractableHoverEvents : MonoBehaviour
{
    private InteractableHoverEvents hover;

    private void Awake()
    {
        this.hover = GetComponent<InteractableHoverEvents>();
    }

    public void Populate()
    {
        this.hover.onHandHoverBegin.AddListener(OnHoverBegin);
        this.hover.onHandHoverEnd.AddListener(OnHoverEnd);
    }

    private void OnHoverBegin()
    {
        ArrowHand arrowHand = FindObjectOfType<ArrowHand>() as ArrowHand;
        arrowHand?.SetHandInBack(true);
    }

    private void OnHoverEnd()
    {
        ArrowHand arrowHand = FindObjectOfType<ArrowHand>() as ArrowHand;
        arrowHand?.SetHandInBack(false);
    }
}
