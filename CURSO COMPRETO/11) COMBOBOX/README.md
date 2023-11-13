# COMBOBOX
O controle `ComboBox` em Windows Forms é utilizado para criar uma lista suspensa que permite aos usuários escolher um item de uma lista de opções. Aqui está um exemplo básico de como usar o `ComboBox` em um formulário Windows Forms:

```csharp
using System;
using System.Windows.Forms;

namespace MeuProjetoWinForms
{
    public partial class MeuFormulario : Form
    {
        private ComboBox comboBoxOpcoes;

        public MeuFormulario()
        {
            InitializeComponent();

            // Criando um ComboBox
            comboBoxOpcoes = new ComboBox();
            comboBoxOpcoes.Location = new System.Drawing.Point(20, 20);
            this.Controls.Add(comboBoxOpcoes);

            // Adicionando itens ao ComboBox
            comboBoxOpcoes.Items.Add("Opção 1");
            comboBoxOpcoes.Items.Add("Opção 2");
            comboBoxOpcoes.Items.Add("Opção 3");

            // Associando um manipulador de eventos ao evento SelectedIndexChanged
            comboBoxOpcoes.SelectedIndexChanged += ComboBoxOpcoes_SelectedIndexChanged;
        }

        private void ComboBoxOpcoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Manipulador de eventos para tratar a seleção de itens no ComboBox
            ComboBox comboBox = (ComboBox)sender;

            if (comboBox.SelectedIndex != -1)
            {
                MessageBox.Show("Opção selecionada: " + comboBox.SelectedItem.ToString());
            }
        }
    }
}
```

Neste exemplo:

- Criamos um `ComboBox` chamado `comboBoxOpcoes`.
- Adicionamos itens ao `ComboBox` usando `comboBoxOpcoes.Items.Add()`.
- Associamos o método `ComboBoxOpcoes_SelectedIndexChanged` ao evento `SelectedIndexChanged`, que é acionado quando o usuário seleciona um item no `ComboBox`.

Principais propriedades do `ComboBox`:

- **Items:** Coleção que representa os itens na lista suspensa.
- **SelectedIndex:** Índice do item selecionado. -1 se nenhum item estiver selecionado.
- **SelectedItem:** Retorna o item selecionado como um objeto.
- **Text:** Obtém ou define o texto exibido na caixa de texto do `ComboBox`.

Você pode personalizar o código conforme necessário para atender às necessidades específicas do seu aplicativo. Além disso, é possível carregar itens dinamicamente, manipular eventos adicionais e estilizar o controle de acordo com os requisitos do seu projeto.