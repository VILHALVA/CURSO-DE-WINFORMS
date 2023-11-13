# GROUPBOX
O controle `GroupBox` em Windows Forms é utilizado para agrupar outros controles, fornecendo uma estrutura organizada para eles. Um `GroupBox` é frequentemente usado para agrupar controles relacionados visualmente e melhorar a organização da interface do usuário.

Aqui está um exemplo básico de como usar o `GroupBox` em um formulário Windows Forms:

```csharp
using System;
using System.Windows.Forms;

namespace MeuProjetoWinForms
{
    public partial class MeuFormulario : Form
    {
        private GroupBox groupBoxOpcoes;
        private RadioButton radioButtonOpcao1;
        private RadioButton radioButtonOpcao2;

        public MeuFormulario()
        {
            InitializeComponent();
            
            // Criando um GroupBox
            groupBoxOpcoes = new GroupBox();
            groupBoxOpcoes.Text = "Opções";
            groupBoxOpcoes.Location = new System.Drawing.Point(20, 20);
            this.Controls.Add(groupBoxOpcoes);

            // Criando RadioButton dentro do GroupBox
            radioButtonOpcao1 = new RadioButton();
            radioButtonOpcao1.Text = "Opção 1";
            radioButtonOpcao1.Location = new System.Drawing.Point(10, 20);
            groupBoxOpcoes.Controls.Add(radioButtonOpcao1);

            radioButtonOpcao2 = new RadioButton();
            radioButtonOpcao2.Text = "Opção 2";
            radioButtonOpcao2.Location = new System.Drawing.Point(10, 50);
            groupBoxOpcoes.Controls.Add(radioButtonOpcao2);

            // Associando um manipulador de eventos aos RadioButtons
            radioButtonOpcao1.CheckedChanged += RadioButtonOpcao_CheckedChanged;
            radioButtonOpcao2.CheckedChanged += RadioButtonOpcao_CheckedChanged;
        }

        private void RadioButtonOpcao_CheckedChanged(object sender, EventArgs e)
        {
            // Manipulador de eventos para tratar as mudanças no estado dos RadioButtons
            RadioButton radioButtonSelecionado = (RadioButton)sender;

            if (radioButtonSelecionado.Checked)
            {
                MessageBox.Show("Opção selecionada dentro do GroupBox: " + radioButtonSelecionado.Text);
            }
        }
    }
}
```

Neste exemplo:

- Criamos um `GroupBox` chamado `groupBoxOpcoes` que agrupa dois `RadioButton`s.
- Adicionamos os `RadioButton`s dentro do `GroupBox` usando `groupBoxOpcoes.Controls.Add()`.
- Associamos o método `RadioButtonOpcao_CheckedChanged` ao evento `CheckedChanged` de ambos os botões.

Principais propriedades do `GroupBox`:

- **Text:** Define ou obtém o texto exibido na borda do grupo.

Você pode usar o `GroupBox` para agrupar diferentes tipos de controles (por exemplo, `RadioButton`, `CheckBox`, `TextBox`, etc.) em uma interface do usuário para torná-la mais organizada e fácil de entender. Personalize o código conforme necessário para atender aos requisitos específicos do seu aplicativo.