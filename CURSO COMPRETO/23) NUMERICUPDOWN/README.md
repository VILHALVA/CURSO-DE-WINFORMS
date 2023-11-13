# NUMERICUPDOWN
O controle `NumericUpDown` em Windows Forms é usado para permitir que os usuários selecionem um valor numérico em um intervalo específico. Ele fornece uma caixa de rotação (up-down) para aumentar ou diminuir o valor numérico.

Aqui está um exemplo básico de como usar o `NumericUpDown` em um formulário Windows Forms:

```csharp
using System;
using System.Windows.Forms;

namespace MeuProjetoWinForms
{
    public partial class MeuFormulario : Form
    {
        private NumericUpDown numericUpDown1;

        public MeuFormulario()
        {
            InitializeComponent();

            // Criando um NumericUpDown
            numericUpDown1 = new NumericUpDown();
            numericUpDown1.Location = new System.Drawing.Point(20, 20);
            numericUpDown1.Size = new System.Drawing.Size(120, 20);
            numericUpDown1.Minimum = 0; // Valor mínimo permitido
            numericUpDown1.Maximum = 100; // Valor máximo permitido
            numericUpDown1.Value = 50; // Valor inicial
            this.Controls.Add(numericUpDown1);

            // Associando um manipulador de eventos ao evento ValueChanged
            numericUpDown1.ValueChanged += NumericUpDown1_ValueChanged;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // Manipulador de eventos para tratar a mudança no valor do NumericUpDown
            NumericUpDown numericUpDown = (NumericUpDown)sender;

            MessageBox.Show("Novo valor: " + numericUpDown.Value.ToString());
        }
    }
}
```

Neste exemplo:

- Criamos um `NumericUpDown` chamado `numericUpDown1`.
- Configuramos seu valor mínimo, máximo e valor inicial.
- Associamos um manipulador de eventos ao evento `ValueChanged` para tratar a mudança no valor do `NumericUpDown`.

Principais propriedades do `NumericUpDown`:

- **Minimum:** Obtém ou define o valor mínimo permitido.
- **Maximum:** Obtém ou define o valor máximo permitido.
- **Value:** Obtém ou define o valor atual.
- **DecimalPlaces:** Obtém ou define o número de casas decimais exibidas.
- **Increment:** Obtém ou define o valor pelo qual o `NumericUpDown` é incrementado ou decrementado quando os botões são pressionados.

O controle `NumericUpDown` é útil para permitir que os usuários escolham valores numéricos em um intervalo específico de uma maneira fácil e intuitiva. Personalize o código conforme necessário para atender às necessidades específicas do seu aplicativo.