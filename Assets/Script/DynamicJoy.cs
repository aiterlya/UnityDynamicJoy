using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class DynamicJoy : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{

    private RectTransform BG;//摇杆的背景图片
    private RectTransform Handle;//摇杆的中心杆

    private Vector2 BGPos;//背景图片位置
    private Vector2 HandldPos;//摇杆位置

    private Vector2 Dirction; //摇杆的方向
    private float radius;
    public void OnDrag(PointerEventData eventData)
    {


        HandldPos = eventData.position;
        Vector2 Dirct = HandldPos - BGPos;

        if (Dirct.magnitude > radius)
        {
            Handle.localPosition = Dirct.normalized * radius;
        }
        else
        {
            Handle.position = eventData.position;
        }

        Dirction = Dirct / radius;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        BgHide(false);
        BGPos = eventData.position;
        BG.position = BGPos;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        BgHide(true);
        Dirction = Vector2.zero;
        Handle.position = BGPos;

    }
    /// <summary>
    /// 返回方向位置
    /// </summary>
    /// <returns></returns>
    public Vector2 GetAxis()
    {

        return Dirction.magnitude < 1 ? Dirction : Dirction.normalized;
    }

    void Start()
    {
        BG = transform.Find("BG").GetComponent<RectTransform>();
        Handle = transform.Find("BG/Handle").GetComponent<RectTransform>();
        radius = BG.sizeDelta.x * 0.5f;
    }

    public void BgHide(bool _hide)
    {
        int hide = _hide ? 0 : 1;
        BG.GetComponent<CanvasGroup>().DOFade(hide, 0.3f);

    }
    // Update is called once per frame
    void Update()
    {

    }
}
