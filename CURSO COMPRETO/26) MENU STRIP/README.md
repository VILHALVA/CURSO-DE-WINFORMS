# MENU STRIP
O `MenuStrip` em Windows Forms é um controle que fornece uma barra de menu para aplicativos. Ele permite criar menus hierárquicos com itens de menu, submenus e atalhos de teclado. Aqui está um exemplo básico de como usar o `MenuStrip`:

```csharp
using System;
using System.Windows.Forms;

namespace MeuProjetoWinForms
{
    public partial class MeuFormulario : Form
    {
        private MenuStrip menuStrip1;
        private ToolStripMenuItem arquivoToolStripMenuItem;
        private ToolStripMenuItem novoToolStripMenuItem;
        private ToolStripMenuItem abrirToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem salvarToolStripMenuItem;
        private ToolStripMenuItem salvarComoToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem sairToolStripMenuItem;
        private ToolStripMenuItem editarToolStripMenuItem;
        private ToolStripMenuItem desfazerToolStripMenuItem;
        private ToolStripMenuItem refazerToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem recortarToolStripMenuItem;
        private ToolStripMenuItem copiarToolStripMenuItem;
        private ToolStripMenuItem colarToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem selecionarTudoToolStripMenuItem;

        public MeuFormulario()
        {
            InitializeComponent();

            // Criando um MenuStrip
            menuStrip1 = new MenuStrip();
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.Controls.Add(menuStrip1);

            // Criando itens de menu
            arquivoToolStripMenuItem = new ToolStripMenuItem("Arquivo");
            novoToolStripMenuItem = new ToolStripMenuItem("Novo");
            abrirToolStripMenuItem = new ToolStripMenuItem("Abrir");
            toolStripSeparator1 = new ToolStripSeparator();
            salvarToolStripMenuItem = new ToolStripMenuItem("Salvar");
            salvarComoToolStripMenuItem = new ToolStripMenuItem("Salvar Como");
            toolStripSeparator2 = new ToolStripSeparator();
            sairToolStripMenuItem = new ToolStripMenuItem("Sair");

            editarToolStripMenuItem = new ToolStripMenuItem("Editar");
            desfazerToolStripMenuItem = new ToolStripMenuItem("Desfazer");
            refazerToolStripMenuItem = new ToolStripMenuItem("Refazer");
            toolStripSeparator3 = new ToolStripSeparator();
            recortarToolStripMenuItem = new ToolStripMenuItem("Recortar");
            copiarToolStripMenuItem = new ToolStripMenuItem("Copiar");
            colarToolStripMenuItem = new ToolStripMenuItem("Colar");
            toolStripSeparator4 = new ToolStripSeparator();
            selecionarTudoToolStripMenuItem = new ToolStripMenuItem("Selecionar Tudo");

            // Adicionando itens ao MenuStrip
            arquivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                novoToolStripMenuItem, abrirToolStripMenuItem, toolStripSeparator1,
                salvarToolStripMenuItem, salvarComoToolStripMenuItem, toolStripSeparator2,
                sairToolStripMenuItem
            });

            editarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                desfazerToolStripMenuItem, refazerToolStripMenuItem, toolStripSeparator3,
                recortarToolStripMenuItem, copiarToolStripMenuItem, colarToolStripMenuItem, toolStripSeparator4,
                selecionarTudoToolStripMenuItem
            });

            menuStrip1.Items.AddRange(new ToolStripItem[] {
                arquivoToolStripMenuItem, editarToolStripMenuItem
            });

            // Associando manipuladores de eventos aos itens de menu
            novoToolStripMenuItem.Click += NovoToolStripMenuItem_Click;
            abrirToolStripMenuItem.Click += AbrirToolStripMenuItem_Click;
            salvarToolStripMenuItem.Click += SalvarToolStripMenuItem_Click;
            sairToolStripMenuItem.Click += SairToolStripMenuItem_Click;

            // Associando um manipulador de eventos para o fechamento do formulário
            this.FormClosing += MeuFormulario_FormClosing;
        }

        private void NovoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Você clicou em Novo!");
        }

        private void AbrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Você clicou em Abrir!");
        }

        private void SalvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Você clicou em Salvar!");
        }

        private void SairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MeuFormulario_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Verificando se o usuário realmente deseja sair
            DialogResult resultado = MessageBox.Show("Deseja realmente sair?", "Sair",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.No)
            {
                e.Cancel = true; // Cancela o fechamento do formulário
            }
        }
    }
}
```

Neste exemplo:

- Criamos um `MenuStrip` chamado `menuStrip1`.
- Criamos itens de menu como "Arquivo" e "Editar" e associamos itens de submenu a eles.
- Adicionamos manipuladores de eventos aos itens de menu para responder a eventos de clique.
- Associamos um manipulador de eventos ao evento de fechamento do formulário para confirmar se o usuário realmente deseja sair.

Este é um exemplo básico, e você pode personalizar o `MenuStrip` adicionando mais itens de menu, manipulando eventos adicionais e ajustando a lógica conforme necessário para atender às necessidades específicas do seu aplicativo.