# RADIOBUTTON
O controle `RadioButton` em Windows Forms é usado para criar botões de opção que permitem aos usuários escolher uma única opção de um grupo. A principal característica dos botões de opção é que, quando um botão de opção é marcado, ele desmarca automaticamente os outros botões de opção no mesmo grupo.

Aqui está um exemplo básico de como usar o `RadioButton` em um formulário Windows Forms:

```csharp
using System;
using System.Windows.Forms;

namespace MeuProjetoWinForms
{
    public partial class MeuFormulario : Form
    {
        private RadioButton radioButtonOpcao1;
        private RadioButton radioButtonOpcao2;

        public MeuFormulario()
        {
            InitializeComponent();
            
            // Criando um grupo de botões de opção
            GroupBox groupBoxOpcoes = new GroupBox();
            groupBoxOpcoes.Text = "Opções";
            groupBoxOpcoes.Location = new System.Drawing.Point(20, 20);
            this.Controls.Add(groupBoxOpcoes);

            // Criando o primeiro RadioButton
            radioButtonOpcao1 = new RadioButton();
            radioButtonOpcao1.Text = "Opção 1";
            radioButtonOpcao1.Location = new System.Drawing.Point(10, 20);
            radioButtonOpcao1.CheckedChanged += RadioButtonOpcao_CheckedChanged; // Associando um manipulador de eventos
            groupBoxOpcoes.Controls.Add(radioButtonOpcao1);

            // Criando o segundo RadioButton
            radioButtonOpcao2 = new RadioButton();
            radioButtonOpcao2.Text = "Opção 2";
            radioButtonOpcao2.Location = new System.Drawing.Point(10, 50);
            radioButtonOpcao2.CheckedChanged += RadioButtonOpcao_CheckedChanged; // Associando um manipulador de eventos
            groupBoxOpcoes.Controls.Add(radioButtonOpcao2);
        }

        private void RadioButtonOpcao_CheckedChanged(object sender, EventArgs e)
        {
            // Manipulador de eventos para tratar as mudanças no estado dos RadioButtons
            RadioButton radioButtonSelecionado = (RadioButton)sender;

            if (radioButtonSelecionado.Checked)
            {
                MessageBox.Show("Opção selecionada: " + radioButtonSelecionado.Text);
            }
        }
    }
}
```

Neste exemplo:

- Criamos dois `RadioButton`s (`radioButtonOpcao1` e `radioButtonOpcao2`) dentro de um `GroupBox` para agrupá-los.
- Associamos o método `RadioButtonOpcao_CheckedChanged` ao evento `CheckedChanged` de ambos os botões.
- Quando um `RadioButton` é marcado, o evento é acionado e exibimos uma mensagem indicando a opção selecionada.

Principais propriedades do `RadioButton`:

- **Text:** Define ou obtém o texto exibido ao lado do botão de opção.
- **Checked:** Indica se o botão de opção está marcado ou não.
- **GroupName:** Especifica o nome do grupo ao qual o botão de opção pertence.

Adapte esse código conforme necessário para atender às necessidades específicas do seu aplicativo.