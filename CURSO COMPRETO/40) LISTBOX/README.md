# LISTBOX
Esse exemplo demonstrará como adicionar itens ao `ListBox`, manipular eventos de seleção e exibir a seleção atual.

## Exemplo de Código:
```csharp
using System;
using System.Windows.Forms;

public class ListBoxForm : Form
{
    private ListBox listBox;
    private Label selectedItemLabel;

    public ListBoxForm()
    {
        // Configuração da janela
        Text = "Exemplo de ListBox";
        Size = new System.Drawing.Size(400, 300);

        // Inicialização do ListBox
        listBox = new ListBox();
        listBox.Location = new System.Drawing.Point(50, 50);
        listBox.Size = new System.Drawing.Size(200, 150);

        // Adicionando itens ao ListBox
        listBox.Items.Add("Item 1");
        listBox.Items.Add("Item 2");
        listBox.Items.Add("Item 3");
        listBox.Items.Add("Item 4");

        // Adicionando evento de seleção ao ListBox
        listBox.SelectedIndexChanged += new EventHandler(ListBoxSelectionChanged);

        // Inicialização do Label para exibir o item selecionado
        selectedItemLabel = new Label();
        selectedItemLabel.Location = new System.Drawing.Point(50, 220);
        selectedItemLabel.Size = new System.Drawing.Size(200, 30);

        // Adicionando o ListBox e o Label ao Form
        Controls.Add(listBox);
        Controls.Add(selectedItemLabel);
    }

    // Manipulador de evento para seleção no ListBox
    private void ListBoxSelectionChanged(object sender, EventArgs e)
    {
        if (listBox.SelectedItem != null)
        {
            selectedItemLabel.Text = "Selecionado: " + listBox.SelectedItem.ToString();
        }
    }

    // Método Main para iniciar a aplicação
    public static void Main()
    {
        Application.Run(new ListBoxForm());
    }
}
```

## Explicação do Código:
1. **Configuração do Form**:
   - A janela é configurada com um título e um tamanho.

2. **Inicialização do ListBox**:
   - Um `ListBox` é criado e posicionado no formulário.
   - Quatro itens são adicionados ao `ListBox`.

3. **Evento de Seleção do ListBox**:
   - O evento `SelectedIndexChanged` é associado ao manipulador de eventos `ListBoxSelectionChanged`.
   - Quando um item é selecionado no `ListBox`, o método `ListBoxSelectionChanged` é chamado, atualizando o texto de um `Label` com o item selecionado.

4. **Inicialização do Label**:
   - Um `Label` é criado para exibir o item selecionado no `ListBox` e posicionado abaixo do `ListBox`.

5. **Método Main**:
   - Inicia a aplicação e exibe o formulário.

Este exemplo cria uma aplicação Windows Forms simples com um `ListBox` que permite ao usuário selecionar itens e exibe o item selecionado em um `Label`. Você pode modificar os itens do `ListBox` e personalizar o layout conforme necessário para suas necessidades.