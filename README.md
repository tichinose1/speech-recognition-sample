# 目的
- Kinectからの音声を認識したい
- 入力は既定の音声入力デバイスを指定するため、Kinectが無くてもマイクがあれば動く
- Kinectでやる場合はKinectを既定のデバイスに指定する

# 参考
- [音声認識 - .NET デスクトップ アプリと音声認識](https://msdn.microsoft.com/ja-jp/magazine/dn857362.aspx)

> ## Microsoft.Speech と System.Speech の違い
> 結論として、音声の使用経験が少ない方が .NET アプリに音声を追加する場合は、System.Speech ライブラリではなく Microsoft.Speech ライブラリを使用することをお勧めします。

> |Microsoft.Speech.dll	|System.Speech.dll|
> | - | - |
> |別途インストールが必要	|OS 組み込み (Windows Vista 以上)|
> |アプリと共にパッケージ化可能	|再頒布不可|
> |Grammar の作成が必要	|Grammar または自由発話のディクテーションを使用|
> |ユーザーのトレーニングが不要	|特定のユーザー向けに対してトレーニングが必要|
> |マネージ コード API (C#)	|ネイティブ コード API (C++)|

> System.Speech による音声認識は、通常ユーザーのトレーニングが必要です。

> System.Speech はほとんどすべての語を認識できます (自由発話のディクテーション) が、Microsoft.Speech はプログラムで定義した Grammar に当てはまる語やフレーズのみを認識します。