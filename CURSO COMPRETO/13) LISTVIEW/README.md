# LISTVIEW
O controle `ListView` em Windows Forms é utilizado para exibir uma lista de itens em um formato tabular. Ele fornece uma maneira flexível de exibir e manipular dados, incluindo a capacidade de exibir itens em colunas e até mesmo a opção de exibir ícones junto com os textos dos itens.

Aqui está um exemplo básico de como usar o `ListView` em um formulário Windows Forms:

```csharp
using System;
using System.Windows.Forms;

namespace MeuProjetoWinForms
{
    public partial class MeuFormulario : Form
    {
        private ListView listView1;

        public MeuFormulario()
        {
            InitializeComponent();

            // Criando um ListView
            listView1 = new ListView();
            listView1.Location = new System.Drawing.Point(20, 20);
            listView1.Size = new System.Drawing.Size(300, 200);
            this.Controls.Add(listView1);

            // Configurando o estilo de exibição
            listView1.View = View.Details; // Exibe os itens em formato de detalhes (colunas)

            // Adicionando colunas
            listView1.Columns.Add("ID", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("Nome", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Idade", 50, HorizontalAlignment.Left);

            // Adicionando itens
            ListViewItem item1 = new ListViewItem("1");
            item1.SubItems.Add("João");
            item1.SubItems.Add("25");

            ListViewItem item2 = new ListViewItem("2");
            item2.SubItems.Add("Maria");
            item2.SubItems.Add("30");

            listView1.Items.AddRange(new ListViewItem[] { item1, item2 });

            // Associando um manipulador de eventos ao evento ItemSelectionChanged
            listView1.ItemSelectionChanged += ListView1_ItemSelectionChanged;
        }

        private void ListView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            // Manipulador de eventos para tratar a mudança na seleção de itens
            if (e.IsSelected)
            {
                MessageBox.Show($"Item selecionado: {e.Item.SubItems[1].Text} (ID: {e.Item.SubItems[0].Text})");
            }
        }
    }
}
```

Neste exemplo:

- Criamos um `ListView` chamado `listView1`.
- Configuramos o `View` para `View.Details`, que exibe os itens em formato de detalhes (em colunas).
- Adicionamos colunas usando `listView1.Columns.Add()`.
- Adicionamos itens usando `ListViewItem` e `item.SubItems.Add()`.
- Associamos um manipulador de eventos ao evento `ItemSelectionChanged` para tratar a mudança na seleção de itens.

Principais propriedades do `ListView`:

- **View:** Define o estilo de exibição (`Details`, `LargeIcon`, `SmallIcon`, `List`, etc.).
- **Columns:** Coleção de colunas no `ListView`.
- **Items:** Coleção de itens no `ListView`.
- **SelectedItems:** Coleção dos itens selecionados.

Personalize esse código conforme necessário para atender às necessidades específicas do seu aplicativo. O `ListView` oferece muitas opções para personalização, incluindo a capacidade de exibir ícones, imagens e muito mais.