using UnityEngine;
using UnityEngine.Video;

public class VideoTest : MonoBehaviour
{
    public string filename;
    private VideoPlayer videoPlayer;
    private string message = " ";

    void Start()
    {
        gameObject.AddComponent<VideoPlayer>();
        videoPlayer = GetComponent<VideoPlayer>();

        //Events
        videoPlayer.errorReceived += (source, message) => { message += "{error:" + message + "} "; };
        videoPlayer.prepareCompleted += (source) => { message += "{video is prepared} "; videoPlayer.Play(); };
        videoPlayer.started += (source) => { message += "{video has started} "; };

        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = Application.streamingAssetsPath + "/" + filename;

        message += videoPlayer.url;

        videoPlayer.renderMode = VideoRenderMode.CameraNearPlane;
        videoPlayer.Prepare();
        videoPlayer.Play();  //Also tried to not play here, but only in prepare event
    }

    void Update()
    {
    }

    void OnGUI()
    {
        string fps = "FPS: " + (int)(1f / Time.smoothDeltaTime) + " " + message;

        if (videoPlayer.isPrepared)
            GUI.Label(new Rect(0, 0, Screen.width, 40), fps + "Video info: " + videoPlayer.texture.width + "x" + videoPlayer.texture.height + ", frame: " + (int)(videoPlayer.time * videoPlayer.frameRate));
        else
            GUI.Label(new Rect(0, 0, Screen.width, 40), fps + "Video not prepared");
    }
}
