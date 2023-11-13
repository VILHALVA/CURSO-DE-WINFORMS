# STATUSSTRIP
O controle `StatusStrip` em Windows Forms é usado para exibir informações de status na parte inferior de um formulário. Ele geralmente contém controles como `ToolStripStatusLabel` para exibir texto, ícones ou outros elementos informativos. Aqui está um exemplo básico de como usar o `StatusStrip` em um formulário:

```csharp
using System;
using System.Windows.Forms;

namespace MeuProjetoWinForms
{
    public partial class MeuFormulario : Form
    {
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;

        public MeuFormulario()
        {
            InitializeComponent();

            // Criando um StatusStrip
            statusStrip1 = new StatusStrip();
            statusStrip1.Dock = DockStyle.Bottom;

            // Criando um ToolStripStatusLabel
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel1.Text = "Status: Pronto";

            // Adicionando o ToolStripStatusLabel ao StatusStrip
            statusStrip1.Items.Add(toolStripStatusLabel1);

            // Adicionando o StatusStrip ao formulário
            this.Controls.Add(statusStrip1);
        }
    }
}
```

Neste exemplo:

- Criamos um `StatusStrip` chamado `statusStrip1`.
- Criamos um `ToolStripStatusLabel` chamado `toolStripStatusLabel1` e definimos seu texto inicial como "Status: Pronto".
- Adicionamos o `ToolStripStatusLabel` ao `StatusStrip`.
- Adicionamos o `StatusStrip` ao formulário.

Este é um exemplo básico e você pode adicionar mais `ToolStripStatusLabel` ou outros controles ao `StatusStrip` conforme necessário. Os controles no `StatusStrip` são frequentemente usados para exibir informações de status, como mensagens, ícones indicativos ou até mesmo barras de progresso, dependendo dos requisitos do seu aplicativo.