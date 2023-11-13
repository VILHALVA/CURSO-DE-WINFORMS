# BUTTON
O controle `Button` em Windows Forms é utilizado para criar botões em um formulário. Os botões são frequentemente usados para acionar ações quando clicados pelo usuário. Aqui está um exemplo básico de como usar o `Button`:

```csharp
using System;
using System.Windows.Forms;

namespace MeuProjetoWinForms
{
    public partial class MeuFormulario : Form
    {
        public MeuFormulario()
        {
            InitializeComponent();
            
            // Criando um botão usando o designer
            Button buttonDesigner = new Button();
            buttonDesigner.Text = "Clique-me (designer)";
            buttonDesigner.Location = new System.Drawing.Point(20, 20);
            buttonDesigner.Click += ButtonDesigner_Click; // Associando um manipulador de eventos
            this.Controls.Add(buttonDesigner);

            // Criando um botão no código
            Button meuBotao = new Button();
            meuBotao.Text = "Clique-me (código)";
            meuBotao.Location = new System.Drawing.Point(20, 60);
            meuBotao.Click += MeuBotao_Click; // Associando um manipulador de eventos
            this.Controls.Add(meuBotao);
        }

        private void ButtonDesigner_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Você clicou no botão criado no designer!");
        }

        private void MeuBotao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Você clicou no botão criado no código!");
        }
    }
}
```

Neste exemplo, criamos dois botões, um usando o designer e outro no código. Associamos manipuladores de eventos `Click` a cada botão para lidar com o evento de clique do usuário.

Propriedades importantes do `Button` incluem:

- **Text:** Define ou obtém o texto exibido no botão.
- **Location:** Define a posição do botão no formulário.
- **Click:** Evento acionado quando o botão é clicado.

Personalize o código conforme necessário para atender às necessidades específicas do seu aplicativo.