using UdonSharp;
using UnityEngine;
using VRC.SDK3.Image;
using VRC.SDKBase;
using VRC.Udon.Common.Interfaces;

namespace sh0uRoom.VRCSIL
{
    [HelpURL("https://creators.vrchat.com/worlds/udon/image-loading/")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
    /// <summary>
    /// URLを指定して画像を取得する
    /// </summary>
    public class ImageLoader : UdonSharpBehaviour
    {
        [SerializeField, UdonSynced(UdonSyncMode.None)] public VRCUrl targetUrl;
        [SerializeField] private Material material;
        [SerializeField] private bool isLoadOnStart = true;
        [SerializeField] private ImageURLInputter inputter;

        private VRCImageDownloader imageDownloader;
        private IVRCImageDownload downloadTask;
        private IUdonEventReceiver udon;
        private bool isStart = false;

        private void Start()
        {
            imageDownloader = new VRCImageDownloader();
            udon = (IUdonEventReceiver)this;

            isStart = true;
            if (isLoadOnStart) LoadImage();
        }

        private void Update()
        {
            // ダウンロードの進捗を表示
            if (downloadTask != null)
            {
                UpdateMessage($"取得中...:{downloadTask.State}({(downloadTask.Progress * 100).ToString("F2")}%)", true);
            }
        }

        private void OnDestroy() => imageDownloader.Dispose();

        /// <summary> 画像を取得する </summary>
        public void LoadImage()
        {
            RequestSerialization();
            var url = targetUrl.Get();
            // URLの長さチェック
            if (url.Length < 11)
            {
                UpdateMessage("URLが短すぎます");
                return;
            }
            // httpsから始まるか
            else if (url.Substring(0, 8) != "https://")
            {
                UpdateMessage("URLがhttpsから始まっていません");
                return;
            }
            else
            {
                if (!isStart) Start();
                // 画像を取得
                downloadTask = imageDownloader.DownloadImage(targetUrl, material, udon);
            }
        }

        /// <summary> メッセージを更新する </summary>
        /// <param name="str">メッセージの内容</param>
        private void UpdateMessage(string str, bool isUpdate = false)
        {
            if (inputter != null)
            {
                inputter.SetMessage(str);
            }
            else if (!isUpdate)
            {
                Debug.Log($"[<color=yellow>{nameof(ImageLoader)}</color>]{str}");
            }
        }

        #region VRCMethods

        public override void OnDeserialization()
        {
            LoadImage();

        }

        public override void OnImageLoadSuccess(IVRCImageDownload result)
        {
            if (downloadTask == null) return;

            downloadTask = null;
            material.mainTexture = result.Result;
            UpdateMessage($"画像の取得に成功しました! ({material.mainTexture.width} x {material.mainTexture.height})");
        }

        public override void OnImageLoadError(IVRCImageDownload result)
        {
            if (downloadTask == null) return;

            downloadTask = null;
            material.mainTexture = null;
            UpdateMessage($"画像の取得に失敗しました: {result.Error}");
        }

        #endregion
    }
}