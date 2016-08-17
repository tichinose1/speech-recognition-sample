# 概要
- 人の声などを音声認識して、認識結果を画面に表示する
- 入力は既定の音声入力デバイスから取得する
- Kinectを音声入力デバイスとして使用する場合はPCの設定でKinectを既定に指定する
- 音声認識のみで、音声合成は無し
- 音声認識は日本語のみ

# 環境
- Visual Studio 2013
- .NET Framework 4.5
- C# 5.0
- Microsoft Speech Platform SDK (x86) v.11.0
- Microsoft Server Speech Platform Runtime (x86)
- Microsoft Server Speech Recognition Engine - TELE (ja-JP)

# SpeechRecognitionConsole
- コンソールアプリケーション
- System.SpeechではなくMicrosoft.Speechを使用する
- 他言語で利用する場合はMSのサイトから認識言語をインストールする

# 参考
- [音声認識 - .NET デスクトップ アプリと音声認識](https://msdn.microsoft.com/ja-jp/magazine/dn857362.aspx)

> ## Microsoft.Speech と System.Speech の違い
> - 結論として、音声の使用経験が少ない方が .NET アプリに音声を追加する場合は、System.Speech ライブラリではなく Microsoft.Speech ライブラリを使用することをお勧めします。
> 
> - System.Speech による音声認識は、通常ユーザーのトレーニングが必要です。
> 
> - System.Speech はほとんどすべての語を認識できます (自由発話のディクテーション) が、Microsoft.Speech はプログラムで定義した Grammar に当てはまる語やフレーズのみを認識します。
>
> |Microsoft.Speech.dll	|System.Speech.dll|
> | - | - |
> |別途インストールが必要	|OS 組み込み (Windows Vista 以上)|
> |アプリと共にパッケージ化可能	|再頒布不可|
> |Grammar の作成が必要	|Grammar または自由発話のディクテーションを使用|
> |ユーザーのトレーニングが不要	|特定のユーザー向けに対してトレーニングが必要|
> |マネージ コード API (C#)	|ネイティブ コード API (C++)|

# TODO
- [ ] 認識したい単語を外出しする