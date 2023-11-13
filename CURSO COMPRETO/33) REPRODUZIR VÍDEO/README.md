# REPRODUZIR VÍDEO
Para reproduzir vídeos em um aplicativo Windows Forms, você pode usar o controle `Windows Media Player`. Certifique-se de que você tenha a biblioteca `AxWMPLib` adicionada ao seu projeto. Aqui está um exemplo básico de como reproduzir um vídeo quando o formulário é carregado:

```csharp
using System;
using System.Windows.Forms;
using AxWMPLib;

namespace MeuProjetoWinForms
{
    public partial class MeuFormulario : Form
    {
        private AxWindowsMediaPlayer axWindowsMediaPlayer1;

        public MeuFormulario()
        {
            InitializeComponent();

            // Inicializando o controle AxWindowsMediaPlayer
            axWindowsMediaPlayer1 = new AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(axWindowsMediaPlayer1)).BeginInit();
            axWindowsMediaPlayer1.Enabled = true;
            axWindowsMediaPlayer1.Location = new System.Drawing.Point(20, 20);
            axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            axWindowsMediaPlayer1.OcxState = null;
            axWindowsMediaPlayer1.Size = new System.Drawing.Size(400, 300);
            this.Controls.Add(axWindowsMediaPlayer1);
            ((System.ComponentModel.ISupportInitialize)(axWindowsMediaPlayer1)).EndInit();

            // Associando o evento de carregamento do formulário ao método de reprodução do vídeo
            this.Load += MeuFormulario_Load;
        }

        private void MeuFormulario_Load(object sender, EventArgs e)
        {
            // Configurando o URL do vídeo a ser reproduzido
            axWindowsMediaPlayer1.URL = "Caminho\\Para\\Seu\\Arquivo\\video.mp4";

            // Iniciando a reprodução do vídeo
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
    }
}
```

Neste exemplo:

- Inicializamos um controle `AxWindowsMediaPlayer` no formulário.
- No evento `Load` do formulário, configuramos o URL do vídeo e iniciamos a reprodução usando `axWindowsMediaPlayer1.Ctlcontrols.play()`.

Certifique-se de substituir "Caminho\\Para\\Seu\\Arquivo\\video.mp4" pelo caminho real do seu arquivo de vídeo. Essa abordagem utiliza a biblioteca nativa do Windows Media Player para reproduzir vídeos.

Se você precisar de funcionalidades mais avançadas ou maior controle sobre a reprodução de vídeo, considere o uso de bibliotecas de terceiros, como a `LibVLCSharp`, que é uma wrapper para a biblioteca LibVLC.