using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.SDKBase.Editor.Attributes;

namespace sh0uRoom.VRCSIL
{
    [RequireComponent(typeof(ImageLoader))]
    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
    /// <summary>
    /// URLを入力して画像を取得する
    /// </summary>
    public class ImageURLInputter : UdonSharpBehaviour
    {
        [SerializeField] private VRCUrlInputField urlInput;
        [SerializeField] private Text messageTextUI;

        private ImageLoader imageLoader;
        public void SetMessage(string str) => messageTextUI.text = str;

        private void Start() => imageLoader = GetComponent<ImageLoader>();

        public void OnURLChanged()
        {
            var url = urlInput.GetUrl();

            Networking.SetOwner(Networking.LocalPlayer, this.gameObject);

            imageLoader.targetUrl = url;
            urlInput.SetUrl(VRCUrl.Empty);
            imageLoader.LoadImage();
        }
    }
}