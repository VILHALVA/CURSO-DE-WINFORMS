# LISTBOX
O controle `ListBox` em Windows Forms é usado para exibir uma lista de itens em uma única coluna. Ele fornece uma maneira simples de apresentar opções para o usuário ou exibir uma lista de itens selecionáveis.

Aqui está um exemplo básico de como usar o `ListBox` em um formulário Windows Forms:

```csharp
using System;
using System.Windows.Forms;

namespace MeuProjetoWinForms
{
    public partial class MeuFormulario : Form
    {
        private ListBox listBox1;

        public MeuFormulario()
        {
            InitializeComponent();

            // Criando um ListBox
            listBox1 = new ListBox();
            listBox1.Location = new System.Drawing.Point(20, 20);
            listBox1.Size = new System.Drawing.Size(150, 120);
            this.Controls.Add(listBox1);

            // Adicionando itens ao ListBox
            listBox1.Items.Add("Item 1");
            listBox1.Items.Add("Item 2");
            listBox1.Items.Add("Item 3");

            // Associando um manipulador de eventos ao evento SelectedIndexChanged
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Manipulador de eventos para tratar a mudança na seleção de itens
            ListBox listBox = (ListBox)sender;

            if (listBox.SelectedIndex != -1)
            {
                MessageBox.Show("Item selecionado: " + listBox.SelectedItem.ToString());
            }
        }
    }
}
```

Neste exemplo:

- Criamos um `ListBox` chamado `listBox1`.
- Adicionamos itens ao `ListBox` usando `listBox1.Items.Add()`.
- Associamos um manipulador de eventos ao evento `SelectedIndexChanged` para tratar a mudança na seleção de itens.

Principais propriedades do `ListBox`:

- **Items:** Coleção de itens no `ListBox`.
- **SelectedIndex:** Índice do item selecionado. -1 se nenhum item estiver selecionado.
- **SelectedItem:** Retorna o item selecionado como um objeto.

Personalize esse código conforme necessário para atender às necessidades específicas do seu aplicativo. O `ListBox` é útil para apresentar uma lista simples de itens, e você pode personalizar a aparência e o comportamento conforme necessário.