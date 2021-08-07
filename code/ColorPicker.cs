using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ColorPicker : MonoBehaviour
{
    public Camera camera;       //보여지는 카메라.

    public RawImage FrameScreen;
    public RawImage FramePicker;

    private int resWidth;
    private int resHeight;
    // Use this for initialization
    void Start()
    {
        resWidth = Screen.width;     //스크린의 가로를 불러와 대입
        resHeight = Screen.height;   //스크린의 세로를 불러와 대입
        camera = Camera.main;
        StartCoroutine(coPicker());
    }

    IEnumerator coPicker()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            // 1. 화면 스크린샷
            RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
            camera.targetTexture = rt;

            Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
            Rect rec = new Rect(0, 0, screenShot.width, screenShot.height);
            camera.Render();

            RenderTexture.active = rt;
            screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);

            screenShot.Apply();

            FrameScreen.texture = screenShot;

            camera.targetTexture = null;

            // 2. 스크린샷의 중앙 픽셀값을 가져와 새로운 텍스쳐에 그려서 출력
            // 수정: 카메라 화면의 카로세로 20의 모든 컬러를 복사해서 가져오니깐
            //       컬러의 갯수가5만개 정도되어서,
            //       중앙 포인트1개만 가져와서 색을 표현하는 방식으로 바꿈
            // pix.r , pix.g , pix.b , pix.a 이런식으로 가져오면 되고
            // 0~255가 아닌, 0~1 사이의 값형태로 가지고옵니다.
            // 0~255값 사용하시려면 각 값에 255곱해서 쓰시면 됩니다.


            int w = screenShot.width;
            int h = screenShot.height;
            //print(w + " , " + h);
            //Color[] pix = screenShot.GetPixels(w/2-5,h/2-5,w/2+5,h/2+5);
            Color pix = screenShot.GetPixel(w / 2, h / 2);
            Debug.Log(pix.r * 255 + " , " + pix.g * 255 + " , " + pix.b * 255 + " , " + pix.a * 255); //★★★
            Texture2D destTex = new Texture2D(1, 1);
            destTex.SetPixel(0, 0, pix);

            //for (int i = 0; i < 10; i++)
            //{
            //    for (int j = 0; j < 10; j++)
            //    {
            //        destTex.SetPixel(i, j, pix);
            //    }
            //}
            //destTex.SetPixels(pix);
            destTex.Apply();

            FramePicker.texture = destTex;
        }
    }


    // Update is called once per frame
    void Update()
    {
        //// 1. 화면 스크린샷
        //RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        //camera.targetTexture = rt;

        //Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        //Rect rec = new Rect(0, 0, screenShot.width, screenShot.height);
        //camera.Render();

        //RenderTexture.active = rt;
        //screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);

        //screenShot.Apply();

        //FrameScreen.texture = screenShot;

        //camera.targetTexture = null;

        //// 2. 스크린샷의 중앙 픽셀값을 가져와 새로운 텍스쳐에 그려서 출력
        //// 수정: 카메라 화면의 카로세로 20의 모든 컬러를 복사해서 가져오니깐
        ////       컬러의 갯수가5만개 정도되어서,
        ////       중앙 포인트1개만 가져와서 색을 표현하는 방식으로 바꿈
        //// pix.r , pix.g , pix.b , pix.a 이런식으로 가져오면 되고
        //// 0~255가 아닌, 0~1 사이의 값형태로 가지고옵니다.
        //// 0~255값 사용하시려면 각 값에 255곱해서 쓰시면 됩니다.


        //int w = screenShot.width;
        //int h = screenShot.height;
        ////print(w + " , " + h);
        ////Color[] pix = screenShot.GetPixels(w/2-5,h/2-5,w/2+5,h/2+5);
        //Color pix = screenShot.GetPixel(w / 2, h / 2);
        //Debug.Log(pix.r*255+ " , " + pix.g * 255 + " , " + pix.b * 255 + " , " + pix.a * 255); //★★★
        //Texture2D destTex = new Texture2D(10, 10);
        //for(int i = 0; i < 10; i++)
        //{
        //    for(int j = 0; j < 10; j++)
        //    {
        //        destTex.SetPixel(i, j, pix);
        //    }
        //}
        ////destTex.SetPixels(pix);
        //destTex.Apply();

        //FramePicker.texture = destTex;
    }
}
