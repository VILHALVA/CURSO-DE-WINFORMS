# TOOLTIP
O controle `ToolTip` em Windows Forms é usado para exibir dicas de ferramentas (tooltips) quando o usuário passa o mouse sobre um controle. As dicas de ferramentas são pequenas caixas de texto informativas que fornecem informações adicionais sobre um controle. Aqui está um exemplo básico de como usar o `ToolTip` em um formulário:

```csharp
using System;
using System.Windows.Forms;

namespace MeuProjetoWinForms
{
    public partial class MeuFormulario : Form
    {
        private Button button1;
        private ToolTip toolTip1;

        public MeuFormulario()
        {
            InitializeComponent();

            // Criando um botão
            button1 = new Button();
            button1.Location = new System.Drawing.Point(20, 20);
            button1.Size = new System.Drawing.Size(100, 30);
            button1.Text = "Botão";

            // Criando um ToolTip
            toolTip1 = new ToolTip();
            toolTip1.SetToolTip(button1, "Esta é uma dica de ferramenta para o botão.");

            // Associando um evento ao botão
            button1.Click += Button1_Click;

            // Adicionando o botão ao formulário
            this.Controls.Add(button1);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Botão clicado!");
        }
    }
}
```

Neste exemplo:

- Criamos um botão chamado `button1`.
- Criamos um `ToolTip` chamado `toolTip1`.
- Usamos o método `SetToolTip` para associar uma dica de ferramenta ao botão.
- Associamos um evento de clique ao botão para mostrar que você pode interagir com o botão.
- Adicionamos o botão ao formulário.

Quando o usuário passar o mouse sobre o botão, a dica de ferramenta será exibida, fornecendo informações adicionais. O uso de dicas de ferramentas é uma prática comum para melhorar a usabilidade e fornecer informações contextuais aos usuários. Personalize conforme necessário para atender aos requisitos específicos do seu aplicativo.