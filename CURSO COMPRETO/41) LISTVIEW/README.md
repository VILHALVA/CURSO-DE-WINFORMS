# LISTVIEW
Vamos criar um exemplo de projeto que utiliza um `ListView` no Windows Forms. O `ListView` é um controle mais avançado do que o `ListBox`, permitindo exibir itens com mais detalhes, como ícones, subitens, e diferentes modos de visualização.

## Exemplo de Código:
```csharp
using System;
using System.Windows.Forms;

public class ListViewForm : Form
{
    private ListView listView;
    private Label selectedItemLabel;

    public ListViewForm()
    {
        // Configuração da janela
        Text = "Exemplo de ListView";
        Size = new System.Drawing.Size(500, 400);

        // Inicialização do ListView
        listView = new ListView();
        listView.Location = new System.Drawing.Point(50, 50);
        listView.Size = new System.Drawing.Size(300, 200);
        listView.View = View.Details; // Modo de exibição em detalhes

        // Adicionando colunas ao ListView
        listView.Columns.Add("Nome", 150, HorizontalAlignment.Left);
        listView.Columns.Add("Descrição", 150, HorizontalAlignment.Left);

        // Adicionando itens ao ListView
        ListViewItem item1 = new ListViewItem(new[] { "Item 1", "Descrição do Item 1" });
        ListViewItem item2 = new ListViewItem(new[] { "Item 2", "Descrição do Item 2" });
        ListViewItem item3 = new ListViewItem(new[] { "Item 3", "Descrição do Item 3" });
        listView.Items.AddRange(new[] { item1, item2, item3 });

        // Adicionando evento de seleção ao ListView
        listView.SelectedIndexChanged += new EventHandler(ListViewSelectionChanged);

        // Inicialização do Label para exibir o item selecionado
        selectedItemLabel = new Label();
        selectedItemLabel.Location = new System.Drawing.Point(50, 270);
        selectedItemLabel.Size = new System.Drawing.Size(300, 30);

        // Adicionando o ListView e o Label ao Form
        Controls.Add(listView);
        Controls.Add(selectedItemLabel);
    }

    // Manipulador de evento para seleção no ListView
    private void ListViewSelectionChanged(object sender, EventArgs e)
    {
        if (listView.SelectedItems.Count > 0)
        {
            selectedItemLabel.Text = "Selecionado: " + listView.SelectedItems[0].Text + " - " + listView.SelectedItems[0].SubItems[1].Text;
        }
    }

    // Método Main para iniciar a aplicação
    public static void Main()
    {
        Application.Run(new ListViewForm());
    }
}
```

## Explicação do Código:
1. **Configuração do Form**:
   - A janela é configurada com um título e um tamanho.

2. **Inicialização do ListView**:
   - Um `ListView` é criado e posicionado no formulário.
   - O modo de exibição é configurado para `View.Details`, que permite a exibição de itens em linhas com colunas.

3. **Adicionando Colunas**:
   - Duas colunas são adicionadas ao `ListView`: "Nome" e "Descrição".

4. **Adicionando Itens**:
   - Três itens são adicionados ao `ListView`, cada um com um nome e uma descrição.

5. **Evento de Seleção do ListView**:
   - O evento `SelectedIndexChanged` é associado ao manipulador de eventos `ListViewSelectionChanged`.
   - Quando um item é selecionado no `ListView`, o método `ListViewSelectionChanged` é chamado, atualizando o texto de um `Label` com o item selecionado e sua descrição.

6. **Inicialização do Label**:
   - Um `Label` é criado para exibir o item selecionado no `ListView` e posicionado abaixo do `ListView`.

7. **Método Main**:
   - Inicia a aplicação e exibe o formulário.

Este exemplo cria uma aplicação Windows Forms simples com um `ListView` que permite ao usuário selecionar itens e exibe o item selecionado em um `Label`. Você pode modificar os itens do `ListView` e personalizar o layout conforme necessário para suas necessidades.