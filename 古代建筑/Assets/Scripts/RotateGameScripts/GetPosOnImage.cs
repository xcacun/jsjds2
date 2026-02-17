using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPosOnImage : MonoBehaviour
{
   public Camera UIcamera;
    Vector2 screenPoint;
    Vector2 PosOnImage;
    Vector2 PosOnImageRelative;
   [SerializeField] RawImage image;
   public RectTransform imageRect;
    Vector2 imageRectSize;
    public float rayDistance = 100f;
    void Start()
    {
        imageRect=image.GetComponent<RectTransform>();
        imageRectSize = imageRect.rect.size;
    }

    // Update is called once per frame
    void Update()
    {
        screenPoint=Input.mousePosition;
        bool mouseOnImage = RectTransformUtility.ScreenPointToLocalPointInRectangle
            (imageRect, screenPoint, null, out PosOnImage);
        PosOnImageRelative.x=PosOnImage.x/imageRectSize.x;
        PosOnImageRelative.y=PosOnImage.y/imageRectSize.y;

        if (mouseOnImage)
        {
           
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray=UIcamera.ViewportPointToRay(new Vector3 (PosOnImageRelative.x, PosOnImageRelative.y,0));
            if (Physics.Raycast(ray, out RaycastHit hit, rayDistance))
            {
                Debug.Log($"射线击中：{hit.collider.name}，位置：{hit.point}");
                Debug.DrawLine(ray.origin, hit.point, Color.red, 2f); // 绘制击中射线
                hit.collider.gameObject?.GetComponent<ClickTrigger>().onTriggerClick();
            }
            else
            {
                Debug.DrawLine(ray.origin, ray.origin + ray.direction * rayDistance, Color.green, 2f); // 绘制未击中射线
            }
        }
    }
}
