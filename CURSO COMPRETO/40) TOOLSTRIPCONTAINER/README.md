# TOOLSTRIPCONTAINER
O controle `ToolStripContainer` em Windows Forms é usado para gerenciar automaticamente o layout de barras de ferramentas (`ToolStrip`) em relação ao conteúdo principal do formulário. Ele é útil quando você deseja ter barras de ferramentas que podem ser ancoradas na parte superior, inferior, esquerda ou direita do formulário. Aqui está um exemplo básico de como usar `ToolStripContainer` em um formulário:

```csharp
using System;
using System.Windows.Forms;

namespace MeuProjetoWinForms
{
    public partial class MeuFormulario : Form
    {
        private ToolStripContainer toolStripContainer1;
        private ToolStrip toolStrip1;
        private ToolStrip toolStrip2;
        private RichTextBox richTextBox1;

        public MeuFormulario()
        {
            InitializeComponent();

            // Criando um ToolStripContainer
            toolStripContainer1 = new ToolStripContainer();
            toolStripContainer1.Dock = DockStyle.Fill;
            
            // Criando uma ToolStrip no topo
            toolStrip1 = new ToolStrip();
            toolStrip1.Items.Add("Botão 1");
            toolStrip1.Items.Add("Botão 2");

            // Criando uma ToolStrip à esquerda
            toolStrip2 = new ToolStrip();
            toolStrip2.Items.Add("Botão 3");
            toolStrip2.Items.Add("Botão 4");

            // Adicionando as ToolStrips ao ToolStripContainer
            toolStripContainer1.TopToolStripPanel.Controls.Add(toolStrip1);
            toolStripContainer1.LeftToolStripPanel.Controls.Add(toolStrip2);

            // Criando uma RichTextBox como conteúdo principal
            richTextBox1 = new RichTextBox();
            richTextBox1.Dock = DockStyle.Fill;

            // Adicionando a RichTextBox ao conteúdo principal do ToolStripContainer
            toolStripContainer1.ContentPanel.Controls.Add(richTextBox1);

            // Adicionando o ToolStripContainer ao formulário
            this.Controls.Add(toolStripContainer1);
        }
    }
}
```

Neste exemplo:

- Criamos um `ToolStripContainer` chamado `toolStripContainer1`.
- Criamos duas barras de ferramentas (`ToolStrip`) chamadas `toolStrip1` e `toolStrip2`.
- Adicionamos alguns botões às barras de ferramentas.
- Adicionamos as barras de ferramentas ao `ToolStripContainer` nas posições desejadas (topo e esquerda).
- Criamos uma `RichTextBox` chamada `richTextBox1` como o conteúdo principal do `ToolStripContainer`.
- Adicionamos a `RichTextBox` ao conteúdo principal do `ToolStripContainer`.
- Adicionamos o `ToolStripContainer` ao formulário.

O `ToolStripContainer` oferece flexibilidade na organização de barras de ferramentas em relação ao conteúdo principal do formulário. O exemplo acima é bastante simples, e você pode personalizar conforme necessário para atender aos requisitos específicos do seu aplicativo.