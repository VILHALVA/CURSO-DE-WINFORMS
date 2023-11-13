# PICTUREBOX
O controle `PictureBox` em Windows Forms é usado para exibir imagens em um formulário. Ele fornece uma área na qual você pode exibir uma imagem, seja ela carregada dinamicamente em tempo de execução ou definida no design.

Aqui está um exemplo básico de como usar o `PictureBox` em um formulário Windows Forms:

```csharp
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MeuProjetoWinForms
{
    public partial class MeuFormulario : Form
    {
        private PictureBox pictureBox1;

        public MeuFormulario()
        {
            InitializeComponent();

            // Criando um PictureBox
            pictureBox1 = new PictureBox();
            pictureBox1.Location = new System.Drawing.Point(20, 20);
            pictureBox1.Size = new System.Drawing.Size(200, 150); // Define o tamanho do PictureBox
            this.Controls.Add(pictureBox1);

            // Carregando uma imagem no PictureBox (pode ser uma imagem no seu projeto ou de um arquivo)
            pictureBox1.Image = Image.FromFile("caminho\\para\\sua\\imagem.jpg");

            // Definindo o modo de exibição da imagem (opcional)
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Ajusta a imagem para preencher o PictureBox

            // Associando um manipulador de eventos ao evento Click (opcional)
            pictureBox1.Click += PictureBox1_Click;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Você clicou na imagem!");
        }
    }
}
```

Neste exemplo:

- Criamos um `PictureBox` chamado `pictureBox1`.
- Definimos sua posição, tamanho e carregamos uma imagem usando `pictureBox1.Image = Image.FromFile("caminho\\para\\sua\\imagem.jpg");`.
- Definimos o modo de exibição da imagem usando `pictureBox1.SizeMode`.
- Associamos um manipulador de eventos ao evento `Click` do `PictureBox` para lidar com cliques na imagem.

Principais propriedades do `PictureBox`:

- **Image:** A imagem exibida no controle.
- **SizeMode:** Define como a imagem é exibida dentro do controle (`Normal`, `StretchImage`, `AutoSize`, etc.).
- **Click:** Evento acionado quando o controle é clicado.

Adapte esse código conforme necessário para atender às necessidades específicas do seu aplicativo. Pode ser útil carregar imagens dinamicamente ou manipular eventos relacionados à exibição da imagem.