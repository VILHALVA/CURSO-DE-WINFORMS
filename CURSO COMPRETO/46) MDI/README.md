# MDI
Em uma aplicação Windows Forms, MDI (Multiple Document Interface) permite que você crie uma interface na qual várias janelas filhas podem ser exibidas dentro de uma janela pai, chamada de formulário MDI. Isso é útil em casos onde você precisa gerenciar múltiplos documentos ou visualizações dentro de uma única aplicação.

Aqui está um exemplo básico de como criar e usar um formulário MDI em C#:

## Passos para criar um formulário MDI
1. **Crie um novo projeto Windows Forms:**

   Abra o Visual Studio, selecione `File` -> `New` -> `Project...`, escolha `Windows Forms App (.NET Framework)` e dê um nome ao seu projeto.

2. **Crie os formulários:**

   - **Formulário pai (MDI Container)**: Este será o formulário principal que conterá os formulários filhos.
   - **Formulários filhos**: Estes serão os formulários que serão exibidos dentro do formulário MDI.

3. **Configuração dos formulários:**

   Abaixo está um exemplo básico com dois formulários, um como MDI container e outro como formulário filho.

## Exemplo de código
**Formulário MDI Container (`FormMDIContainer.cs`):**

```csharp
using System;
using System.Windows.Forms;

namespace MDIExample
{
    public partial class FormMDIContainer : Form
    {
        public FormMDIContainer()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            FormChild childForm = new FormChild();
            childForm.MdiParent = this; // Define este formulário como o pai do formulário filho
            childForm.Show(); // Mostra o formulário filho
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); // Fecha a aplicação
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade); // Organiza os formulários filhos em cascata
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical); // Organiza os formulários filhos lado a lado verticalmente
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal); // Organiza os formulários filhos lado a lado horizontalmente
        }

        // Método principal para iniciar a aplicação
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMDIContainer());
        }
    }
}
```

**Formulário Filho (`FormChild.cs`):**

```csharp
using System;
using System.Windows.Forms;

namespace MDIExample
{
    public partial class FormChild : Form
    {
        public FormChild()
        {
            InitializeComponent();
        }

        private void FormChild_Load(object sender, EventArgs e)
        {
            // Configuração inicial do formulário filho
            this.Text = "Formulário Filho";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); // Fecha o formulário filho
        }
    }
}
```

**Design de `FormMDIContainer`:**

No designer do formulário MDI container (`FormMDIContainer`), adicione um `MenuStrip` e configure os itens de menu para controlar a criação e organização dos formulários filhos. Exemplo:

- Adicione um `MenuStrip` (`menuStrip`) com itens como `File` e `Window`.
- Em `Window`, adicione opções como `New Window`, `Cascade`, `Tile Vertical`, `Tile Horizontal`, etc.
- Associe os eventos desses itens de menu para manipular a criação e a organização dos formulários filhos.

## Explicação do Código
- **FormMDIContainer**:
  - Configura o formulário principal como um formulário MDI usando `this.IsMdiContainer = true;`.
  - Define os métodos para criar novos formulários filhos (`ShowNewForm`), fechar a aplicação (`ExitToolsStripMenuItem_Click`) e organizar os formulários filhos (`CascadeToolStripMenuItem_Click`, `TileVerticalToolStripMenuItem_Click`, `TileHorizontalToolStripMenuItem_Click`).
  - No método `Main`, inicia a aplicação Windows Forms.

- **FormChild**:
  - Um exemplo simples de um formulário filho que exibe "Formulário Filho" no título.
  - Inclui um botão de fechar (`btnClose`) para fechar o formulário.

## Como executar
- Compile e execute o projeto.
- O `FormMDIContainer` será exibido como o formulário principal da aplicação.
- Use o menu `Window` para criar novos formulários filhos, organizar ou fechar os formulários.

## Considerações Finais
Este exemplo oferece uma introdução básica ao uso de MDI em uma aplicação Windows Forms. Você pode expandir isso adicionando mais funcionalidades aos formulários filhos, como menus específicos, controles de entrada de dados, etc. MDI é útil em cenários onde você precisa manter múltiplas janelas relacionadas dentro de uma única interface de usuário.