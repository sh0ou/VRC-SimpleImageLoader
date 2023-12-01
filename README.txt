*==========*==========*
Simple Image Loader v1.0
*==========*==========*
Author: sh0u
Twitter: https://twitter.com/sh0ou

*==========*==========*

【VCC経由でインポートした方へ】
各種ファイルは「Package」フォルダ内にある「SimpleImageLoader」フォルダ内に存在します。
Packageフォルダは「Assets」フォルダと同じ階層にあります。

【使い方】
1. 「SimpleImageLoader」フォルダを開きます
2. Runtimeフォルダ内の「ImageViewer.prefab」をシーン上に配置します
3. （事前に画像を配置したい場合）ImageViewer内の「取得先URL」を設定し、「開始時自動ロード」にチェックを入れます

*==========*==========*

【こんなときは】
Q.
画像を複数のオブジェクトに反映したい
A.
配置するオブジェクトに「Image.mat」マテリアルを適用させて下さい。

Q.
ImageViewerを複数配置したら全部同じ画像になる
A.
新しくMaterialを作成し、作成したマテリアルをImageViewer内「出力先マテリアル」に設定してください。

Q.
イベント用に入力UIを別の場所に配置したい
A.ImageViewerオブジェクトの子にある「Canvas_ImageInput / Input」オブジェクトを配置したい場所に移動してください。

Q.
持ちたい
A.
同梱プレハブ「ImageViewer_Pickup」を使用してください。

Q.
入力UIを取り除きたい
A.
同梱プレハブ「ImageViewer_NoInput」を使用してください。

*==========*==========*