# TREEVIEW
O controle `TreeView` em Windows Forms é usado para exibir dados em uma estrutura hierárquica de árvore, onde os itens podem ter filhos e pais. É uma escolha comum para exibir estruturas de dados que têm uma relação hierárquica, como diretórios e arquivos, categorias e subcategorias, entre outros.

Aqui está um exemplo básico de como usar o `TreeView` em um formulário Windows Forms:

```csharp
using System;
using System.Windows.Forms;

namespace MeuProjetoWinForms
{
    public partial class MeuFormulario : Form
    {
        private TreeView treeView1;

        public MeuFormulario()
        {
            InitializeComponent();

            // Criando um TreeView
            treeView1 = new TreeView();
            treeView1.Location = new System.Drawing.Point(20, 20);
            treeView1.Size = new System.Drawing.Size(200, 150);
            this.Controls.Add(treeView1);

            // Adicionando nós ao TreeView
            TreeNode nodeRoot = new TreeNode("Raiz");
            treeView1.Nodes.Add(nodeRoot);

            TreeNode nodeFilho1 = new TreeNode("Filho 1");
            nodeRoot.Nodes.Add(nodeFilho1);

            TreeNode nodeFilho2 = new TreeNode("Filho 2");
            nodeRoot.Nodes.Add(nodeFilho2);

            TreeNode nodeNeto = new TreeNode("Neto");
            nodeFilho2.Nodes.Add(nodeNeto);

            // Associando um manipulador de eventos ao evento AfterSelect
            treeView1.AfterSelect += TreeView1_AfterSelect;
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Manipulador de eventos para tratar a seleção de um nó no TreeView
            TreeNode selectedNode = treeView1.SelectedNode;

            if (selectedNode != null)
            {
                MessageBox.Show("Nó selecionado: " + selectedNode.Text);
            }
        }
    }
}
```

Neste exemplo:

- Criamos um `TreeView` chamado `treeView1`.
- Adicionamos alguns nós hierárquicos ao `TreeView`.
- Associamos um manipulador de eventos ao evento `AfterSelect` para tratar a seleção de um nó no `TreeView`.

Principais propriedades do `TreeView`:

- **Nodes:** Coleção de nós no `TreeView`.
- **SelectedNode:** Retorna ou define o nó atualmente selecionado.
- **AfterSelect:** Evento acionado após um nó ser selecionado.

O controle `TreeView` é especialmente útil para exibir dados em formato de árvore, facilitando a navegação e a visualização hierárquica. Personalize o código conforme necessário para atender às necessidades específicas do seu aplicativo.