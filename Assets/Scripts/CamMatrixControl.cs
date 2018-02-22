using UnityEngine;
using System.Collections;

public class CamMatrixControl : MonoBehaviour
{
    public float rotate_angle = 0;
    public float scale = 1;
    public Vector2 shearing = Vector2.zero;
    public Vector2 translation = Vector2.zero;

    private Matrix4x4 MatRotate = Matrix4x4.identity;
    private Matrix4x4 MatScale = Matrix4x4.identity;
    private Matrix4x4 MatXShearing = Matrix4x4.identity;
    private Matrix4x4 MatYShearing = Matrix4x4.identity;
    private Matrix4x4 MatTranslation = Matrix4x4.identity;

    private Matrix4x4 OriMatProjection;
    private Camera cam;
    public GameObject player;
    public GameObject plane;

    // Use this for initialization
    void Start()
    {
        cam = this.GetComponent<Camera>();
        OriMatProjection = cam.projectionMatrix;
    }

    // Update is called once per frame
    void Update()
    {
        //get player angle to plan
        float angle = 0;
        angle = Mathf.Atan((plane.transform.position.x - player.transform.position.x) / (plane.transform.position.y - player.transform.position.y));
        //translation.x = -angle;

        MatScale[0, 0] = scale;
        MatScale[1, 1] = scale;

        MatRotate[0, 0] = Mathf.Cos(rotate_angle * Mathf.Deg2Rad);
        MatRotate[0, 1] = -Mathf.Sin(rotate_angle * Mathf.Deg2Rad);
        MatRotate[1, 0] = Mathf.Sin(rotate_angle * Mathf.Deg2Rad);
        MatRotate[1, 1] = Mathf.Cos(rotate_angle * Mathf.Deg2Rad);

        MatXShearing[0, 1] = shearing.x;
        MatYShearing[1, 0] = shearing.y;

        MatTranslation[0, 2] = translation.x;
        MatTranslation[1, 2] = translation.y;

        cam.projectionMatrix = OriMatProjection *
                                MatScale *
                                MatRotate *
                                MatXShearing *
                                MatYShearing *
                                MatTranslation;
    }
}