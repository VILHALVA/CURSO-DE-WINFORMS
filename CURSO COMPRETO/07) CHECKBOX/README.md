# CHECKBOX
O controle `CheckBox` em Windows Forms é usado para criar caixas de seleção que permitem aos usuários escolher entre duas opções (verdadeiro ou falso, ativado ou desativado, etc.). Aqui está um exemplo básico de como usar o `CheckBox` em um formulário Windows Forms:

```csharp
using System;
using System.Windows.Forms;

namespace MeuProjetoWinForms
{
    public partial class MeuFormulario : Form
    {
        private CheckBox checkBox1;

        public MeuFormulario()
        {
            InitializeComponent();
            
            // Criando um CheckBox usando o designer
            CheckBox checkBoxDesigner = new CheckBox();
            checkBoxDesigner.Text = "Opção do Designer";
            checkBoxDesigner.Location = new System.Drawing.Point(20, 20);
            checkBoxDesigner.CheckedChanged += CheckBoxDesigner_CheckedChanged; // Associando um manipulador de eventos
            this.Controls.Add(checkBoxDesigner);

            // Criando um CheckBox no código
            checkBox1 = new CheckBox();
            checkBox1.Text = "Opção do Código";
            checkBox1.Location = new System.Drawing.Point(20, 50);
            checkBox1.CheckedChanged += CheckBox1_CheckedChanged; // Associando um manipulador de eventos
            this.Controls.Add(checkBox1);
        }

        private void CheckBoxDesigner_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Opção do Designer: " + ((CheckBox)sender).Checked.ToString());
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Opção do Código: " + checkBox1.Checked.ToString());
        }
    }
}
```

Neste exemplo:

- Dois `CheckBox` são criados, um usando o designer e outro no código.
- Para cada `CheckBox`, associamos um manipulador de eventos ao evento `CheckedChanged`. Esse evento é acionado quando o estado da caixa de seleção é alterado.
- Quando um `CheckBox` é clicado, uma caixa de mensagem é exibida informando se a opção está marcada ou desmarcada.

Principais propriedades do `CheckBox`:

- **Checked:** Indica se a caixa de seleção está marcada ou não.
- **Text:** Define ou obtém o texto exibido junto à caixa de seleção.

Este é um exemplo simples, e você pode personalizar o código conforme necessário para atender aos requisitos específicos do seu aplicativo.