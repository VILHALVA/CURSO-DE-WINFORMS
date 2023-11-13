# TOOLSTRIP
O controle `ToolStrip` em Windows Forms é uma barra de ferramentas que geralmente contém botões, dropdowns, caixas de texto e outros controles para fornecer acesso rápido às funcionalidades do aplicativo. Aqui está um exemplo básico de como usar o `ToolStrip` em um formulário:

```csharp
using System;
using System.Windows.Forms;

namespace MeuProjetoWinForms
{
    public partial class MeuFormulario : Form
    {
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem menuItem1;
        private ToolStripMenuItem menuItem2;

        public MeuFormulario()
        {
            InitializeComponent();

            // Criando um ToolStrip
            toolStrip1 = new ToolStrip();
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Size = new System.Drawing.Size(400, 30);

            // Criando ToolStripButtons
            toolStripButton1 = new ToolStripButton();
            toolStripButton1.Text = "Botão 1";
            toolStripButton1.Click += ToolStripButton1_Click;

            toolStripButton2 = new ToolStripButton();
            toolStripButton2.Text = "Botão 2";
            toolStripButton2.Click += ToolStripButton2_Click;

            // Criando um ToolStripSeparator
            toolStripSeparator1 = new ToolStripSeparator();

            // Criando um ToolStripDropDownButton com itens de menu
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            toolStripDropDownButton1.Text = "Menu Dropdown";

            menuItem1 = new ToolStripMenuItem();
            menuItem1.Text = "Item 1";
            menuItem1.Click += MenuItem1_Click;

            menuItem2 = new ToolStripMenuItem();
            menuItem2.Text = "Item 2";
            menuItem2.Click += MenuItem2_Click;

            toolStripDropDownButton1.DropDownItems.Add(menuItem1);
            toolStripDropDownButton1.DropDownItems.Add(menuItem2);

            // Adicionando os controles ao ToolStrip
            toolStrip1.Items.Add(toolStripButton1);
            toolStrip1.Items.Add(toolStripButton2);
            toolStrip1.Items.Add(toolStripSeparator1);
            toolStrip1.Items.Add(toolStripDropDownButton1);

            // Adicionando o ToolStrip ao formulário
            this.Controls.Add(toolStrip1);
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Botão 1 clicado!");
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Botão 2 clicado!");
        }

        private void MenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Item 1 do menu clicado!");
        }

        private void MenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Item 2 do menu clicado!");
        }
    }
}
```

Neste exemplo:

- Criamos um `ToolStrip` chamado `toolStrip1`.
- Adicionamos `ToolStripButtons`, `ToolStripSeparator` e um `ToolStripDropDownButton` ao `ToolStrip`.
- Associamos manipuladores de eventos aos cliques desses controles.
- Adicionamos o `ToolStrip` ao formulário.

Este é um exemplo básico e pode ser expandido conforme necessário, dependendo dos requisitos específicos do seu aplicativo. O controle `ToolStrip` é frequentemente utilizado para fornecer uma interface de usuário consistente e de fácil acesso para funcionalidades do aplicativo.