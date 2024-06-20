# LS-STYLES
No controle `ListView` do Windows Forms, existem vários estilos de exibição, que são definidos pela propriedade `View`. Cada estilo oferece uma maneira diferente de apresentar os itens na lista. Vamos explorar os diferentes estilos de exibição (`View`) e como configurar cada um deles.

## Estilos de Exibição do ListView
1. **View.Details**:
   - Exibe os itens em linhas, com colunas para detalhes adicionais.
   - Esse modo é útil quando você precisa exibir várias informações sobre cada item.

2. **View.LargeIcon**:
   - Exibe cada item com um ícone grande.
   - Esse modo é útil para visualizações onde os ícones são a principal forma de identificar os itens.

3. **View.SmallIcon**:
   - Exibe cada item com um ícone pequeno.
   - Similar ao `LargeIcon`, mas com ícones menores, permitindo mais itens visíveis ao mesmo tempo.

4. **View.List**:
   - Exibe os itens em uma única coluna com ícones pequenos e texto.
   - Útil para listas simples onde você não precisa de detalhes adicionais.

5. **View.Tile**:
   - Exibe os itens como blocos com ícones grandes e texto ao lado.
   - Esse modo pode mostrar informações adicionais de cada item se configurado.

## Exemplo de Código com Diferentes Estilos de Exibição
Aqui está um exemplo que demonstra como alternar entre os diferentes estilos de exibição do `ListView` em um formulário Windows Forms.

```csharp
using System;
using System.Windows.Forms;

public class ListViewForm : Form
{
    private ListView listView;
    private ComboBox viewSelector;
    private ImageList largeImageList;
    private ImageList smallImageList;

    public ListViewForm()
    {
        // Configuração da janela
        Text = "Exemplo de ListView com Diferentes Estilos";
        Size = new System.Drawing.Size(500, 400);

        // Inicialização do ListView
        listView = new ListView();
        listView.Location = new System.Drawing.Point(50, 50);
        listView.Size = new System.Drawing.Size(300, 200);

        // Adicionando colunas ao ListView
        listView.Columns.Add("Nome", 150, HorizontalAlignment.Left);
        listView.Columns.Add("Descrição", 150, HorizontalAlignment.Left);

        // Inicialização das listas de imagens
        largeImageList = new ImageList();
        largeImageList.ImageSize = new System.Drawing.Size(64, 64);
        largeImageList.Images.Add(SystemIcons.Application);

        smallImageList = new ImageList();
        smallImageList.ImageSize = new System.Drawing.Size(16, 16);
        smallImageList.Images.Add(SystemIcons.Application);

        listView.LargeImageList = largeImageList;
        listView.SmallImageList = smallImageList;

        // Adicionando itens ao ListView
        ListViewItem item1 = new ListViewItem(new[] { "Item 1", "Descrição do Item 1" });
        item1.ImageIndex = 0;
        ListViewItem item2 = new ListViewItem(new[] { "Item 2", "Descrição do Item 2" });
        item2.ImageIndex = 0;
        ListViewItem item3 = new ListViewItem(new[] { "Item 3", "Descrição do Item 3" });
        item3.ImageIndex = 0;
        listView.Items.AddRange(new[] { item1, item2, item3 });

        // Inicialização do ComboBox para seleção de visualização
        viewSelector = new ComboBox();
        viewSelector.Location = new System.Drawing.Point(50, 270);
        viewSelector.Items.AddRange(Enum.GetNames(typeof(View)));
        viewSelector.SelectedIndexChanged += new EventHandler(ViewSelectorChanged);
        viewSelector.SelectedIndex = 0; // Seleciona o primeiro item por padrão

        // Adicionando o ListView e o ComboBox ao Form
        Controls.Add(listView);
        Controls.Add(viewSelector);
    }

    // Manipulador de evento para mudança de visualização
    private void ViewSelectorChanged(object sender, EventArgs e)
    {
        listView.View = (View)Enum.Parse(typeof(View), viewSelector.SelectedItem.ToString());
    }

    // Método Main para iniciar a aplicação
    public static void Main()
    {
        Application.Run(new ListViewForm());
    }
}
```

## Explicação do Código
1. **Configuração do Form**:
   - A janela é configurada com um título e um tamanho.

2. **Inicialização do ListView**:
   - Um `ListView` é criado e posicionado no formulário.
   - Duas colunas são adicionadas para exibir detalhes adicionais.

3. **Inicialização das Listas de Imagens**:
   - Duas listas de imagens (`ImageList`) são criadas: uma para ícones grandes e outra para ícones pequenos.
   - Ícones de sistema são adicionados a essas listas.

4. **Adicionando Itens ao ListView**:
   - Três itens são adicionados ao `ListView`, cada um associado a um ícone.

5. **Inicialização do ComboBox**:
   - Um `ComboBox` é criado para permitir a seleção do estilo de exibição do `ListView`.
   - Os nomes dos diferentes estilos de exibição (`View`) são adicionados ao `ComboBox`.

6. **Evento de Mudança de Visualização**:
   - O evento `SelectedIndexChanged` do `ComboBox` é associado ao método `ViewSelectorChanged`, que altera o estilo de exibição do `ListView` conforme a seleção do usuário.

7. **Método Main**:
   - Inicia a aplicação e exibe o formulário.

Este exemplo demonstra como usar o `ListView` com diferentes estilos de exibição e como permitir que o usuário alterne entre esses estilos dinamicamente usando um `ComboBox`.