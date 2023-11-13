# CURSOR
O cursor em Windows Forms é um indicador gráfico que representa a posição do mouse na tela. O controle `Cursor` permite que você manipule o cursor durante a execução do aplicativo, alterando sua forma e comportamento em resposta a eventos ou ações específicas.

Aqui estão alguns exemplos de como usar o `Cursor` em um formulário Windows Forms:

### Mudando o Cursor:

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

            // Mudando o cursor para a mão ao passar sobre um botão
            Button button1 = new Button();
            button1.Text = "Clique-me!";
            button1.Location = new System.Drawing.Point(20, 20);
            button1.MouseEnter += (sender, e) => { Cursor = Cursors.Hand; };
            button1.MouseLeave += (sender, e) => { Cursor = Cursors.Default; };
            this.Controls.Add(button1);
        }
    }
}
```

Neste exemplo, quando o mouse entra no botão, o cursor é alterado para a forma de uma mão (`Cursors.Hand`). Quando o mouse sai do botão, o cursor é restaurado para a forma padrão (`Cursors.Default`).

### Obtendo a Posição do Cursor:

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

            // Exibindo a posição do cursor ao clicar no formulário
            this.MouseClick += (sender, e) =>
            {
                MessageBox.Show($"Posição do Cursor: X = {e.X}, Y = {e.Y}");
            };
        }
    }
}
```

Neste exemplo, ao clicar no formulário, uma caixa de mensagem exibe a posição do cursor em relação ao formulário.

Principais propriedades e métodos relacionados ao `Cursor`:

- **Current:** Obtém ou define o cursor atual.
- **Position:** Obtém ou define a posição do cursor na tela.
- **Clip:** Obtém ou define a área retangular na qual o cursor é restrito.
- **Hide():** Oculta o cursor.
- **Show():** Exibe o cursor.

Esses são apenas exemplos básicos; o controle `Cursor` oferece uma variedade de opções para personalizar a aparência e o comportamento do cursor em seu aplicativo Windows Forms. Adapte o código conforme necessário para atender às necessidades específicas do seu projeto.