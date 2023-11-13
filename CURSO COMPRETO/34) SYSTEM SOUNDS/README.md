# SYSTEM SOUNDS
Para reproduzir os sons do sistema no Windows Forms, você pode usar a classe `SystemSounds`. Essa classe fornece acesso aos sons do sistema, como o som de erro, alerta, informações e outros. Aqui está um exemplo simples:

```csharp
using System;
using System.Media;
using System.Windows.Forms;

namespace MeuProjetoWinForms
{
    public partial class MeuFormulario : Form
    {
        private Button btnPlaySystemSound;

        public MeuFormulario()
        {
            InitializeComponent();

            // Criando um botão para reproduzir o som do sistema
            btnPlaySystemSound = new Button();
            btnPlaySystemSound.Location = new System.Drawing.Point(20, 20);
            btnPlaySystemSound.Size = new System.Drawing.Size(150, 30);
            btnPlaySystemSound.Text = "Reproduzir Som do Sistema";
            btnPlaySystemSound.Click += BtnPlaySystemSound_Click;
            this.Controls.Add(btnPlaySystemSound);
        }

        private void BtnPlaySystemSound_Click(object sender, EventArgs e)
        {
            // Reproduzindo o som do sistema padrão (exemplo: som de alerta)
            SystemSounds.Asterisk.Play();
        }
    }
}
```

Neste exemplo:

- Criamos um botão chamado `btnPlaySystemSound`.
- Associamos um manipulador de eventos ao evento `Click` do botão para reproduzir o som do sistema.
- Utilizamos `SystemSounds.Asterisk.Play()` para reproduzir o som de alerta do sistema. Você pode substituir `Asterisk` por outros sons disponíveis, como `Beep`, `Exclamation` e `Hand`.

Essa abordagem é útil quando você deseja incorporar sons padrão do sistema em sua aplicação. Lembre-se de que os sons específicos podem variar dependendo das configurações do sistema e da versão do Windows em execução.